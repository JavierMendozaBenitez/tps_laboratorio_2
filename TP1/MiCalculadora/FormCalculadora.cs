using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");

            Limpiar();
           
        }

        public void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public static double Operar(String numero1, String numero2, string operador)
        {
            char c;

            double resultado;

            char.TryParse(operador, out c);

            Operando op1 = new Operando(numero1);
            Operando op2 = new Operando(numero2);

            resultado = Calculadora.Operar(op1, op2, c);

            return resultado;
        }

        List<string> listaOperaciones = new List<string>();

        private void btnOperar_Click(object sender, EventArgs e)
        {

            string resultado;
            string operacionHecha;

            if(cmbOperador.Text == "")
            {
                operacionHecha = txtNumero1.Text +" "+"+"+" " + txtNumero2.Text + " = " + (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text.ToString()));
            }
            else
            {
                operacionHecha = txtNumero1.Text +" "+ cmbOperador.Text +" "+ txtNumero2.Text + " = " + (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text.ToString()));
            }

            resultado = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text.ToString())).ToString();

            listaOperaciones.Add(operacionHecha);
            lstOperaciones.DataSource = null;
            lstOperaciones.DataSource = listaOperaciones;

            lblResultado.Text = resultado;

        }
      
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado;
            string resultadoBinario;

            resultado = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text.ToString())).ToString();

            Operando opBin1 = new Operando();


            resultadoBinario = opBin1.DecimalBinario(double.Parse(resultado));
            listaOperaciones.Add(resultadoBinario);
            lstOperaciones.DataSource = null;

            lstOperaciones.DataSource = listaOperaciones;

            lblResultado.Text = resultadoBinario;

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando opDec1 = new Operando();

            string resultadoDecimal;
            string ultimo = listaOperaciones.Last();


            resultadoDecimal = opDec1.BinarioDecimal(ultimo);

            listaOperaciones.Add(resultadoDecimal);
            lstOperaciones.DataSource = null;

            lstOperaciones.DataSource = listaOperaciones;

            lblResultado.Text = resultadoDecimal;

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
