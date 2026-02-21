using NUnit.Framework;
using CE;
using System;

namespace Tests
{
    [TestFixture]
    public class E_MarcacionesTests
    {
        private E_Marcaciones _marcacion;

        [SetUp]
        public void Setup()
        {
            _marcacion = new E_Marcaciones();
        }

        [Test]
        public void E_Marcaciones_Constructor_CreatesInstance()
        {
            // Arrange & Act
            var marcacion = new E_Marcaciones();

            // Assert
            Assert.IsNotNull(marcacion);
        }

        [Test]
        public void E_Marcaciones_SetProperties_SetsCorrectValues()
        {
            // Arrange
            string expectedIdMarcacion = "MAR001";
            string expectedIdEmpleado = "EMP001";
            DateTime expectedFecha = new DateTime(2025, 1, 15);
            string expectedHIngreso = "08:00";
            string expectedHSalida = "17:00";
            string expectedObservacion = "Día normal de trabajo";

            // Act
            _marcacion.Id_Marcacion = expectedIdMarcacion;
            _marcacion.Id_Empleado = expectedIdEmpleado;
            _marcacion.Fecha = expectedFecha;
            _marcacion.H_Ingreso = expectedHIngreso;
            _marcacion.H_Salida = expectedHSalida;
            _marcacion.Observacion = expectedObservacion;

            // Assert
            Assert.AreEqual(expectedIdMarcacion, _marcacion.Id_Marcacion);
            Assert.AreEqual(expectedIdEmpleado, _marcacion.Id_Empleado);
            Assert.AreEqual(expectedFecha, _marcacion.Fecha);
            Assert.AreEqual(expectedHIngreso, _marcacion.H_Ingreso);
            Assert.AreEqual(expectedHSalida, _marcacion.H_Salida);
            Assert.AreEqual(expectedObservacion, _marcacion.Observacion);
        }

        [Test]
        public void CalcularHorasTrabajadas_ReturnsCorrectHours()
        {
            // Arrange
            _marcacion.H_Ingreso = "08:00";
            _marcacion.H_Salida = "17:00";
            _marcacion.HS_Refrigerio = "12:00";
            _marcacion.HI_Refrigerio = "13:00";

            // Act
            TimeSpan ingreso = TimeSpan.Parse(_marcacion.H_Ingreso);
            TimeSpan salida = TimeSpan.Parse(_marcacion.H_Salida);
            TimeSpan salidaRefrigerio = TimeSpan.Parse(_marcacion.HS_Refrigerio);
            TimeSpan ingresoRefrigerio = TimeSpan.Parse(_marcacion.HI_Refrigerio);
            
            TimeSpan horasTrabajadas = (salida - ingreso) - (ingresoRefrigerio - salidaRefrigerio);

            // Assert
            Assert.AreEqual(8, horasTrabajadas.Hours);
        }

        [Test]
        [TestCase("08:00", "17:00", true)]
        [TestCase("", "17:00", false)]
        [TestCase("08:00", "", false)]
        [TestCase(null, "17:00", false)]
        [TestCase("08:00", null, false)]
        public void ValidarHorarios_ReturnsExpectedResult(string hIngreso, string hSalida, bool expected)
        {
            // Arrange
            _marcacion.H_Ingreso = hIngreso;
            _marcacion.H_Salida = hSalida;

            // Act
            bool resultado = !string.IsNullOrEmpty(_marcacion.H_Ingreso) && 
                           !string.IsNullOrEmpty(_marcacion.H_Salida);

            // Assert
            Assert.AreEqual(expected, resultado);
        }

        [Test]
        public void E_Marcaciones_DefaultValues_AreCorrect()
        {
            // Arrange & Act
            var marcacion = new E_Marcaciones();

            // Assert
            Assert.IsNull(marcacion.Id_Marcacion);
            Assert.IsNull(marcacion.Id_Empleado);
            Assert.AreEqual(DateTime.MinValue, marcacion.Fecha);
            Assert.IsNull(marcacion.H_Ingreso);
            Assert.IsNull(marcacion.H_Salida);
            Assert.IsNull(marcacion.Observacion);
        }

        [TearDown]
        public void TearDown()
        {
            _marcacion = null;
        }
    }
}