using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace CarWash_01
{
    public class ClCotxe
    {
        int qualitat; // les 3 qualitats del cotxe
        Bitmap Cotxe;
        Bitmap Limpador;
        bool estado = false; // estat del cotxe: net o brut
        PictureBox imatgeCotxe = new PictureBox(); // la imatge del 

        // cotxe a mostrar
        public ClCotxe(string marca, int xqualitat, int ample, int alt)
        {
            qualitat = xqualitat;

            PropertyInfo[] propietats = typeof(Properties.Resources).GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            
            foreach (PropertyInfo p in propietats)
            {
                if (p.PropertyType.Name == "Bitmap")
                {
                    if (p.Name.StartsWith("Cleaning_" + marca))
                    {
                        Limpador = new Bitmap(((Bitmap)p.GetValue(null, null)));
                    }
                    else if (p.Name.StartsWith(marca))
                    {
                        Cotxe = new Bitmap(((Bitmap)p.GetValue(null, null)));
                    }

                }
            }
            imatgeCotxe.Image = Cotxe;
            imatgeCotxe.SizeMode = PictureBoxSizeMode.Zoom;
            imatgeCotxe.Size = new Size(ample, alt);
        }

        internal Image agafarImg()
        {
            if (estado == true) return Limpador;
            return Cotxe;
        }

        internal int agafarTipos()
        {
            return qualitat;
        }

        internal void cambiarImg()
        {
            if (estado == true)
            {
                imatgeCotxe.Image = Cotxe;
            }
            else
            {
                imatgeCotxe.Image = Limpador;
            }
            estado = !estado;
        }

        internal Control obtenirImg()
        {
            return imatgeCotxe;
        }

        internal void printarLlista(int x, int y)
        {
            imatgeCotxe.Location = new Point(x, y);
            imatgeCotxe.Show();
        }
    }
}
