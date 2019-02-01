using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace leer_exel
{
    public partial class Form1 : Form
    {

        Microsoft.Office.Interop.Excel.Application _exelapplication;
        Workbook workbook;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnabrir_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                string name = openFileDialog1.FileName;//se guarda el nombre la ruta del archivo
                _exelapplication = new Microsoft.Office.Interop.Excel.Application(); //creo un objeto de titpo aplicacion
                workbook = _exelapplication.Workbooks.Open(name); //un libro de exel
                lblnombre.Text = name;
                //MessageBox.Show("OK !");
            }else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("cancel !");
            }
        }

        private void btnleer_Click(object sender, EventArgs e)
        {
            int hoja = Convert.ToInt32(textBox1.Text);
            int fila = Convert.ToInt32(textBox2.Text);
            int col = Convert.ToInt32(textBox3.Text);

            Worksheet worksheet = (Worksheet)workbook.Sheets[hoja];

            string value = (((Range)worksheet.Cells[fila,col]).Value2).ToString();

            textBox4.Text = value;
        }
    }
}
