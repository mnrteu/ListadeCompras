using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListadeCompras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Verifica se o campo de texto está vazio
            if (txbItem.Text == "")
            {
                MessageBox.Show("Digite um item antes de adicionar.", "Campo vazio",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Insere o conteúdo na lista
                lstCompras.Items.Add(txbItem.Text);
                txbItem.Text = "";
                txbItem.Clear();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Confirma se há elementos para limpar
            if (lstCompras.Items.Count == 0)
            {
                MessageBox.Show("A lista já está sem itens.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Remove todos os elementos da lista
                lstCompras.Items.Clear();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se algum item foi selecionado
            if (lstCompras.SelectedItem != null)
            {
                // Exclui o item marcado
                lstCompras.Items.Remove(lstCompras.SelectedItem);
            }
            else
            {
                MessageBox.Show("Escolha um item da lista para remover.", "Atenção");
            }
        }

        private void lstCompras_DoubleClick(object sender, EventArgs e)
        {
            // Garante que um item esteja selecionado
            if (lstCompras.SelectedIndex != -1)
            {
                DialogResult confirmacao = MessageBox.Show(
                    "Deseja realmente apagar este item da lista?",
                    "Confirmar remoção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (confirmacao == DialogResult.Yes)
                {
                    lstCompras.Items.RemoveAt(lstCompras.SelectedIndex);
                }
                else
                {   
                    lstCompras.SelectedIndex = -1;
                }
            }
        }

        private void txbItem_KeyDown(object sender, KeyEventArgs e)
        {
            // Permite adicionar pressionando Enter
            if (e.KeyCode == Keys.Enter)
            {
                btnAdicionar.PerformClick();
            }
        }
    }
}
