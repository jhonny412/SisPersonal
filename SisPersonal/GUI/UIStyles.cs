using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Clase estática que define los estilos UX/UI modernos para el sistema.
    /// Paleta corporativa: Rosa #fe6393 y Cian #0cb9da
    /// Principios: jerarquía visual, consistencia, accesibilidad, feedback visual.
    /// </summary>
    public static class UIStyles
    {
        #region Paleta Corporativa

        // Colores primarios de la empresa
        public static readonly Color BrandPink    = Color.FromArgb(254, 99,  147);   // #fe6393
        public static readonly Color BrandCyan    = Color.FromArgb(12,  185, 218);   // #0cb9da

        // Variantes de rosa
        public static readonly Color BrandPinkDark  = Color.FromArgb(220, 70,  115);
        public static readonly Color BrandPinkLight = Color.FromArgb(255, 180, 205);
        public static readonly Color BrandPinkBg    = Color.FromArgb(255, 240, 246);  // fondo suave rosa

        // Variantes de cian
        public static readonly Color BrandCyanDark  = Color.FromArgb(8,   148, 175);
        public static readonly Color BrandCyanLight = Color.FromArgb(150, 230, 245);
        public static readonly Color BrandCyanBg    = Color.FromArgb(232, 250, 254);  // fondo suave cian

        // Neutros
        public static readonly Color White       = Color.White;
        public static readonly Color Background  = Color.FromArgb(248, 250, 252);     // gris muy claro
        public static readonly Color Surface     = Color.White;
        public static readonly Color TextPrimary = Color.FromArgb(30,  30,  45);      // casi negro
        public static readonly Color TextSecond  = Color.FromArgb(100, 110, 130);     // gris medio
        public static readonly Color Border      = Color.FromArgb(220, 225, 235);

        // Estado
        public static readonly Color SuccessGreen = Color.FromArgb(39,  174, 96);
        public static readonly Color DangerRed    = Color.FromArgb(220, 53,  69);
        public static readonly Color WarningAmber = Color.FromArgb(255, 193, 7);

        // Alias de compatibilidad (nombres anteriores → paleta corporativa)
        public static readonly Color DarkGray  = Color.FromArgb(30,  30,  45);   // = TextPrimary
        public static readonly Color LightGray = Color.FromArgb(248, 250, 252);  // = Background
        public static readonly Color LightBlue = Color.FromArgb(232, 250, 254);  // = BrandCyanBg

        #endregion

        #region Fuentes (Segoe UI — fuente nativa de Windows moderna)

        public static readonly Font TitleFont    = new Font("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font SubtitleFont = new Font("Segoe UI", 13F, FontStyle.Bold);
        public static readonly Font HeaderFont   = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font BodyFont     = new Font("Segoe UI",  9F, FontStyle.Regular);
        public static readonly Font SmallFont    = new Font("Segoe UI",  8F, FontStyle.Regular);
        public static readonly Font ButtonFont   = new Font("Segoe UI",  9F, FontStyle.Bold);
        public static readonly Font InputFont    = new Font("Segoe UI",  9F, FontStyle.Regular);

        #endregion

        #region Estilos por tipo de control

        /// <summary>Aplica bordes redondeados a un control mediante Region.</summary>
        public static void ApplyRoundedCorners(Control ctrl, int radius = 15)
        {
            ctrl.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, radius, radius));
            ctrl.Resize += (s, e) =>
            {
                ctrl.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, radius, radius));
            };
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        /// <summary>Estilo base del formulario.</summary>
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = Background;
            form.Font      = BodyFont;
            form.ForeColor = TextPrimary;
        }

        /// <summary>Botón primario — acción principal (Cian corporativo).</summary>
        public static void ApplyPrimaryButtonStyle(Button btn)
        {
            btn.BackColor              = BrandCyan;
            btn.ForeColor              = White;
            btn.FlatStyle              = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                   = ButtonFont;
            btn.Cursor                 = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;

            ApplyRoundedCorners(btn);

            btn.MouseEnter += (s, e) => btn.BackColor = BrandCyanDark;
            btn.MouseLeave += (s, e) => btn.BackColor = BrandCyan;
        }

        /// <summary>Botón de acción secundaria (Rosa corporativo).</summary>
        public static void ApplySecondaryButtonStyle(Button btn)
        {
            btn.BackColor              = BrandPink;
            btn.ForeColor              = White;
            btn.FlatStyle              = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                   = ButtonFont;
            btn.Cursor                 = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;

            ApplyRoundedCorners(btn);

            btn.MouseEnter += (s, e) => btn.BackColor = BrandPinkDark;
            btn.MouseLeave += (s, e) => btn.BackColor = BrandPink;
        }

        /// <summary>Botón de peligro — eliminar / cancelar.</summary>
        public static void ApplyDangerButtonStyle(Button btn)
        {
            btn.BackColor              = DangerRed;
            btn.ForeColor              = White;
            btn.FlatStyle              = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                   = ButtonFont;
            btn.Cursor                 = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;

            ApplyRoundedCorners(btn);

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(190, 30, 50);
            btn.MouseLeave += (s, e) => btn.BackColor = DangerRed;
        }

        /// <summary>Botón outline (neutro, acciones complementarias).</summary>
        public static void ApplyOutlineButtonStyle(Button btn)
        {
            btn.BackColor                        = White;
            btn.ForeColor                        = BrandCyan;
            btn.FlatStyle                        = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize        = 2;
            btn.FlatAppearance.BorderColor       = BrandCyan;
            btn.FlatAppearance.MouseOverBackColor = BrandCyanBg;
            btn.Font                             = ButtonFont;
            btn.Cursor                           = Cursors.Hand;
            btn.UseVisualStyleBackColor          = false;

            ApplyRoundedCorners(btn);
        }

        /// <summary>TextBox moderno con feedback de foco.</summary>
        public static void ApplyTextBoxStyle(TextBox tb)
        {
            tb.Font        = InputFont;
            tb.BackColor   = White;
            tb.ForeColor   = TextPrimary;
            tb.BorderStyle = BorderStyle.FixedSingle;

            tb.Enter += (s, e) => { tb.BackColor = BrandCyanBg; };
            tb.Leave += (s, e) => { tb.BackColor = White; };
        }

        /// <summary>ComboBox moderno.</summary>
        public static void ApplyComboBoxStyle(ComboBox cb)
        {
            cb.Font      = InputFont;
            cb.BackColor = White;
            cb.ForeColor = TextPrimary;
            cb.FlatStyle = FlatStyle.Flat;
        }

        /// <summary>Label de título grande.</summary>
        public static void ApplyTitleLabelStyle(Label lbl)
        {
            lbl.Font      = TitleFont;
            lbl.ForeColor = BrandCyan;
            lbl.BackColor = Color.Transparent;
        }

        /// <summary>Label de subtítulo.</summary>
        public static void ApplySubtitleLabelStyle(Label lbl)
        {
            lbl.Font      = SubtitleFont;
            lbl.ForeColor = BrandPink;
            lbl.BackColor = Color.Transparent;
        }

        /// <summary>Label normal.</summary>
        public static void ApplyLabelStyle(Label lbl)
        {
            lbl.Font      = BodyFont;
            lbl.ForeColor = TextPrimary;
            lbl.BackColor = Color.Transparent;
        }

        /// <summary>GroupBox con acento cian en el título.</summary>
        public static void ApplyGroupBoxStyle(GroupBox gb)
        {
            gb.Font      = HeaderFont;
            gb.ForeColor = BrandCyan;
            gb.BackColor = Color.Transparent;
            gb.FlatStyle = FlatStyle.Flat;
        }

        /// <summary>DataGridView moderno con cabecera cian.</summary>
        public static void ApplyDataGridViewStyle(DataGridView dgv)
        {
            dgv.BackgroundColor = White;
            dgv.GridColor       = Border;
            dgv.BorderStyle     = BorderStyle.None;

            // Cabecera
            dgv.EnableHeadersVisualStyles                        = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor         = BrandCyan;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor         = White;
            dgv.ColumnHeadersDefaultCellStyle.Font              = HeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = BrandCyanDark;
            dgv.ColumnHeadersDefaultCellStyle.Alignment         = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight                              = 38;

            // Celdas
            dgv.DefaultCellStyle.BackColor          = White;
            dgv.DefaultCellStyle.ForeColor          = TextPrimary;
            dgv.DefaultCellStyle.Font               = BodyFont;
            dgv.DefaultCellStyle.SelectionBackColor = BrandCyanBg;
            dgv.DefaultCellStyle.SelectionForeColor = TextPrimary;
            dgv.RowTemplate.Height                  = 32;

            // Filas alternas — rosa muy suave
            dgv.AlternatingRowsDefaultCellStyle.BackColor = BrandPinkBg;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimary;

            dgv.SelectionMode    = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect      = false;
            dgv.AllowUserToAddRows    = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly         = true;
        }

        /// <summary>CheckBox moderno.</summary>
        public static void ApplyCheckBoxStyle(CheckBox cb)
        {
            cb.Font      = BodyFont;
            cb.ForeColor = TextPrimary;
            cb.BackColor = Color.Transparent;
            cb.Cursor    = Cursors.Hand;
        }

        /// <summary>DateTimePicker moderno.</summary>
        public static void ApplyDateTimePickerStyle(DateTimePicker dtp)
        {
            dtp.Font      = InputFont;
            dtp.BackColor = White;
            dtp.ForeColor = TextPrimary;
        }

        /// <summary>NumericUpDown moderno.</summary>
        public static void ApplyNumericUpDownStyle(NumericUpDown num)
        {
            num.Font        = InputFont;
            num.BackColor   = White;
            num.ForeColor   = TextPrimary;
            num.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>Panel contenedor.</summary>
        public static void ApplyPanelStyle(Panel panel)
        {
            panel.BackColor   = White;
            panel.BorderStyle = BorderStyle.None;
        }

        /// <summary>ToolStrip / MenuStrip moderno.</summary>
        public static void ApplyToolStripStyle(ToolStrip ts)
        {
            ts.BackColor = White;
            ts.ForeColor = TextPrimary;
            ts.Font      = BodyFont;
            ts.Renderer  = new ModernToolStripRenderer();
        }

        #endregion

        #region Aplicación masiva a formulario

        /// <summary>
        /// Aplica la paleta corporativa a todos los controles del formulario de forma recursiva.
        /// </summary>
        public static void ApplyModernStylesToForm(Form form)
        {
            ApplyFormStyle(form);
            ApplyStylesToAllControls(form);
        }

        private static void ApplyStylesToAllControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                switch (ctrl)
                {
                    case GroupBox gb:   ApplyGroupBoxStyle(gb);   break;
                    case TextBox  tb:   ApplyTextBoxStyle(tb);    break;
                    case ComboBox cb:   ApplyComboBoxStyle(cb);   break;
                    case Button   btn:  ApplyButtonStyleByName(btn); break;
                    case Label    lbl:  ApplyLabelStyleBySize(lbl);  break;
                    case DataGridView dgv: ApplyDataGridViewStyle(dgv); break;
                    case Panel    pnl:  ApplyPanelStyle(pnl);    break;
                    case ToolStrip ts:  ApplyToolStripStyle(ts); break;
                    case CheckBox cb2:  ApplyCheckBoxStyle(cb2); break;
                    case DateTimePicker dtp: ApplyDateTimePickerStyle(dtp); break;
                    case NumericUpDown  num: ApplyNumericUpDownStyle(num);  break;
                }

                if (ctrl.HasChildren)
                    ApplyStylesToAllControls(ctrl);
            }
        }

        private static void ApplyButtonStyleByName(Button btn)
        {
            string n = btn.Name.ToLower();

            if (n.Contains("grabar") || n.Contains("guardar") || n.Contains("ingresar") ||
                n.Contains("buscar") || n.Contains("generar") || n.Contains("exportar") ||
                n.Contains("nuevo")  || n.Contains("agregar") || n.Contains("aceptar"))
            {
                ApplyPrimaryButtonStyle(btn);   // Cian — acción confirmación
            }
            else if (n.Contains("eliminar") || n.Contains("borrar") || n.Contains("delete") ||
                     n.Contains("cancelar"))
            {
                ApplyDangerButtonStyle(btn);    // Rojo — acción destructiva
            }
            else if (n.Contains("salir") || n.Contains("cerrar") || n.Contains("volver"))
            {
                ApplyOutlineButtonStyle(btn);   // Outline — navegación
            }
            else
            {
                ApplySecondaryButtonStyle(btn); // Rosa — acción secundaria
            }
        }

        private static void ApplyLabelStyleBySize(Label lbl)
        {
            if      (lbl.Font.Size >= 16) ApplyTitleLabelStyle(lbl);
            else if (lbl.Font.Size >= 12) ApplySubtitleLabelStyle(lbl);
            else                          ApplyLabelStyle(lbl);
        }

        #endregion
    }

    /// <summary>Renderer personalizado con la paleta corporativa.</summary>
    public class ModernToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            using (var brush = new SolidBrush(UIStyles.White))
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected || e.Item.Pressed)
                using (var brush = new SolidBrush(UIStyles.BrandCyanBg))
                    e.Graphics.FillRectangle(brush, new Rectangle(Point.Empty, e.Item.Size));
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
                using (var brush = new SolidBrush(UIStyles.BrandCyanBg))
                    e.Graphics.FillRectangle(brush, new Rectangle(Point.Empty, e.Item.Size));
        }
    }
}