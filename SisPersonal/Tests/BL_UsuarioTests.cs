using NUnit.Framework;
using BL;
using CAD;
using CE;
using Moq;
using System.Data;

namespace Tests
{
    [TestFixture]
    public class BL_UsuarioTests
    {
        private Mock<ID_Usuario> _mockDUsuario;
        private BL_Usuario _blUsuario;
        private E_Usuario _usuarioTest;

        [SetUp]
        public void Setup()
        {
            _mockDUsuario = new Mock<ID_Usuario>();
            _blUsuario = new BL_Usuario(_mockDUsuario.Object);
            
            _usuarioTest = new E_Usuario
            {
                IdUsuario = 1,
                Usuario = "admin",
                Clave = "123456",
                Estado = 1,
                Perfil = "Administrador"
            };
        }

        [Test]
        public void Login_ValidUser_ReturnsDataTable()
        {
            // Arrange
            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add("IdUsuario", typeof(int));
            expectedDataTable.Columns.Add("Usuario", typeof(string));
            expectedDataTable.Columns.Add("Perfil", typeof(string));
            expectedDataTable.Rows.Add(1, "admin", "Administrador");

            _mockDUsuario.Setup(x => x.Login(It.IsAny<E_Usuario>()))
                        .Returns(expectedDataTable);

            // Act
            var result = _blUsuario.Login(_usuarioTest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Rows.Count);
            Assert.AreEqual("admin", result.Rows[0]["Usuario"]);
            Assert.AreEqual("Administrador", result.Rows[0]["Perfil"]);
            _mockDUsuario.Verify(x => x.Login(It.IsAny<E_Usuario>()), Times.Once);
        }

        [Test]
        public void Login_InvalidUser_ReturnsEmptyDataTable()
        {
            // Arrange
            var emptyDataTable = new DataTable();
            _mockDUsuario.Setup(x => x.Login(It.IsAny<E_Usuario>()))
                        .Returns(emptyDataTable);

            var invalidUser = new E_Usuario { Usuario = "invalid", Clave = "wrong" };

            // Act
            var result = _blUsuario.Login(invalidUser);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
            _mockDUsuario.Verify(x => x.Login(It.IsAny<E_Usuario>()), Times.Once);
        }

        [Test]
        public void GenerarCodigo_ReturnsNextId()
        {
            // Arrange
            int expectedId = 5;
            _mockDUsuario.Setup(x => x.generaCodigo()).Returns(expectedId);

            // Act
            var result = _blUsuario.generarCodigo();

            // Assert
            Assert.AreEqual(expectedId, result);
            _mockDUsuario.Verify(x => x.generaCodigo(), Times.Once);
        }

        [Test]
        public void NuevoRegistro_ValidUser_CallsDataLayer()
        {
            // Arrange
            string accion = "INSERTAR";
            _mockDUsuario.Setup(x => x.nuevoRegistro(It.IsAny<E_Usuario>(), It.IsAny<string>()));

            // Act
            _blUsuario.nuevoRegistro(_usuarioTest, accion);

            // Assert
            _mockDUsuario.Verify(x => x.nuevoRegistro(_usuarioTest, accion), Times.Once);
        }

        [Test]
        public void ListarUsuarios_ReturnsDataTable()
        {
            // Arrange
            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add("IdUsuario", typeof(int));
            expectedDataTable.Columns.Add("Usuario", typeof(string));
            expectedDataTable.Rows.Add(1, "admin");
            expectedDataTable.Rows.Add(2, "user1");

            _mockDUsuario.Setup(x => x.listarUsuarios()).Returns(expectedDataTable);

            // Act
            var result = _blUsuario.listarUsuarios();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Rows.Count);
            _mockDUsuario.Verify(x => x.listarUsuarios(), Times.Once);
        }

        [Test]
        public void ActualizarRegistro_ValidUser_CallsDataLayer()
        {
            // Arrange
            string accion = "ACTUALIZAR";
            _mockDUsuario.Setup(x => x.actualizarRegistro(It.IsAny<E_Usuario>(), It.IsAny<string>()));

            // Act
            _blUsuario.actualizarRegistro(_usuarioTest, accion);

            // Assert
            _mockDUsuario.Verify(x => x.actualizarRegistro(_usuarioTest, accion), Times.Once);
        }

        [Test]
        public void EliminarRegistro_ValidUser_CallsDataLayer()
        {
            // Arrange
            string accion = "ELIMINAR";
            _mockDUsuario.Setup(x => x.eliminarRegistro(It.IsAny<E_Usuario>(), It.IsAny<string>()));

            // Act
            _blUsuario.eliminarRegistro(_usuarioTest, accion);

            // Assert
            _mockDUsuario.Verify(x => x.eliminarRegistro(_usuarioTest, accion), Times.Once);
        }

        [Test]
        public void Login_WithException_ThrowsException()
        {
            // Arrange
            _mockDUsuario.Setup(x => x.Login(It.IsAny<E_Usuario>()))
                        .Throws(new System.Exception("Error de base de datos"));

            // Act & Assert
            var ex = Assert.Throws<System.Exception>(() => _blUsuario.Login(_usuarioTest));
            Assert.AreEqual("Error de base de datos", ex.Message);
        }

        [Test]
        public void GenerarCodigo_WithException_ThrowsException()
        {
            // Arrange
            _mockDUsuario.Setup(x => x.generaCodigo())
                        .Throws(new System.Exception("Error de conexión"));

            // Act & Assert
            var ex = Assert.Throws<System.Exception>(() => _blUsuario.generarCodigo());
            Assert.AreEqual("Error de conexión", ex.Message);
        }

        [TearDown]
        public void TearDown()
        {
            _mockDUsuario = null;
            _blUsuario = null;
            _usuarioTest = null;
        }
    }
}