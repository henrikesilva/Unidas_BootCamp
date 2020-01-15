using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02
{
    public partial class lab02Form : Form
    {
        public lab02Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valorCompra = 0;
                decimal valorPago = 0;
                decimal resto = 0;

                valorCompra = Convert.ToDecimal(textBox1.Text);
                valorPago = Convert.ToDecimal(textBox2.Text);

                resto = valorPago - valorCompra;

                label4.Text = resto.ToString("C2");

                int moeda1Real = (int)(resto / 1);
                resto = resto % 1;
                moeda100.Text = moeda1Real.ToString();

                int moeda50Centavos = (int)(resto / 0.5m);
                resto = resto % 0.5m;
                moeda50.Text = moeda50Centavos.ToString();

                int moeda25Centavos = (int)(resto / 0.25m);
                resto = resto % 0.25m;
                moeda25.Text = moeda25Centavos.ToString();

                int moeda10Centavos = (int)(resto / 0.1m);
                resto = resto % 0.1m;
                moeda10.Text = moeda10Centavos.ToString();

                int moeda5Centavos = (int)(resto / 0.05m);
                resto = resto % 0.05m;
                moeda05.Text = moeda5Centavos.ToString();

                int moeda1Centavo = (int)(resto / 0.01m);
                resto = resto % 0.01m;
                moeda01.Text = moeda1Centavo.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Favor digitar apenas numeros");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Numero Informado extenso demais para calculo");
            }
            finally
            {
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }
    }
}
