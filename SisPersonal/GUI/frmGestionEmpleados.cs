using BL;
using CE;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data;
using Serilog;
using Excel = Microsoft.Office.Interop.Excel;

namespace GUI
{
    public partial class frmGestionEmpleados : Form
    {
        BL_Empleado objEmp = new BL_Empleado();
        E_Empleado objEEmp = new E_Empleado();
        string mode = "Insert";

        public frmGestionEmpleados()
        {
            InitializeComponent();
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Imagen (*.jpg, *.png)|*.jpg;*.png|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Cargar imagen sin bloquear el archivo original
                    using (var tempImg = Image.FromFile(ofd.FileName))
                    {
                        pbxFoto.Image = new Bitmap(tempImg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
            }
        }

        private void frmGestionEmpleados_Load(object sender, EventArgs e)
        {
            ApplyModernStyles();
            listar();
            habilitarCampos(false);

            // Establecer dimensiones fijas
            this.Size = new Size(1037, 630);
            this.MinimumSize = new Size(1037, 630);
            this.MaximumSize = new Size(1037, 630);
        }

        private void ApplyModernStyles()
        {
            UIStyles.ApplyModernStylesToForm(this);
        }

        private void listar()
        {
            dgvEmpleados.DataSource = objEmp.GetEmpleado();
            if (dgvEmpleados.Columns.Contains("Foto"))
            {
                dgvEmpleados.Columns["Foto"].Visible = false;
            }
            if (dgvEmpleados.Columns.Contains("SBasicoHora"))
            {
                dgvEmpleados.Columns["SBasicoHora"].DefaultCellStyle.Format = "N2";
            }
            if (dgvEmpleados.Columns.Contains("SHorasExtraHora"))
            {
                dgvEmpleados.Columns["SHorasExtraHora"].DefaultCellStyle.Format = "N2";
            }
        }

        private void habilitarCampos(bool v)
        {
            groupBox1.Enabled = v;
            btnGrabar.Enabled = v;
        }

        private void limpiarCampos()
        {
            txtId.Clear();
            txtNombres.Clear();
            txtApepat.Clear();
            txtApemat.Clear();
            txtDNI.Clear();
            txtDireccion.Clear();
            txtBasico.Clear();
            txtHE.Clear();
            chkActivo.Checked = true;
            chkInactivo.Checked = false;
            pbxFoto.Image = null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            mode = "Insert";
            limpiarCampos();
            habilitarCampos(true);
            txtNombres.Focus();
            // Generar un ID temporal para ejemplo o dejar que el SP lo maneje si es necesario
            txtId.Text = "E" + DateTime.Now.ToString("mmssfff");
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombres.Text) || string.IsNullOrEmpty(txtDNI.Text))
                {
                    MessageBox.Show("Nombres y DNI son obligatorios.");
                    return;
                }

                objEEmp.ID_Empleado = txtId.Text;
                objEEmp.Nombres = txtNombres.Text;
                objEEmp.Ape_Paterno = txtApepat.Text;
                objEEmp.Ape_Materno = txtApemat.Text;
                objEEmp.DNI = txtDNI.Text;
                objEEmp.Direccion = txtDireccion.Text;
                objEEmp.Estado = chkActivo.Checked;
                objEEmp.SBasicoHora = string.IsNullOrEmpty(txtBasico.Text) ? 0 : Convert.ToDecimal(txtBasico.Text);
                objEEmp.SHorasExtraHora = string.IsNullOrEmpty(txtHE.Text) ? 0 : Convert.ToDecimal(txtHE.Text);

                // Convertir imagen a byte[]
                if (pbxFoto.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Crear una copia de la imagen para evitar el "Error genérico en GDI+"
                        // que ocurre si la imagen original está vinculada a un stream cerrado.
                        using (Bitmap tempBmp = new Bitmap(pbxFoto.Image))
                        {
                            tempBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        objEEmp.Foto = ms.ToArray();
                    }
                }
                else
                {
                    objEEmp.Foto = null;
                }

                int res = 0;
                if (mode == "Insert")
                {
                    res = objEmp.nuevoRegistro(objEEmp);
                    if (res > 0) MessageBox.Show("Empleado registrado correctamente.");
                }
                else
                {
                    res = objEmp.actualizarRegistro(objEEmp);
                    if (res > 0) MessageBox.Show("Empleado actualizado correctamente.");
                }

