using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace CarWash_01
{
    public partial class FrmMain : Form
    {
        //properties

        List<ClCotxe> llCotxes = new List<ClCotxe>();
        List<ClLimpiadors> llLimpadors = new List<ClLimpiadors>();

        int cotxeHeight = 40;
        int cotxeWidth = 60;

        int numeroLimpadors = 4;
        private Mutex exclusio { get; set; } = new Mutex();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void rbBasic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBasic.Checked)
            {
                rbNormal.Checked = false;
                rbExecutive.Checked = false;
            }
        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNormal.Checked)
            {
                rbBasic.Checked = false;
                rbExecutive.Checked = false;
            }
        }
        private void rbExecutive_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExecutive.Checked)
            {
                rbBasic.Checked = false;
                rbNormal.Checked = false;
            }
        }

        private void btNouCotxe_Click(object sender, EventArgs e)
        {
            int random = new Random().Next(0, 4);

            string marca = "fiat";
            int tipus = 5;

            if (rbNormal.Checked)
            {
                tipus = 10;
            }
            else if (rbExecutive.Checked)
            {
                tipus = 15;
            }

            if (random == 0)
            {
                marca = "jeep";
            }
            else if (random == 1)
            {
                marca = "limousine";
            }
            else if (random == 2)
            {
                marca = "suv";
            }

            llCotxes.Add(new ClCotxe(marca, tipus, cotxeWidth, cotxeHeight));
            carregarLlistaCotxes();

        }
        public void carregarLlistaCotxes()
        {
            gbCotxes.Controls.Clear();

            int cotxesPerFila = gbCotxes.Size.Width / cotxeWidth;

            if (cotxesPerFila == 0) cotxesPerFila = 1; // evitar división entre 0

            for (int fila = 0; fila * cotxesPerFila < llCotxes.Count; fila++)
            {
                for (int col = 0; col < cotxesPerFila; col++)
                {
                    int index = fila * cotxesPerFila + col;
                    if (index >= llCotxes.Count)
                        break;

                    ClCotxe cotxe = llCotxes[index];
                    gbCotxes.Controls.Add(cotxe.obtenirImg());

                    int x = col * cotxeHeight;
                    int y = fila * cotxeHeight + 10;
                    cotxe.printarLlista(x, y);
                }
            }
        }
        public ClCotxe extreureCotxe()
        {
            ClCotxe extret = null;
            exclusio.WaitOne();
            try
            {
                if (llCotxes.Any())
                {
                    extret = llCotxes[0];
                    llCotxes.RemoveAt(0);
                    carregarLlistaCotxes();
                }
            }
            finally
            {
                exclusio.ReleaseMutex();
            }
            return extret;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Size moduloBase = new Size(150, 100);
            int altoDisponible = (ClientSize.Height / numeroLimpadors) - 15;
            int anchoDisponible = gbCotxes.Left - gbNouCotxe.Right - 15;
            int numeroColumnas = 1;

            while (altoDisponible < 60)
            {
                anchoDisponible /= 2;
                altoDisponible *= 2;
                numeroColumnas++;
            }

            int numeroFilas = numeroLimpadors / numeroColumnas;
            int origenX = gbNouCotxe.Right + 12;

            for (int index = 0; index < numeroFilas * numeroColumnas; index++)
            {
                int fila = index % numeroFilas;
                int columna = index / numeroFilas;
                int posX = origenX + (columna * anchoDisponible);
                int posY = 10 + (fila * altoDisponible);

                string nombreModulo = $"Lavadero_{index}";
                ClLimpiadors carWash = new ClLimpiadors(
                    new Size(anchoDisponible, altoDisponible),
                    new Point(posX, posY),
                    nombreModulo,
                    this
                );

                // Insertar en el formulario y guardarlo en la lista
                Controls.Add(carWash.obtenirGrup());
                llLimpadors.Add(carWash);
            }
        }
    }
}
