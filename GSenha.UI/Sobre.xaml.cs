using System;
using System.Reflection;
using System.Windows;
using GSenha.BLL;

namespace GSenha.UI
{
    public partial class Sobre : Window
    {
        Negocio negocio = new Negocio();

        public Sobre()
        {
            InitializeComponent();

            CapturaNome();
            CapturaVersao();
            CarregaLicensa();
        }

        private void CapturaNome()
        {
            try
            {
                label_NomeAplicativo.Content = negocio.GetNomeDoProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Nome do Produto");
            }
        }

        private void CapturaVersao()
        {
            try
            {
                label_Versao.Content = negocio.GetVersao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Versão do Arquivo");
            }
        }

       private void CarregaLicensa()
        {
            try
            {
                textbox_LicenseContexto.Text = negocio.GetArquivoDeLicensa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Arquivo de Licença");
            }
        }

    }
}
