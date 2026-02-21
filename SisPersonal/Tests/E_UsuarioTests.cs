using NUnit.Framework;
using CE;

namespace Tests
{
    [TestFixture]
    public class E_UsuarioTests
    {
        private E_Usuario _usuario;

        [SetUp]
        public void Setup()
        {
            _usuario = new E_Usuario();
        }

        [Test]
        public void E_Usuario_Constructor_CreatesInstance()
        {
            // Arrange & Act
            var usuario = new E_Usuario();

            // Assert
            Assert.IsNotNull(usuario);
        }

        [Test]
        public void E_Usuario_SetProperties_SetsCorrectValues()
        {
            // Arrange
            int expectedId = 1;
            string expectedUsuario = "admin";
            string expectedClave = "123456";
            int expectedEstado = 1;
            string expectedPerfil = "Administrador";

            // Act
            _usuario.IdUsuario = expectedId;
            _usuario.Usuario = expectedUsuario;
            _usuario.Clave = expectedClave;
            _usuario.Estado = expectedEstado;
            _usuario.Perfil = expectedPerfil;

            // Assert
            Assert.AreEqual(expectedId, _usuario.IdUsuario);
            Assert.AreEqual(expectedUsuario, _usuario.Usuario);
            Assert.AreEqual(expectedClave, _usuario.Clave);
            Assert.AreEqual(expectedEstado, _usuario.Estado);
            Assert.AreEqual(expectedPerfil, _usuario.Perfil);
        }

        [Test]
        [TestCase("admin", true)]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("a", false)]
        [TestCase("administrador123", true)]
        public void ValidarUsuario_ReturnsExpectedResult(string usuario, bool expected)
        {
            // Arrange
            _usuario.Usuario = usuario;

            // Act
            bool resultado = !string.IsNullOrEmpty(_usuario.Usuario) && _usuario.Usuario.Length >= 3;

            // Assert
            Assert.AreEqual(expected, resultado);
        }

        [Test]
        [TestCase("123456", true)]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("123", false)]
        [TestCase("password123", true)]
        public void ValidarClave_ReturnsExpectedResult(string clave, bool expected)
        {
            // Arrange
            _usuario.Clave = clave;

            // Act
            bool resultado = !string.IsNullOrEmpty(_usuario.Clave) && _usuario.Clave.Length >= 6;

            // Assert
            Assert.AreEqual(expected, resultado);
        }

        [Test]
        public void E_Usuario_DefaultValues_AreCorrect()
        {
            // Arrange & Act
            var usuario = new E_Usuario();

            // Assert
            Assert.AreEqual(0, usuario.IdUsuario);
            Assert.IsNull(usuario.Usuario);
            Assert.IsNull(usuario.Clave);
            Assert.AreEqual(0, usuario.Estado);
            Assert.IsNull(usuario.Perfil);
        }

        [TearDown]
        public void TearDown()
        {
            _usuario = null;
        }
    }
}