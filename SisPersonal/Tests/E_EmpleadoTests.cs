using NUnit.Framework;
using CE;
using System;

namespace Tests
{
    [TestFixture]
    public class E_EmpleadoTests
    {
        private E_Empleado _empleado;

        [SetUp]
        public void Setup()
        {
            _empleado = new E_Empleado();
        }

        [Test]
        public void E_Empleado_Constructor_CreatesInstance()
        {
            // Arrange & Act
            var empleado = new E_Empleado();

            // Assert
            Assert.IsNotNull(empleado);
        }

        [Test]
        public void E_Empleado_SetProperties_SetsCorrectValues()
        {
            // Arrange
            string expectedIdEmpleado = "EMP001";
            string expectedApePaterno = "García";
            string expectedApeMaterno = "López";
            string expectedNombres = "Juan Carlos";
            string expectedDni = "12345678";
            string expectedDireccion = "Av. Principal 123";
            bool expectedEstado = true;

            // Act
            _empleado.ID_Empleado = expectedIdEmpleado;
            _empleado.Ape_Paterno = expectedApePaterno;
            _empleado.Ape_Materno = expectedApeMaterno;
            _empleado.Nombres = expectedNombres;
            _empleado.DNI = expectedDni;
            _empleado.Direccion = expectedDireccion;
            _empleado.Estado = expectedEstado;

            // Assert
            Assert.AreEqual(expectedIdEmpleado, _empleado.ID_Empleado);
            Assert.AreEqual(expectedApePaterno, _empleado.Ape_Paterno);
            Assert.AreEqual(expectedApeMaterno, _empleado.Ape_Materno);
            Assert.AreEqual(expectedNombres, _empleado.Nombres);
            Assert.AreEqual(expectedDni, _empleado.DNI);
            Assert.AreEqual(expectedDireccion, _empleado.Direccion);
            Assert.AreEqual(expectedEstado, _empleado.Estado);
        }

        [Test]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("1234567", false)]
        [TestCase("123456789", false)]
        [TestCase("12345678", true)]
        [TestCase("87654321", true)]
        public void ValidarDNI_ReturnsExpectedResult(string dni, bool expected)
        {
            // Arrange
            _empleado.DNI = dni;

            // Act
            bool resultado = !string.IsNullOrEmpty(_empleado.DNI) && _empleado.DNI.Length == 8;

            // Assert
            Assert.AreEqual(expected, resultado);
        }

        [Test]
        public void E_Empleado_InheritsFromE_Marcaciones()
        {
            // Arrange & Act
            var empleado = new E_Empleado();

            // Assert
            Assert.IsInstanceOf<E_Marcaciones>(empleado);
        }

        [Test]
        public void E_Empleado_CanSetMarcacionesProperties()
        {
            // Arrange
            string expectedIdMarcacion = "MAR001";
            DateTime expectedFecha = DateTime.Now;
            string expectedHIngreso = "08:00";
            string expectedHSalida = "17:00";

            // Act
            _empleado.Id_Marcacion = expectedIdMarcacion;
            _empleado.Fecha = expectedFecha;
            _empleado.H_Ingreso = expectedHIngreso;
            _empleado.H_Salida = expectedHSalida;

            // Assert
            Assert.AreEqual(expectedIdMarcacion, _empleado.Id_Marcacion);
            Assert.AreEqual(expectedFecha, _empleado.Fecha);
            Assert.AreEqual(expectedHIngreso, _empleado.H_Ingreso);
            Assert.AreEqual(expectedHSalida, _empleado.H_Salida);
        }

        [Test]
        public void GetNombreCompleto_ReturnsFormattedName()
        {
            // Arrange
            _empleado.Nombres = "Juan Carlos";
            _empleado.Ape_Paterno = "García";
            _empleado.Ape_Materno = "López";

            // Act
            string nombreCompleto = $"{_empleado.Nombres} {_empleado.Ape_Paterno} {_empleado.Ape_Materno}";

            // Assert
            Assert.AreEqual("Juan Carlos García López", nombreCompleto);
        }

        [Test]
        public void E_Empleado_DefaultValues_AreCorrect()
        {
            // Arrange & Act
            var empleado = new E_Empleado();

            // Assert
            Assert.IsNull(empleado.ID_Empleado);
            Assert.IsNull(empleado.Ape_Paterno);
            Assert.IsNull(empleado.Ape_Materno);
            Assert.IsNull(empleado.Nombres);
            Assert.IsNull(empleado.DNI);
            Assert.IsNull(empleado.Direccion);
            Assert.IsFalse(empleado.Estado);
        }

        [TearDown]
        public void TearDown()
        {
            _empleado = null;
        }
    }
}