                if (res > 0)
                {
                    listar();
                    limpiarCampos();
                    habilitarCampos(false);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al grabar empleado. Modo: {Mode}, ID: {Id}", mode, txtId.Text);
                MessageBox.Show("Error al grabar: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                mode = "Update";
                habilitarCampos(true);
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                string id = dgvEmpleados.CurrentRow.Cells["Id_Empleado"].Value.ToString();
                if (MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (objEmp.eliminarRegistro(id) > 0)
                    {
                        MessageBox.Show("Registro eliminado.");
                        listar();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            habilitarCampos(false);
            mode = "Insert";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string criterio = textBox1.Text.Trim();
            try
            {
                Log.Information("Iniciando búsqueda de empleados con criterio: {Criterio}", criterio);

                E_Empleado searchParam = new E_Empleado { Nombres = criterio };
                DataTable dt = objEmp.buscarPersona(searchParam);
                dgvEmpleados.DataSource = dt;

                int count = dt.Rows.Count;
                if (count == 0 && !string.IsNullOrEmpty(criterio))
                {
                    Log.Warning("Búsqueda sin resultados para: {Criterio}", criterio);
                    MessageBox.Show("No se encontraron resultados para: " + criterio, "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Log.Information("Búsqueda finalizada. Se encontraron {Count} registros para el criterio: {Criterio}", count, criterio);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error crítico durante la búsqueda de empleados. Criterio: {Criterio}", criterio);
                MessageBox.Show("Error en la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                txtId.Text = dgvEmpleados.CurrentRow.Cells["Id_Empleado"].Value.ToString();
                txtNombres.Text = dgvEmpleados.CurrentRow.Cells["Nombres"].Value.ToString();
                txtApepat.Text = dgvEmpleados.CurrentRow.Cells["Ape_Paterno"].Value.ToString();
                txtApemat.Text = dgvEmpleados.CurrentRow.Cells["Ape_Materno"].Value.ToString();
                txtDNI.Text = dgvEmpleados.CurrentRow.Cells["DNI"].Value.ToString();
                txtDireccion.Text = dgvEmpleados.CurrentRow.Cells["Direccion"].Value.ToString();
                txtBasico.Text = Convert.ToDecimal(dgvEmpleados.CurrentRow.Cells["SBasicoHora"].Value).ToString("N2");
                txtHE.Text = Convert.ToDecimal(dgvEmpleados.CurrentRow.Cells["SHorasExtraHora"].Value).ToString("N2");

                bool estado = Convert.ToBoolean(dgvEmpleados.CurrentRow.Cells["Estado"].Value);
                chkActivo.Checked = estado;
                chkInactivo.Checked = !estado;

                // Cargar Foto
                if (dgvEmpleados.CurrentRow.Cells["Foto"].Value != DBNull.Value)
                {
                    byte[] img = (byte[])dgvEmpleados.CurrentRow.Cells["Foto"].Value;
                    using (MemoryStream ms = new MemoryStream(img))
                    {
                        pbxFoto.Image = new Bitmap(ms);
                    }
                }
                else
                {
                    pbxFoto.Image = null;
                }
            }
        }
        private void ExportToExcel(DataGridView dgv, string filePath)
        {
            Excel.Application excelApp = null;
            Excel.Workbooks workbooks = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbooks = excelApp.Workbooks;
                workbook = workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Empleados";

                int colIndex = 1;
                // Exportar encabezados
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (!dgv.Columns[i].Visible) continue;

                    Excel.Range headerCell = (Excel.Range)worksheet.Cells[1, colIndex];
                    headerCell.Value = dgv.Columns[i].HeaderText;
                    headerCell.Font.Bold = true;

                    // Colores desde la grilla (o UIStyles si están vacíos)
                    Color backColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
                    Color foreColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

                    if (backColor.IsEmpty || backColor.A == 0) backColor = UIStyles.BrandTeal;
                    if (foreColor.IsEmpty || foreColor.A == 0) foreColor = Color.White;

                    headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(backColor);
                    headerCell.Font.Color = System.Drawing.ColorTranslator.ToOle(foreColor);

                    colIndex++;
                }

                // Exportar datos
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    colIndex = 1;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (!dgv.Columns[j].Visible) continue;

                        Excel.Range dataCell = (Excel.Range)worksheet.Cells[i + 2, colIndex];
                        var value = dgv.Rows[i].Cells[j].Value;

                        // Formatear según el tipo
                        if (value != null && value != DBNull.Value)
                        {
                            if (dgv.Columns[j].ValueType == typeof(decimal) || dgv.Columns[j].ValueType == typeof(double))
                            {
                                dataCell.Value = value;
                                dataCell.NumberFormat = "#,##0.00";
                            }
                            else if (dgv.Columns[j].ValueType == typeof(DateTime))
                            {
                                dataCell.Value = value;
                                dataCell.NumberFormat = "dd/mm/yyyy";
                            }
                            else
                            {
                                dataCell.Value = value.ToString();
                            }
                        }

                        // Colores intercalados desde la grilla
                        if (i % 2 != 0)
                        {
                            Color altColor = dgv.AlternatingRowsDefaultCellStyle.BackColor;
                            if (altColor.IsEmpty || altColor.A == 0) altColor = UIStyles.BrandPinkBg;
                            dataCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(altColor);
                        }

                        colIndex++;
                    }
                }

                Excel.Range fullRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dgv.Rows.Count + 1, colIndex - 1]];
                fullRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                fullRange.Columns.AutoFit();

                workbook.SaveAs(filePath);
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }
                if (workbooks != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
                if (worksheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
                    sfd.FileName = "Reporte_Empleados_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportToExcel(dgvEmpleados, sfd.FileName);
                        MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al exportar a Excel");
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
