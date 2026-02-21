using BL;
using CE;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMarcacion : Form
    {
        public frmMarcacion()
        {
            InitializeComponent();
        }
        E_Empleado objEEmp = new E_Empleado();
        BL_Empleado objBLEmp = new BL_Empleado();
        E_Marcaciones objMar = new E_Marcaciones();
        BL_Marcacion objMarBL = new BL_Marcacion();
        //Variable para guardar las horas de marcacion
        string HI;
        string HSR;
        string HIR;
        string HS;
        string OBS;
        DateTime F;
        bool flag = true;
        //Variables para almacenar el estado de las marcaciones
        string H1 = "00:00:00", H2 = "00:00:00", H3 = "00:00:00", H4 = "00:00:00", H5 = "00:00:00";

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            string fechaFormateada = fechaActual.ToString("dd/MM/yyyy");
            objEEmp.dni = txtDni.Text;
            objEEmp.Fecha = Convert.ToDateTime(fechaFormateada);

            var totalRegistro = objBLEmp.buscarPersona(objEEmp);

            if (totalRegistro.Rows.Count > 0)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }

            if (txtDni.TextLength < 8)
            {
                lblNombres.Text = string.Empty;
                chkEntrada.Checked = false; chkSalidaRefrigerio.Checked = false; chkRetornoRefrigerio.Checked = false; chkSalida.Checked = false; txtObservacion.Text = string.Empty;
                btnGrabar.Enabled = false;
            }
            else
            {
                if (totalRegistro.Rows.Count > 0)
                {
                    txtObservacion.ReadOnly = false;
                    lblNombres.Text = totalRegistro.Rows[0]["Nombres y Apellidos"].ToString();
                    btnGrabar.Enabled = true;
                    chkEntrada.Enabled = true;

                    var totMar = objMarBL.ConsultarMarcacion(objEEmp);
                    if (totMar.Rows.Count > 0)
                    {
                        //flag = false;
                        H1 = totMar.Rows[0]["H_Ingreso"].ToString();
                        H2 = totMar.Rows[0]["HS_Refrigerio"].ToString();
                        H3 = totMar.Rows[0]["HI_Refrigerio"].ToString();
                        H4 = totMar.Rows[0]["H_Salida"].ToString();
                        H5 = totMar.Rows[0]["Fecha"].ToString();
                        OBS = totMar.Rows[0]["Observacion"].ToString();
                        txtObservacion.Text = OBS;
                        txtIdMarcacion.Text = totMar.Rows[0]["Id_Marcacion"].ToString();

                        if (H1 != "00:00:00")
                        {
                            H1 = totMar.Rows[0]["H_Ingreso"].ToString();
                            chkEntrada.Checked = true;
                            chkEntrada.Enabled = false;

                            if (chkEntrada.Checked)
                            {
                                chkSalidaRefrigerio.Enabled = true;
                            }
                        }

                        if (H2 != "00:00:00")
                        {
                            H2 = totMar.Rows[0]["HS_Refrigerio"].ToString();
                            chkSalidaRefrigerio.Checked = true;
                            chkSalidaRefrigerio.Enabled = false;

                            if (chkEntrada.Checked && chkSalidaRefrigerio.Checked)
                            {
                                chkEntrada.Enabled = false;
                                chkSalidaRefrigerio.Enabled = false;
                                chkRetornoRefrigerio.Enabled = true;
                                chkSalida.Enabled = false;
                            }
                        }

                        if (H3 != "00:00:00")
                        {
                            H3 = totMar.Rows[0]["HI_Refrigerio"].ToString();
                            chkRetornoRefrigerio.Checked = true;
                            chkRetornoRefrigerio.Enabled = false;

                            if (chkEntrada.Checked && chkSalidaRefrigerio.Checked && chkRetornoRefrigerio.Checked)
                            {
                                chkEntrada.Enabled = false;
                                chkSalidaRefrigerio.Enabled = false;
                                chkRetornoRefrigerio.Enabled = false;
                                chkSalida.Enabled = true;
                            }
                        }


                        if (H4 != "00:00:00")
                        {
                            H4 = totMar.Rows[0]["H_Salida"].ToString();
                            chkSalida.Checked = true;
                            chkSalida.Enabled = false;

                            if (chkEntrada.Checked && chkSalidaRefrigerio.Checked && chkRetornoRefrigerio.Checked && chkSalida.Checked)
                            {
                                chkEntrada.Enabled = false;
                                chkSalidaRefrigerio.Enabled = false;
                                chkRetornoRefrigerio.Enabled = false;
                                chkSalida.Enabled = false;
                            }
                        }

                        if (chkEntrada.Checked && chkSalidaRefrigerio.Checked && chkRetornoRefrigerio.Checked && chkSalida.Checked)
                        {
                            MessageBox.Show("EL EMPLEADO YA TIENE LAS MARCACIONES COMPLETAS", "REGISTRO DE ASISTENCIAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtObservacion.ReadOnly = true;
                            txtDni.Enabled = true;
                            btnGrabar.Enabled = false; txtDni.Focus();
                            return;
                        }
                        else
                        {
                            btnGrabar.Enabled = true;
                        }
                    }

                    lblIdPersonal.Text = totalRegistro.Rows[0][0].ToString().Trim();
                    MessageBox.Show("POR FAVOR, REALICE SU MARCACIÓN", "MARCACIONES", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //txtDni.Enabled = false;
                    btnGrabar.Enabled = true; txtObservacion.ReadOnly = false;

                }
                else
                {
                    txtObservacion.ReadOnly = true;
                    MessageBox.Show("NO EXISTE EMPLEADO CON EL DNI INGRESADO", "Marcacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDni.Enabled = true;
                    txtDni.Text = string.Empty;
                    chkEntrada.Checked = false; chkSalidaRefrigerio.Checked = false; chkRetornoRefrigerio.Checked = false; chkSalida.Checked = false; txtObservacion.Text = string.Empty;
                    btnGrabar.Enabled = false; txtDni.Focus();

                }
            }

        }
        private void frmMarcacion_Load(object sender, EventArgs e)
        {
            ApplyModernStyles();
            txtObservacion.ReadOnly = true;
            lblFecha.Text = DateTime.Now.ToShortDateString();
            btnGrabar.Enabled = false;
            chkEntrada.Enabled = false;
            chkSalidaRefrigerio.Enabled = false;
            chkRetornoRefrigerio.Enabled = false;
            chkSalida.Enabled = false;
            btnGrabar.Enabled = false;
        }

        private void ApplyModernStyles()
        {
            UIStyles.ApplyModernStylesToForm(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("T");
        }

        private void rbtIngreso_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (chkEntrada.Checked)
            {
                if (H1 == "00:00:00")
                {
                    HI = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    HI = H1;
                }
            }
            else
            {
                HI = "00:00:00";
            }

            if (chkSalidaRefrigerio.Checked)
            {
                if (H2 == "00:00:00")
                {
                    HSR = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    HSR = H2;
                }
            }
            else
            {
                HSR = "00:00:00";
            }

            if (chkRetornoRefrigerio.Checked)
            {
                if (H3 == "00:00:00")
                {
                    HIR = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    HIR = H3;
                }
            }
            else
            {
                HIR = "00:00:00";
            }

            if (chkSalida.Checked)
            {
                if (H4 == "00:00:00")
                {
                    HS = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    HS = H4;
                }
            }
            else
            {
                HS = "00:00:00";
            }

            if (H5 != "00:00:00" && H5 != "")
            {
                F = DateTime.Parse(H5);
            }
            else
            {
                F = DateTime.Now;
            }

            objMar.Id_Empleado = lblIdPersonal.Text.Trim();
            objMar.Fecha = F;
            objMar.H_Ingreso = HI;
            objMar.HS_Refrigerio = HSR;
            objMar.HI_Refrigerio = HIR;
            objMar.H_Salida = HS;

            //INICIO

            if (HSR == "00:00:00" || HIR == "00:00:00")
            {
                objMar.TH_Refrigerio = "00:00:00";
            }
            else
            {
                objMar.TH_Refrigerio = (Convert.ToDateTime(HIR) - Convert.ToDateTime(HSR)).ToString();
            }

            if (HS == "00:00:00" || HI == "00:00:00")
            {
                objMar.TH_Trabajadas = "00:00:00";
            }
            else
            {
                objMar.TH_Trabajadas = (Convert.ToDateTime(HS) - Convert.ToDateTime(HI)).ToString();
            }
            //FIN
            objMar.Observacion = txtObservacion.Text;

            objMar.Id_Marcacion = string.IsNullOrEmpty(txtIdMarcacion.Text) ? "1" : txtIdMarcacion.Text;
            try
            {
                bool accion = false;
                string mensaje = string.Empty;

                if ((chkEntrada.Checked && chkEntrada.Enabled == true) || (chkSalidaRefrigerio.Checked && chkSalidaRefrigerio.Enabled == true) || (chkRetornoRefrigerio.Checked && chkRetornoRefrigerio.Enabled == true)
                    || (chkSalida.Checked && chkSalida.Enabled == true))
                {
                    accion = objMarBL.InsertarMarcacion(objMar);
                }
                else
                {
                    MessageBox.Show("POR LO MENOS DEBE SELECCIONAR UNA OPCION PARA REGISTRAR LA MARCACIÓN", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (accion)
                {
                    mensaje = objMar.Mensaje.ToString();
                    MessageBox.Show(mensaje, "CONTROL DE ASISTENCIAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblNombres.Text = string.Empty;
                    chkEntrada.Checked = false; chkSalidaRefrigerio.Checked = false; chkRetornoRefrigerio.Checked = false; chkSalida.Checked = false;
                    chkEntrada.Enabled = false; chkSalidaRefrigerio.Enabled = false; chkRetornoRefrigerio.Enabled = false; chkSalida.Enabled = false;
                    txtDni.Enabled = true; txtDni.Focus(); txtDni.Text = string.Empty;
                    txtObservacion.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("OCURRIO UN ERROR EL GUARDAR LA INFORMACIÓN", "CONTROL DE ASISTENCIAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " CONTROL DE ASISTENCIAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMarcacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            if (!flag)
            {
                txtObservacion.ReadOnly = flag;
                RichTextBox richTextBox = (RichTextBox)sender;
                int pos = richTextBox.SelectionStart;
                richTextBox.TextChanged -= txtObservacion_TextChanged; // Desactiva el evento temporalmente
                richTextBox.Text = richTextBox.Text.ToUpper(); richTextBox.SelectionStart = pos; // Mantiene la posición del cursor
                richTextBox.TextChanged += txtObservacion_TextChanged;
            }
            else
            {
                txtObservacion.ReadOnly = true;
            }

        }

        private void chkEntrada_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEntrada.Checked)
            {
                HI = DateTime.Now.ToString("HH:mm:ss");
                btnGrabar.Enabled = true;
            }
        }

        private void chkSalidaRefrigerio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSalidaRefrigerio.Checked)
            {
                HSR = DateTime.Now.ToString("HH:mm:ss");
                btnGrabar.Enabled = true;
            }
            else
            {
                HSR = "";
            }
        }

        private void chkRetornoRefrigerio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRetornoRefrigerio.Checked)
            {
                HIR = DateTime.Now.ToString("HH:mm:ss");
                btnGrabar.Enabled = true;
            }
            else
            {
                HIR = "";
            }
        }

        private void chkSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSalida.Checked)
            {
                HS = DateTime.Now.ToString("HH:mm:ss");
                btnGrabar.Enabled = true;
            }
        }
    }
}