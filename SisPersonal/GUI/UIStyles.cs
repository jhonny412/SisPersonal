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
        public static readonly System.Drawing.Color BrandGold      = System.Drawing.Color.FromArgb(219, 176, 80);  // #dbb050
        public static readonly System.Drawing.Color BrandTeal      = System.Drawing.Color.FromArgb(26, 141, 137);  // #1a8d89
        public static readonly System.Drawing.Color BrandPink      = System.Drawing.Color.FromArgb(254, 99, 147);

        // Alias para compatibilidad
        public static readonly System.Drawing.Color BrandCyan      = BrandTeal;
        public static readonly System.Drawing.Color BrandNavy      = BrandGold;
        
        // Variantes y fondos
        public static readonly System.Drawing.Color BrandPinkDark  = System.Drawing.Color.FromArgb(220, 70, 115);
        public static readonly System.Drawing.Color BrandCyanDark  = System.Drawing.Color.FromArgb(20, 110, 105);
        public static readonly System.Drawing.Color BrandPinkBg    = System.Drawing.Color.FromArgb(255, 240, 246);
        public static readonly System.Drawing.Color BrandCyanBg    = System.Drawing.Color.FromArgb(232, 250, 254);

        // Neutros
        public static readonly System.Drawing.Color White       = System.Drawing.Color.White;
        public static readonly System.Drawing.Color Background  = System.Drawing.Color.FromArgb(248, 250, 252);     // gris muy claro
        public static readonly System.Drawing.Color Surface     = System.Drawing.Color.White;
        public static readonly System.Drawing.Color TextPrimary = System.Drawing.Color.FromArgb(30,  30,  45);      // casi negro
        public static readonly System.Drawing.Color TextSecond  = System.Drawing.Color.FromArgb(100, 110, 130);     // gris medio
        public static readonly System.Drawing.Color Border      = System.Drawing.Color.FromArgb(220, 225, 235);

        // Estado
        public static readonly System.Drawing.Color SuccessGreen = System.Drawing.Color.FromArgb(39,  174, 96);
        public static readonly System.Drawing.Color DangerRed    = System.Drawing.Color.FromArgb(220, 53,  69);
        public static readonly System.Drawing.Color WarningAmber = System.Drawing.Color.FromArgb(255, 193, 7);

        // Alias de compatibilidad (nombres anteriores → paleta corporativa)
        public static readonly System.Drawing.Color DarkGray  = System.Drawing.Color.FromArgb(30,  30,  45);   // = TextPrimary
        public static readonly System.Drawing.Color LightGray = System.Drawing.Color.FromArgb(248, 250, 252);  // = Background
        public static readonly System.Drawing.Color LightBlue = System.Drawing.Color.FromArgb(232, 250, 254);  // = BrandCyanBg
        
        // Login Modern Colors
        public static readonly System.Drawing.Color LoginInputBg       = System.Drawing.Color.FromArgb(244, 246, 249);
        
        // Sidebar / Dark Theme
        public static readonly System.Drawing.Color SidebarBg      = System.Drawing.Color.FromArgb(20, 40, 40); // Darker Teal for background
        public static readonly System.Drawing.Color SidebarHover   = System.Drawing.Color.FromArgb(40, 80, 80);
        public static readonly System.Drawing.Color SidebarSelection = BrandGold;
        public static readonly System.Drawing.Color AccentOrange     = BrandGold;
        
        // Login Modern Colors
        public static readonly System.Drawing.Color LoginGradientStart = BrandTeal;
        public static readonly System.Drawing.Color LoginGradientEnd   = System.Drawing.Color.FromArgb(40, 160, 155);

        #endregion

        #region Fuentes (Segoe UI — fuente nativa de Windows moderna)

        public static readonly System.Drawing.Font TitleFont    = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        public static readonly System.Drawing.Font SubtitleFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        public static readonly System.Drawing.Font HeaderFont   = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        public static readonly System.Drawing.Font BodyFont     = new System.Drawing.Font("Segoe UI",  9F, System.Drawing.FontStyle.Regular);
        public static readonly System.Drawing.Font SmallFont    = new System.Drawing.Font("Segoe UI",  8F, System.Drawing.FontStyle.Regular);
        public static readonly System.Drawing.Font ButtonFont   = new System.Drawing.Font("Segoe UI",  9F, System.Drawing.FontStyle.Bold);
        public static readonly System.Drawing.Font InputFont    = new System.Drawing.Font("Segoe UI",  9F, System.Drawing.FontStyle.Regular);

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

            btn.MouseEnter += (s, e) => btn.BackColor = System.Drawing.Color.FromArgb(190, 30, 50);
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
            lbl.BackColor = System.Drawing.Color.Transparent;
        }

        /// <summary>Label de subtítulo.</summary>
        public static void ApplySubtitleLabelStyle(Label lbl)
        {
            lbl.Font      = SubtitleFont;
            lbl.ForeColor = BrandPink;
            lbl.BackColor = System.Drawing.Color.Transparent;
        }

        /// <summary>Label normal.</summary>
        public static void ApplyLabelStyle(Label lbl)
        {
            lbl.Font      = BodyFont;
            lbl.ForeColor = TextPrimary;
            lbl.BackColor = System.Drawing.Color.Transparent;
        }

        /// <summary>GroupBox con acento cian en el título.</summary>
        public static void ApplyGroupBoxStyle(GroupBox gb)
        {
            gb.Font      = HeaderFont;
            gb.ForeColor = BrandCyan;
            gb.BackColor = System.Drawing.Color.Transparent;
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
            cb.BackColor = System.Drawing.Color.Transparent;
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

        /// <summary>Dibuja un fondo con gradiente lineal.</summary>
        public static void PaintGradient(System.Drawing.Graphics g, System.Drawing.Rectangle rect, System.Drawing.Color startColor, System.Drawing.Color endColor, float angle = 45f)
        {
            using (var brush = new LinearGradientBrush(rect, startColor, endColor, angle))
            {
                g.FillRectangle(brush, rect);
            }
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
                    e.Graphics.FillRectangle(brush, new System.Drawing.Rectangle(System.Drawing.Point.Empty, e.Item.Size));
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
                using (var brush = new SolidBrush(UIStyles.BrandCyanBg))
                    e.Graphics.FillRectangle(brush, new System.Drawing.Rectangle(System.Drawing.Point.Empty, e.Item.Size));
        }
    }
}
