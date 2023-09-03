using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraWindows
{
    public partial class Calculadora : Form
    {
        double numero1 = 0, numero2 = 0;
        char operador;
        public Calculadora()
        {
            InitializeComponent();
        }
        private void AgregarNumero(object sender, EventArgs e)
        {
            var botao = ((Button)sender);
            if (txtResultado.Text == "0")
            {
                txtResultado.Text = "";
            }
            txtResultado.Text += botao.Text;
           
        }
        private void BtnIgual_Click(object sender, EventArgs e)
        {
            numero2 = Convert.ToDouble(txtResultado.Text);
            if(operador == '+')
            {
                txtResultado.Text = (numero1 + numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if(operador == '-')
            {
                txtResultado.Text = (numero1 - numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado);
            }
            else if(operador == '÷')
            {
                if (txtResultado.Text != "0")
                {
                    txtResultado.Text = (numero1 / numero2).ToString();
                    numero1 = Convert.ToDouble(txtResultado.Text);
                }
            }
            else if (operador == 'x')
            {
                txtResultado.Text = (numero1 * numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (operador == '%')
            {
                double resultado = (numero1 * numero2/100);
                txtResultado.Text = resultado.ToString();
                numero1 = resultado;

            }
        }
        /*
private void btn0_Click(object sender, EventArgs e)
{
//variável do botão
var botao = ((Button)sender);
AgregarNumero(botao.Text);
}
//podemos chamar esse mesmo codigo no evento do botao no formulário, assim, economizamos o código. Evento AgregarNumero();
// para isso, colocamos o "object sender, KeyPressEventArgs e" dentro do método AgregarNumero();
*/
        private void ClickOperador(object sender, EventArgs e)
        {
            var botao = ((Button)sender);
            numero1 = Convert.ToDouble(txtResultado.Text);
            operador = Convert.ToChar(botao.Tag);

            if (operador == '√')
            {
                numero1 =  Math.Sqrt(numero1);
                txtResultado.Text = numero1.ToString();
            }
            else if (operador == '²')
            {
                numero1 = Math.Pow(numero1, 2);
                txtResultado.Text = numero1.ToString();
            } 
            else{txtResultado.Text = "0";}
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            numero1 = 0;
            numero2= 0;
            operador = '\0';
            txtResultado.Text = "0";
        }
        private void btnLimparTudo_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }
        private void btnVirgula_Click(object sender, EventArgs e)
        {
          //se nao tiver no txtResultado ","
            if (!txtResultado.Text.Contains(",")) 
            {
                txtResultado.Text += ","; 
            }
        }
        private void btnMaisMenos_Click(object sender, EventArgs e)
        {
            numero1=Convert.ToDouble(txtResultado.Text);
            numero1 *= -1; //Faz o número ficar negativo ou positivo se ja estiver negativo :D
            txtResultado.Text = numero1.ToString();
        }
        private void btnApagar_Click(object sender, EventArgs e)
        {
            if(txtResultado.Text.Length > 1) 
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
            else { txtResultado.Text = "0"; }
        }

    }
}
