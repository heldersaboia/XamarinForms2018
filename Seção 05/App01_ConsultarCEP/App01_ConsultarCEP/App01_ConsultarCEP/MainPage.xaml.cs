using App01_ConsultarCEP.Servico;
using System;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();

            if (IsValidCEP(cep))
            {
                try
                {
                    var endereco = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (endereco != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0}, {1} {2} - {3}", endereco.logradouro, endereco.bairro, endereco.localidade, endereco.uf);
                    }
                    else
                    {
                        DisplayAlert("CEP não encontrado!", "Endereço não encontrado para o CEP " + cep, "OK");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }

        }

        private bool IsValidCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8 || cep.Length == 0 || !int.TryParse(cep, out int novoCEP))
            {
                DisplayAlert("CEP Inválido!", "O CEP deve conter 8 dígitos numéricos.", "OK");

                valido = false;
            }

            return valido;
        }
    }
}
