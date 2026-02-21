using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Clase estática que define los estilos UX/UI modernos para el sistema
    /// Paleta de colores: Blanco y Azul con principios de Material Design
    /// </summary>
    public static class UIStyles
    {
        #region Colores Base
        
        // Colores principales - Paleta Azul y Blanco
        public static readonly Color PrimaryBlue = Color.FromArgb(0, 122, 204);        // Azul principal
        public static readonly Color SecondaryBlue = Color.FromArgb(64, 158, 255);     // Azul secundario
        public static readonly Color LightBlue = Color.FromArgb(227, 242, 253);        // Azul claro
        public static readonly Color DarkBlue = Color.FromArgb(0, 78, 146);            // Azul oscuro
        
        // Colores neutros
        public static readonly Color White = Color.White;
        public static readonly Color LightGray = Color.FromArgb(248, 249, 250);
        public static readonly Color MediumGray = Color.FromArgb(108, 117, 125);
        public static readonly Color DarkGray = Color.FromArgb(52, 58, 64);
        
        // Colores de estado
        public static readonly Color SuccessGreen = Color.FromArgb(40, 167, 69);
        public static readonly Color WarningOrange = Color.FromArgb(255, 193, 7);
        public static readonly Color DangerRed = Color.FromArgb(220, 53, 69);
        public static readonly Color InfoBlue = Color.FromArgb(23, 162, 184);
        
        #endregion

        #region Fuentes
        
        public static readonly Font TitleFont = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font SubtitleFont = new Font("Segoe UI", 14F, FontStyle.Regular);
        public static readonly Font HeaderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font SmallFont = new Font("Segoe UI", 8F, FontStyle.Regular);
        public static readonly Font ButtonFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        
        #endregion

        #region Métodos de Aplicación de Estilos

        /// <summary>
        /// Aplica estilo moderno a un formulario principal
        /// </summary>
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = White;
            form.Font = BodyFont;
            form.ForeColor = DarkGray;
        }

        /// <summary>
        /// Aplica estilo a botones primarios (acciones principales)
        /// </summary>
        public static void ApplyPrimaryButtonStyle(Button button)
        {
            button.BackColor = PrimaryBlue;
            button.ForeColor = White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = ButtonFont;
            button.Cursor = Cursors.Hand;
            button.Height = 35;
            button.UseVisualStyleBackColor = false;
            
            // Efectos hover
            button.MouseEnter += (s, e) => button.BackColor = DarkBlue;
            button.MouseLeave += (s, e) => button.BackColor = PrimaryBlue;
        }

        /// <summary>
        /// Aplica estilo a botones secundarios
        /// </summary>
        public static void ApplySecondaryButtonStyle(Button button)
        {
            button.BackColor = LightGray;
            button.ForeColor = DarkGray;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = MediumGray;
            button.Font = ButtonFont;
            button.Cursor = Cursors.Hand;
            button.Height = 35;
            button.UseVisualStyleBackColor = false;
            
            // Efectos hover
            button.MouseEnter += (s, e) => {
                button.BackColor = Color.FromArgb(233, 236, 239);
                button.FlatAppearance.BorderColor = PrimaryBlue;
            };
            button.MouseLeave += (s, e) => {
                button.BackColor = LightGray;
                button.FlatAppearance.BorderColor = MediumGray;
            };
        }

        /// <summary>
        /// Aplica estilo a botones de peligro (eliminar, cancelar)
        /// </summary>
        public static void ApplyDangerButtonStyle(Button button)
        {
            button.BackColor = DangerRed;
            button.ForeColor = White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = ButtonFont;
            button.Cursor = Cursors.Hand;
            button.Height = 35;
            button.UseVisualStyleBackColor = false;
            
            // Efectos hover
            button.MouseEnter += (s, e) => button.BackColor = Color.FromArgb(200, 35, 51);
            button.MouseLeave += (s, e) => button.BackColor = DangerRed;
        }

        /// <summary>
        /// Aplica estilo moderno a TextBox
        /// </summary>
        public static void ApplyTextBoxStyle(TextBox textBox)
        {
            textBox.Font = BodyFont;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = White;
            textBox.ForeColor = DarkGray;
            textBox.Height = 30;
            
            // Efectos focus
            textBox.Enter += (s, e) => {
                textBox.BackColor = LightBlue;
            };
            textBox.Leave += (s, e) => {
                textBox.BackColor = White;
            };
        }

        /// <summary>
        /// Aplica estilo a ComboBox
        /// </summary>
        public static void ApplyComboBoxStyle(ComboBox comboBox)
        {
            comboBox.Font = BodyFont;
            comboBox.BackColor = White;
            comboBox.ForeColor = DarkGray;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Height = 30;
        }

        /// <summary>
        /// Aplica estilo a Labels de título
        /// </summary>
        public static void ApplyTitleLabelStyle(Label label)
        {
            label.Font = TitleFont;
            label.ForeColor = PrimaryBlue;
            label.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Aplica estilo a Labels de subtítulo
        /// </summary>
        public static void ApplySubtitleLabelStyle(Label label)
        {
            label.Font = SubtitleFont;
            label.ForeColor = DarkGray;
            label.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Aplica estilo a Labels normales
        /// </summary>
        public static void ApplyLabelStyle(Label label)
        {
            label.Font = BodyFont;
            label.ForeColor = DarkGray;
            label.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Aplica estilo a GroupBox
        /// </summary>
        public static void ApplyGroupBoxStyle(GroupBox groupBox)
        {
            groupBox.Font = HeaderFont;
            groupBox.ForeColor = PrimaryBlue;
            groupBox.BackColor = Color.Transparent;
            groupBox.FlatStyle = FlatStyle.Flat;
        }

        /// <summary>
        /// Aplica estilo moderno a DataGridView
        /// </summary>
        public static void ApplyDataGridViewStyle(DataGridView dgv)
        {
            // Colores generales
            dgv.BackgroundColor = White;
            dgv.GridColor = Color.FromArgb(222, 226, 230);
            dgv.BorderStyle = BorderStyle.None;
            
            // Estilo de encabezados
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = White;
            dgv.ColumnHeadersDefaultCellStyle.Font = HeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = DarkBlue;
            dgv.ColumnHeadersHeight = 40;
            
            // Estilo de celdas
            dgv.DefaultCellStyle.BackColor = White;
            dgv.DefaultCellStyle.ForeColor = DarkGray;
            dgv.DefaultCellStyle.Font = BodyFont;
            dgv.DefaultCellStyle.SelectionBackColor = LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = DarkGray;
            dgv.RowTemplate.Height = 35;
            
            // Estilo de filas alternas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = LightGray;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = DarkGray;
            
            // Configuraciones adicionales
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
        }

        /// <summary>
        /// Aplica estilo a ToolStrip/MenuStrip
        /// </summary>
        public static void ApplyToolStripStyle(ToolStrip toolStrip)
        {
            toolStrip.BackColor = White;
            toolStrip.ForeColor = DarkGray;
            toolStrip.Font = BodyFont;
            toolStrip.Renderer = new ModernToolStripRenderer();
        }

        /// <summary>
        /// Aplica estilo a Panel contenedor
        /// </summary>
        public static void ApplyPanelStyle(Panel panel)
        {
            panel.BackColor = White;
            panel.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Aplica padding y márgenes consistentes a un control
        /// </summary>
        public static void ApplySpacing(Control control, int padding = 10)
        {
            control.Padding = new Padding(padding);
            control.Margin = new Padding(padding / 2);
        }

        /// <summary>
        /// Aplica estilos modernos automáticamente a todos los controles de un formulario
        /// </summary>
        public static void ApplyModernStylesToForm(Form form)
        {
            // Aplicar estilo base al formulario
            ApplyFormStyle(form);
            
            // Aplicar estilos a todos los controles recursivamente
            ApplyStylesToAllControls(form);
        }

        /// <summary>
        /// Aplica estilos a todos los controles de manera recursiva
        /// </summary>
        private static void ApplyStylesToAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                switch (control)
                {
                    case GroupBox groupBox:
                        ApplyGroupBoxStyle(groupBox);
                        break;
                    case TextBox textBox:
                        ApplyTextBoxStyle(textBox);
                        break;
                    case ComboBox comboBox:
                        ApplyComboBoxStyle(comboBox);
                        break;
                    case Button button:
                        ApplyButtonStyleByName(button);
                        break;
                    case Label label:
                        ApplyLabelStyleBySize(label);
                        break;
                    case DataGridView dgv:
                        ApplyDataGridViewStyle(dgv);
                        break;
                    case Panel panel:
                        ApplyPanelStyle(panel);
                        break;
                    case ToolStrip toolStrip:
                        ApplyToolStripStyle(toolStrip);
                        break;
                    case CheckBox checkBox:
                        ApplyCheckBoxStyle(checkBox);
                        break;
                    case DateTimePicker dtp:
                        ApplyDateTimePickerStyle(dtp);
                        break;
                    case NumericUpDown numeric:
                        ApplyNumericUpDownStyle(numeric);
                        break;
                }
                
                // Aplicar recursivamente a controles hijos
                if (control.HasChildren)
                {
                    ApplyStylesToAllControls(control);
                }
            }
        }

        /// <summary>
        /// Aplica estilo a botones según su nombre
        /// </summary>
        private static void ApplyButtonStyleByName(Button button)
        {
            string name = button.Name.ToLower();
            
            if (name.Contains("grabar") || name.Contains("guardar") || name.Contains("ingresar") || 
                name.Contains("buscar") || name.Contains("generar") || name.Contains("exportar") ||
                name.Contains("nuevo") || name.Contains("agregar"))
            {
                ApplyPrimaryButtonStyle(button);
            }
            else if (name.Contains("eliminar") || name.Contains("borrar") || name.Contains("delete"))
            {
                ApplyDangerButtonStyle(button);
            }
            else
            {
                ApplySecondaryButtonStyle(button);
            }
        }

        /// <summary>
        /// Aplica estilo a labels según su tamaño de fuente
        /// </summary>
        private static void ApplyLabelStyleBySize(Label label)
        {
            if (label.Font.Size >= 16)
            {
                ApplyTitleLabelStyle(label);
            }
            else if (label.Font.Size >= 12)
            {
                ApplySubtitleLabelStyle(label);
            }
            else
            {
                ApplyLabelStyle(label);
            }
        }

        /// <summary>
        /// Aplica estilo a CheckBox
        /// </summary>
        public static void ApplyCheckBoxStyle(CheckBox checkBox)
        {
            checkBox.Font = BodyFont;
            checkBox.ForeColor = DarkGray;
            checkBox.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Aplica estilo a DateTimePicker
        /// </summary>
        public static void ApplyDateTimePickerStyle(DateTimePicker dtp)
        {
            dtp.Font = BodyFont;
            dtp.BackColor = White;
            dtp.ForeColor = DarkGray;
        }

        /// <summary>
        /// Aplica estilo a NumericUpDown
        /// </summary>
        public static void ApplyNumericUpDownStyle(NumericUpDown numeric)
        {
            numeric.Font = BodyFont;
            numeric.BackColor = White;
            numeric.ForeColor = DarkGray;
            numeric.BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion
    }

    /// <summary>
    /// Renderer personalizado para ToolStrip con estilo moderno
    /// </summary>
    public class ModernToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(UIStyles.White))
            {
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
            }
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected || e.Item.Pressed)
            {
                using (SolidBrush brush = new SolidBrush(UIStyles.LightBlue))
                {
                    e.Graphics.FillRectangle(brush, new Rectangle(Point.Empty, e.Item.Size));
                }
            }
        }
    }
}