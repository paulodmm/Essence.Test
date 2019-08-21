using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Essence.Test.FormUI
{
    public partial class Form1 : Form
    {
        APIService service;

        public Form1()
        {
            InitializeComponent();
            service = new APIService();
            AtualizarAmigos();
        }

        private void AtualizarAmigos()
        {
            lbxListaAmigos.Items.Clear();

            var amigos = service.GetAll();
            foreach (var amigo in amigos)
            {
                string item = string.Format("id: {0} - {1} Lat:{2} Long: {3}"
                    , amigo.AmigoId.ToString()
                    , amigo.Nome
                    , amigo.Latitude
                    , amigo.Longitude);
                lbxListaAmigos.Items.Add(item);
            }
        }

        private void AtualizarAmigosProximos(int id)
        {
            lbxAmigosProximos.Items.Clear();

            var amigos = service.AmigosProximos(id);
            foreach (var amigo in amigos)
            {
                string item = string.Format("id: {0} - {1} Distância:{2}"
                    , amigo.AmigoId.ToString()
                    , amigo.Nome
                    , amigo.Distancia);
                lbxAmigosProximos.Items.Add(item);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAtualiarLista_Click(object sender, EventArgs e)
        {
            AtualizarAmigos();
        }

        private void btnExibirProximos_Click(object sender, EventArgs e)
        {
            var itemSelecionado = lbxListaAmigos.SelectedItem;
            string pattern = @"id\: (\d+) \-(.*)";
            int id = Convert.ToInt32(Regex.Replace(itemSelecionado.ToString(), pattern, "$1"));

            AtualizarAmigosProximos(id);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            double latitude = 0;
            double longitude = 0;

            if (!string.IsNullOrEmpty(txtNome.Text.Trim())
                && double.TryParse(txtLatitude.Text, out latitude) 
                && double.TryParse(txtLongitude.Text, out longitude))
            {
                AmigoDTO amigo = new AmigoDTO();
                amigo.Nome = txtNome.Text;
                amigo.Latitude = Convert.ToDouble(txtLatitude.Text);
                amigo.Longitude = Convert.ToDouble(txtLongitude.Text);

                service.Add(amigo);

                AtualizarAmigos();
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("Projeto Teste", "Preencher o nome, a latitude e longitede devem ser do tipo decimal.");
            }
        }
    }
}
