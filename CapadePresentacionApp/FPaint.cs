using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapadePresentacionApp
{
    public partial class FPaint : Form
    {
       

        public FPaint()
        {
            InitializeComponent();
            //Metodo que centraliza la pantalla
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Objeto que pone en funcionamiento la paleta de colores
            ColorDialog colorDialog1 = new ColorDialog();
            //si se selecciono un color en la paleta de colores se guardara
            //en el objeto y ese color se agregara al fondo del formulario 
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                
            }
        }
        //Metodo que se ejecula al cerrar el formulario
        private void FPaint_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Form1 form = new Form1();
            form.Show();
               
            
        }
    }
}
