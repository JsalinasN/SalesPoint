using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPoint
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            BtnDashboard_Click(null,e);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMaximizar.Visible = false;
            BtnRestaurar.Visible = true;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnRestaurar.Visible = false;
            BtnMaximizar.Visible = true;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
          
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

       
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            SubmenuResportes.Visible = true;

        }

        private void BtnReporteVenta_Click(object sender, EventArgs e)
        {
            SubmenuResportes.Visible = false;
        }

        private void BtnReporteCompra_Click(object sender, EventArgs e)
        {
            SubmenuResportes.Visible = false;
        }

        private void BtnReportePago_Click(object sender, EventArgs e)
        {
            SubmenuResportes.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenAnyForms(object formProd)
        {
            if (this.PanelContenedor.Controls.Count > 0 ) 
                this.PanelContenedor.Controls.RemoveAt(0);

            Form fh = formProd as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            OpenAnyForms(new Productos());
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            OpenAnyForms(new Dashboard());
        }
    }
}
