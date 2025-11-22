using CarWash_01.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CarWash_01
{
    class ClLimpiadors
    {
        GroupBox groupbox = new GroupBox();
        Label label = new Label();
        PictureBox pictureBox = new PictureBox();
        Button button = new Button();
        FrmMain frmMain;
        ClCotxe cotxe = null;

        private System.Timers.Timer acabat = new System.Timers.Timer();

        private delegate void elMeuDelegat();

        public ClLimpiadors(Size xTamany, Point location, string name, FrmMain xfmain)
        {
            // Asignamos parámetros recibidos
            frmMain = xfmain;
            groupbox.Size = xTamany;
            groupbox.Location = location;
            groupbox.Text = name;

            // --- CONFIGURACIÓN DEL PICTUREBOX ---
            pictureBox.Location = new Point(5, 12);
            pictureBox.Size = new Size(xTamany.Width - 10, xTamany.Height - 60);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // --- CONFIGURACIÓN DEL BOTÓN ---
            button.Text = "Start";
            button.Size = new Size(xTamany.Width / 3, xTamany.Height / 4);
            button.BackColor = Color.DarkGreen;
            button.ForeColor = Color.White;
            button.Location = new Point(
                xTamany.Width - (xTamany.Width / 3),
                xTamany.Height - (xTamany.Height / 4)
            );
            button.Click += Button_Click;

            // --- CONFIGURACIÓN DEL LABEL ---
            label.Location = new Point(5, xTamany.Height - 22);
            label.Text = "0";
            label.BackColor = Color.Transparent;

            // --- AÑADIR CONTROLES ---
            groupbox.Controls.Add(pictureBox);
            groupbox.Controls.Add(button);
            groupbox.Controls.Add(label);

            // --- INICIAR TIMERS / HILOS ---
            iniTimers();

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (button.Text == "Start")
            {
                button.BackColor = Color.Red;
                button.Text = "Stop";
                pictureBox.Image = Resources.animacio3;
                acabat.Start();
            }
            else
            {
                button.BackColor = Color.DarkGreen;
                button.Text = "Start";
                pictureBox.Image = null;
                acabat.Stop();
            }
        }

        private void iniTimers()
        {
            System.Threading.Thread.Sleep(5);
            acabat.Interval = 1000;
            acabat.Elapsed += TimerFinished_Elapsed;
        }

        private void TimerFinished_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (label.Text == "0")
            {
                elMeuDelegat delegat = agafatCotxe;
                frmMain.BeginInvoke(delegat);
            }
            else
            {
                elMeuDelegat delegat = recarregarLlista;
                frmMain.BeginInvoke(delegat);
            }
        }

        private void recarregarLlista()
        {
            label.Text = (int.Parse(label.Text) - 1).ToString();
        }

        private void agafatCotxe()
        {
            cotxe = frmMain.extreureCotxe();

            if (cotxe != null)
            {
                cotxe.cambiarImg();
                pictureBox.Image = cotxe.agafarImg();
                int a = cotxe.agafarTipos();
                this.label.Text = a.ToString();
                button.Visible = false;
            }
            else
            {
                pictureBox.Image = Resources.animacio3;
                button.Visible = true;
            }
        }

        public GroupBox obtenirGrup()
        {
            return groupbox;
        }
    }
}
