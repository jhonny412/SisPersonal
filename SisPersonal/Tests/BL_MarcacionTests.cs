using NUnit.Framework;
using BL;
using CAD;
using CE;
using Moq;
using System;
using System.Data;

namespace Tests
{
    [TestFixture]
    public class BL_MarcacionTests
    {
        private Mock<ID_Marcaciones> _mockDMarcaciones;
        private BL_Marcacion _blMarcacion;
        private E_Marcaciones _marcacionTest;
        private E_Empleado _empleadoTest;

        [SetUp]
        public void Setup()
        {
            _mockDMarcaciones = new Mock<ID_Marcaciones>();
            _blMarcacion = new BL_Marcacion(_mockDMarcaciones.Object);

            _marcacionTest = new E_Marcaciones
            {
                Id_Marcacion = "MAR001",
                Id_Empleado = "EMP001",
                Fecha = DateTime.Now,
                H_Ingreso = "08:00",
                H_Salida = "17:00",
                HS_Refrigerio = "12:00",
                HI_Refrigerio = "13:00",
                TH_Refrigerio = "01:00",
                TH_Trabajadas = "08:00",
                Observacion = "Jornada normal"
            };

            _empleadoTest = new E_Empleado
            {
                ID_Empleado = "EMP001",
                DNI = "12345678",
                Fecha = DateTime.Now
            };
        }

        [Test]
        public void ListarMarcaciones_ReturnsDataTable()
        {
            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add("Id_Marcacion", typeof(string));
            expectedDataTable.Columns.Add("Id_Empleado", typeof(string));
            expectedDataTable.Columns.Add("Fecha", typeof(DateTime));
            expectedDataTable.Rows.Add("MAR001", "EMP001", DateTime.Now);

            _mockDMarcaciones.Setup(x => x.ListarMarcaciones())
                            .Returns(expectedDataTable);

            var result = _blMarcacion.ListarMarcaciones();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Rows.Count);
            Assert.AreEqual("MAR001", result.Rows[0]["Id_Marcacion"]);
            _mockDMarcaciones.Verify(x => x.ListarMarcaciones(), Times.Once);
        }

        [Test]
        public void ListarMarcaciones_EmptyTable_ReturnsEmptyDataTable()
        {
            var emptyDataTable = new DataTable();
            _mockDMarcaciones.Setup(x => x.ListarMarcaciones())
                            .Returns(emptyDataTable);

            var result = _blMarcacion.ListarMarcaciones();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
            _mockDMarcaciones.Verify(x => x.ListarMarcaciones(), Times.Once);
        }

        [Test]
        public void InsertarMarcacion_ValidMarcacion_ReturnsTrue()
        {
            _mockDMarcaciones.Setup(x => x.InsertarMarcacion(It.IsAny<E_Marcaciones>()))
                            .Returns(true);

            var result = _blMarcacion.InsertarMarcacion(_marcacionTest);

            Assert.IsTrue(result);
            _mockDMarcaciones.Verify(x => x.InsertarMarcacion(It.IsAny<E_Marcaciones>()), Times.Once);
        }

        [Test]
        public void InsertarMarcacion_FailedInsert_ReturnsFalse()
        {
            _mockDMarcaciones.Setup(x => x.InsertarMarcacion(It.IsAny<E_Marcaciones>()))
                            .Returns(false);

            var result = _blMarcacion.InsertarMarcacion(_marcacionTest);

            Assert.IsFalse(result);
            _mockDMarcaciones.Verify(x => x.InsertarMarcacion(It.IsAny<E_Marcaciones>()), Times.Once);
        }

        [Test]
        public void InsertarMarcacion_VerifyCorrectParameterPassed()
        {
            _mockDMarcaciones.Setup(x => x.InsertarMarcacion(It.IsAny<E_Marcaciones>()))
                            .Returns(true);

            _blMarcacion.InsertarMarcacion(_marcacionTest);

            _mockDMarcaciones.Verify(x => x.InsertarMarcacion(
                It.Is<E_Marcaciones>(m => m.Id_Empleado == "EMP001" && m.H_Ingreso == "08:00")), Times.Once);
        }

