using NUnit.Framework;
using BL;
using CAD;
using CE;
using Moq;
using System.Data;

namespace Tests
{
    [TestFixture]
    public class BL_EmpleadoTests
    {
        private Mock<ID_Empleado> _mockDEmpleado;
        private BL_Empleado _blEmpleado;
        private E_Empleado _empleadoTest;

        [SetUp]
        public void Setup()
        {
            _mockDEmpleado = new Mock<ID_Empleado>();
            _blEmpleado = new BL_Empleado(_mockDEmpleado.Object);
            
            _empleadoTest = new E_Empleado
            {
                ID_Empleado = "EMP001",
                Ape_Paterno = "García",
                Ape_Materno = "López",
                Nombres = "Juan Carlos",
                DNI = "12345678",
                Direccion = "Av. Principal 123",
                Estado = true
            };
        }

        [Test]
        public void BuscarPersona_ValidDNI_ReturnsDataTable()
        {
            // Arrange
            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add("ID_Empleado", typeof(string));
            expectedDataTable.Columns.Add("Nombres", typeof(string));
            expectedDataTable.Columns.Add("Ape_Paterno", typeof(string));
            expectedDataTable.Columns.Add("DNI", typeof(string));
            expectedDataTable.Rows.Add("EMP001", "Juan Carlos", "García", "12345678");

            _mockDEmpleado.Setup(x => x.buscarPersona(It.IsAny<E_Empleado>()))
                         .Returns(expectedDataTable);

            // Act
            var result = _blEmpleado.buscarPersona(_empleadoTest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Rows.Count);
            Assert.AreEqual("12345678", result.Rows[0]["DNI"]);
            Assert.AreEqual("Juan Carlos", result.Rows[0]["Nombres"]);
            _mockDEmpleado.Verify(x => x.buscarPersona(It.IsAny<E_Empleado>()), Times.Once);
        }

        [Test]
        public void BuscarPersona_InvalidDNI_ReturnsEmptyDataTable()
        {
            // Arrange
            var emptyDataTable = new DataTable();
            _mockDEmpleado.Setup(x => x.buscarPersona(It.IsAny<E_Empleado>()))
                         .Returns(emptyDataTable);

            var empleadoInvalido = new E_Empleado { DNI = "99999999" };

            // Act
            var result = _blEmpleado.buscarPersona(empleadoInvalido);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
            _mockDEmpleado.Verify(x => x.buscarPersona(It.IsAny<E_Empleado>()), Times.Once);
        }

        [Test]
        public void GetEmpleado_ReturnsAllEmployees()
        {
            // Arrange
            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add("Ape_Paterno", typeof(string));
            expectedDataTable.Columns.Add("Nombres", typeof(string));
            expectedDataTable.Columns.Add("DNI", typeof(string));
            expectedDataTable.Rows.Add("García", "Juan Carlos", "12345678");
            expectedDataTable.Rows.Add("Pérez", "María Elena", "87654321");

            _mockDEmpleado.Setup(x => x.GetEmpleado()).Returns(expectedDataTable);

            // Act
            var result = _blEmpleado.GetEmpleado();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Rows.Count);
            Assert.AreEqual("García", result.Rows[0]["Ape_Paterno"]);
            Assert.AreEqual("Pérez", result.Rows[1]["Ape_Paterno"]);
            _mockDEmpleado.Verify(x => x.GetEmpleado(), Times.Once);
        }

        [Test]
        public void BuscarPersona_WithException_ThrowsException()
        {
            // Arrange
            _mockDEmpleado.Setup(x => x.buscarPersona(It.IsAny<E_Empleado>()))
                         .Throws(new System.Exception("Error de base de datos"));

            // Act & Assert
            var ex = Assert.Throws<System.Exception>(() => _blEmpleado.buscarPersona(_empleadoTest));
            Assert.AreEqual("Error de base de datos", ex.Message);
        }

        [Test]
        public void GetEmpleado_WithException_ThrowsException()
        {
            // Arrange
            _mockDEmpleado.Setup(x => x.GetEmpleado())
                         .Throws(new System.Exception("Error de conexión"));

            // Act & Assert
            var ex = Assert.Throws<System.Exception>(() => _blEmpleado.GetEmpleado());
            Assert.AreEqual("Error de conexión", ex.Message);
        }

        [Test]
        public void BuscarPersona_VerifyCorrectParameterPassed()
        {
            // Arrange
            var dataTable = new DataTable();
            _mockDEmpleado.Setup(x => x.buscarPersona(It.IsAny<E_Empleado>()))
                         .Returns(dataTable);

            // Act
            _blEmpleado.buscarPersona(_empleadoTest);

            // Assert
            _mockDEmpleado.Verify(x => x.buscarPersona(
                It.Is<E_Empleado>(e => e.DNI == "12345678")), Times.Once);
        }

        [Test]
        public void BuscarPersona_MultipleCallsWithDifferentDNI_VerifiesEachCall()
        {
            // Arrange
            var dataTable = new DataTable();
            _mockDEmpleado.Setup(x => x.buscarPersona(It.IsAny<E_Empleado>()))
                         .Returns(dataTable);

            var empleado1 = new E_Empleado { DNI = "11111111" };
            var empleado2 = new E_Empleado { DNI = "22222222" };

            // Act
            _blEmpleado.buscarPersona(empleado1);
            _blEmpleado.buscarPersona(empleado2);

            // Assert
            _mockDEmpleado.Verify(x => x.buscarPersona(It.Is<E_Empleado>(e => e.DNI == "11111111")), Times.Once);
            _mockDEmpleado.Verify(x => x.buscarPersona(It.Is<E_Empleado>(e => e.DNI == "22222222")), Times.Once);
            _mockDEmpleado.Verify(x => x.buscarPersona(It.IsAny<E_Empleado>()), Times.Exactly(2));
        }

        [TearDown]
        public void TearDown()
        {
            _mockDEmpleado = null;
            _blEmpleado = null;
            _empleadoTest = null;
        }
    }
}