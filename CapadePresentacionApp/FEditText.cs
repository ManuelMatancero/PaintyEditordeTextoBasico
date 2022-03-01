using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapadePresentacionApp
{
    public partial class FEditText : Form
    {
        Form1 form = new Form1();
        public FEditText()
        {
            InitializeComponent();
            this.CenterToScreen();
        
          
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Determina si hay texto seleccionado, si lo hay lo guarda en el Clipboard 
            if (textBox1.SelectedText != "")
            {
                Clipboard.SetDataObject(textBox1.SelectedText);
            }
               
           
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creo un objeto de tipo iData Que sera igual a la data que haya en el objeto Clipboard
            IDataObject iData = Clipboard.GetDataObject();

            //Si hay datos de tipo texto en ese objeto se agregara al Textbox del edit Text.
            if (iData.GetDataPresent(DataFormats.Text))
            {
                String texto = iData.GetData(DataFormats.Text).ToString();

                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, texto);

                //Coloca el cursor al final del texto que se ha pegado
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
            }
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Determina si hay texto seleccionado, si lo hay lo guarda en el Clipboard 
            if (textBox1.SelectedText != "")
            {
                Clipboard.SetDataObject(textBox1.SelectedText);
                //para cortar limpio el texto seleccionado
                textBox1.SelectedText = "";
            }
                
        }
        //Acciones para guardar archivo 
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Este objeto de tipo SaveFileDialog muestra una ventana donde se puede seleccionar la ubicacion 
            //donde se guardara el archivo y su nombre.
            using(SaveFileDialog guardarArchivo = new SaveFileDialog() {Filter= "Text Documents|*.txt", ValidateNames= true })
            {
                //una vez el usuario presione guardar se creara el archivo y a traves del objeto escribirArchivo 
                //se le dara por parametro la ubicacion y el nombre del archivo y procedera a escribir el texto que se encuentra
                //en el textBox en dicho archivo
                if (guardarArchivo.ShowDialog()==DialogResult.OK)
                {       
                    using(StreamWriter escribirArchivo = new StreamWriter(guardarArchivo.FileName))
                    {
                        escribirArchivo.WriteLine(textBox1.Text);
                        MessageBox.Show("Archivo Guardado, correctamente","Message", MessageBoxButtons.OK , MessageBoxIcon.Information);
                    }
                }
            }
        }
        //Acciones para Abrir Archivo
        private  void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {//Para abrir un archivo txt se crea un objeto de tipo OpenFileDialog
            //el cual abre una ventana donde se puede seleccionar el archivo que se desea abrir
            using (OpenFileDialog buscadorArchivo = new OpenFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true, Multiselect = false })
            {
                //Una vez seleccionado, el objeto de tipo streamReader recibira por parametro la ubicacion
                //y el nombre de ese archivo, lo localiza y el textBox1 pasa a ser igual a todo el texto que se encuentre en el archivo
                if (buscadorArchivo.ShowDialog() == DialogResult.OK)
                {
                    using(StreamReader archivoLeer = new StreamReader(buscadorArchivo.FileName))
                    {
                        textBox1.Text = archivoLeer.ReadToEnd();
                    }
                }
            }
        }
        //boton del menu para salir
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Close();
            
        }
        //Si este formulario se cierra se abre el formulario principal
        private void FEditText_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }

        //Metodo utilizado para modificar el tipo y tamano del texto
        private void letraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();

            DialogResult fontResult = fontDialog1.ShowDialog();

            if (fontResult == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }
    }
}
