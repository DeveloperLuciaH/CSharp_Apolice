using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prj_ApoliceLucia
{
    public partial class FrmApolice : Form
    {
        char sexo;
        int idade;
        double valorAutomovel;
        double valorApolice;

        public FrmApolice()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FrmApolice_Load(object sender, EventArgs e)
        {

        }

        private void lstDetalhamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbParcela_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstDetalhamento.Items.Clear();

            int parcela = Convert.ToInt32(cmbParcela.Text);

            for(int x = 1; x <= parcela; x++)
            {
                lstDetalhamento.Items.Add(x + " - " + "Venc. "
                + DateTime.Now.AddMonths(x - 1).ToString("dd/MM/yyyy") + " =>" + (valorApolice / parcela).ToString("c2"));
            }

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    throw new Exception("Nome Inválido");
                }
                if (string.IsNullOrEmpty(cmbMarca.Text))
                {
                    throw new Exception("Marca Inválida");
                }

                lstDetalhamento.Items.Clear();

                //recuperar valores da tela
                idade = Convert.ToInt16(txtIdade.Text);
                valorAutomovel = Convert.ToDouble(txtValor.Text);
                if (rdMasculino.Checked)
                    sexo = 'M';
                else
                    sexo = 'F';

                //calcular valor da apólice
                double valorApolice = 0;
                if (sexo == 'M' && idade <= 25)
                    valorApolice = valorAutomovel * 0.1;
                if (sexo == 'M' && idade > 25)
                    valorApolice = valorAutomovel * 0.05;
                if (sexo == 'F')
                    valorApolice = valorAutomovel * 0.02;

                // mostrar na tela o resultado
                this.valorApolice = valorApolice;
                lblValorPagar.Text = valorApolice.ToString("c2");
                grPagamento.Visible = true;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Limite da variável estourou - " + ex.Message);
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Formato incorreto -" + ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Genérico - " + ex.Message);
            }
            finally
            {
                if (string.IsNullOrEmpty(lblValorPagar.Text))
                    lblValorPagar.Text = "0,00";
            }

        }


        
    }
}