        [Test]
        public void ConsultarMarcacion_ValidEmpleado_ReturnsDataTable()
        {
            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add("Id_Marcacion", typeof(string));
            expectedDataTable.Columns.Add("Fecha", typeof(DateTime));
            expectedDataTable.Columns.Add("H_Ingreso", typeof(string));
            expectedDataTable.Rows.Add("MAR001", DateTime.Now, "08:00");

            _mockDMarcaciones.Setup(x => x.ConsultarMarcacion(It.IsAny<E_Empleado>()))
                            .Returns(expectedDataTable);

            var result = _blMarcacion.ConsultarMarcacion(_empleadoTest);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Rows.Count);
            Assert.AreEqual("MAR001", result.Rows[0]["Id_Marcacion"]);
            _mockDMarcaciones.Verify(x => x.ConsultarMarcacion(It.IsAny<E_Empleado>()), Times.Once);
        }

        [Test]
        public void ConsultarMarcacion_NoRecords_ReturnsEmptyDataTable()
        {
            var emptyDataTable = new DataTable();
            _mockDMarcaciones.Setup(x => x.ConsultarMarcacion(It.IsAny<E_Empleado>()))
                            .Returns(emptyDataTable);

            var result = _blMarcacion.ConsultarMarcacion(_empleadoTest);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
            _mockDMarcaciones.Verify(x => x.ConsultarMarcacion(It.IsAny<E_Empleado>()), Times.Once);
        }

        [Test]
        public void ListarEmpleados_ReturnsDataTable()
        {
            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add("ID_Empleado", typeof(string));
            expectedDataTable.Columns.Add("Nombres", typeof(string));
            expectedDataTable.Columns.Add("DNI", typeof(string));
            expectedDataTable.Rows.Add("EMP001", "Juan García", "12345678");
            expectedDataTable.Rows.Add("EMP002", "María López", "87654321");

            _mockDMarcaciones.Setup(x => x.ListarEmpleados())
                            .Returns(expectedDataTable);

            var result = _blMarcacion.ListarEmpleados();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Rows.Count);
            Assert.AreEqual("EMP001", result.Rows[0]["ID_Empleado"]);
            _mockDMarcaciones.Verify(x => x.ListarEmpleados(), Times.Once);
        }

        [Test]
        public void ListarEmpleados_EmptyTable_ReturnsEmptyDataTable()
        {
            var emptyDataTable = new DataTable();
            _mockDMarcaciones.Setup(x => x.ListarEmpleados())
                            .Returns(emptyDataTable);

            var result = _blMarcacion.ListarEmpleados();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
            _mockDMarcaciones.Verify(x => x.ListarEmpleados(), Times.Once);
        }

        [Test]
        public void MarcacionXFecha_ValidParameters_ReturnsDataTable()
        {
            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add("Id_Marcacion", typeof(string));
            expectedDataTable.Columns.Add("Fecha", typeof(DateTime));
            expectedDataTable.Rows.Add("MAR001", DateTime.Now);

            string idEmpleado = "EMP001";
            DateTime desde = DateTime.Now.AddDays(-7);
            DateTime hasta = DateTime.Now;

            _mockDMarcaciones.Setup(x => x.MarcacionXFecha(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                            .Returns(expectedDataTable);

            var result = _blMarcacion.MarcacionXFecha(idEmpleado, desde, hasta);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Rows.Count);
            _mockDMarcaciones.Verify(x => x.MarcacionXFecha(idEmpleado, desde, hasta), Times.Once);
        }

        [Test]
        public void MarcacionXFecha_NoRecords_ReturnsEmptyDataTable()
        {
            var emptyDataTable = new DataTable();

            _mockDMarcaciones.Setup(x => x.MarcacionXFecha(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                            .Returns(emptyDataTable);

            var result = _blMarcacion.MarcacionXFecha("EMP999", DateTime.Now, DateTime.Now);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
            _mockDMarcaciones.Verify(x => x.MarcacionXFecha(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
        }

        [Test]
        public void MarcacionXFecha_VerifyCorrectParametersPassed()
        {
            var dataTable = new DataTable();
            string idEmpleado = "EMP001";
            DateTime desde = new DateTime(2025, 1, 1);
            DateTime hasta = new DateTime(2025, 1, 31);

            _mockDMarcaciones.Setup(x => x.MarcacionXFecha(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                            .Returns(dataTable);

            _blMarcacion.MarcacionXFecha(idEmpleado, desde, hasta);

            _mockDMarcaciones.Verify(x => x.MarcacionXFecha(
                It.Is<string>(id => id == "EMP001"),
                It.Is<DateTime>(d => d == new DateTime(2025, 1, 1)),
                It.Is<DateTime>(h => h == new DateTime(2025, 1, 31))), Times.Once);
        }

        [Test]
        public void ListarMarcaciones_WithException_ThrowsException()
        {
            _mockDMarcaciones.Setup(x => x.ListarMarcaciones())
                            .Throws(new Exception("Error de base de datos"));

            var ex = Assert.Throws<Exception>(() => _blMarcacion.ListarMarcaciones());
            Assert.AreEqual("Error de base de datos", ex.Message);
        }

        [Test]
        public void InsertarMarcacion_WithException_ThrowsException()
        {
            _mockDMarcaciones.Setup(x => x.InsertarMarcacion(It.IsAny<E_Marcaciones>()))
                            .Throws(new Exception("Error al insertar marcación"));

            var ex = Assert.Throws<Exception>(() => _blMarcacion.InsertarMarcacion(_marcacionTest));
            Assert.AreEqual("Error al insertar marcación", ex.Message);
        }

        [Test]
        public void ConsultarMarcacion_WithException_ThrowsException()
        {
            _mockDMarcaciones.Setup(x => x.ConsultarMarcacion(It.IsAny<E_Empleado>()))
                            .Throws(new Exception("Error al consultar marcación"));

            var ex = Assert.Throws<Exception>(() => _blMarcacion.ConsultarMarcacion(_empleadoTest));
            Assert.AreEqual("Error al consultar marcación", ex.Message);
        }

        [Test]
        public void ListarEmpleados_WithException_ThrowsException()
        {
            _mockDMarcaciones.Setup(x => x.ListarEmpleados())
                            .Throws(new Exception("Error de conexión"));

            var ex = Assert.Throws<Exception>(() => _blMarcacion.ListarEmpleados());
            Assert.AreEqual("Error de conexión", ex.Message);
        }

        [Test]
        public void MarcacionXFecha_WithException_ThrowsException()
        {
            _mockDMarcaciones.Setup(x => x.MarcacionXFecha(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                            .Throws(new Exception("Error al filtrar por fecha"));

            var ex = Assert.Throws<Exception>(() => _blMarcacion.MarcacionXFecha("EMP001", DateTime.Now, DateTime.Now));
            Assert.AreEqual("Error al filtrar por fecha", ex.Message);
        }

        [Test]
        public void InsertarMarcacion_CompleteMarcacion_AllPropertiesPassed()
        {
            var marcacionCompleta = new E_Marcaciones
            {
                Id_Empleado = "EMP001",
                Fecha = new DateTime(2025, 1, 15),
                H_Ingreso = "08:30",
                H_Salida = "18:00",
                HS_Refrigerio = "12:00",
                HI_Refrigerio = "13:00",
                TH_Refrigerio = "01:00",
                TH_Trabajadas = "08:30",
                Observacion = "Jornada completa"
            };

            _mockDMarcaciones.Setup(x => x.InsertarMarcacion(It.IsAny<E_Marcaciones>()))
                            .Returns(true);

            var result = _blMarcacion.InsertarMarcacion(marcacionCompleta);

            Assert.IsTrue(result);
            _mockDMarcaciones.Verify(x => x.InsertarMarcacion(
                It.Is<E_Marcaciones>(m =>
                    m.Id_Empleado == "EMP001" &&
                    m.H_Ingreso == "08:30" &&
                    m.H_Salida == "18:00" &&
                    m.Observacion == "Jornada completa")), Times.Once);
        }

        [TearDown]
        public void TearDown()
        {
            _mockDMarcaciones = null;
            _blMarcacion = null;
            _marcacionTest = null;
            _empleadoTest = null;
        }
    }
}
