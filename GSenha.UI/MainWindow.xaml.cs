using GSenha.BLL;
using System;
using System.Windows;

namespace GSenha.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Senhas senhas = new Senhas();

        private void Button_Gerar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!checkbox_Maiusculas.IsChecked.Value && !checkbox_Minusculas.IsChecked.Value && !checkbox_Numeros.IsChecked.Value && !checkbox_Especiais.IsChecked.Value)
                {
                    MessageBox.Show("Marque pelo menos uma das opções de senha.", "Opções de Senha", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    textbox_SenhasGeradas.Text = String.Empty;

                    for (int i = 0; i < Convert.ToInt32(textbox_NumeroDeSenhas.Text); i++)
                    {
                        textbox_SenhasGeradas.Text += senhas.Gerar(checkbox_Maiusculas.IsChecked.Value, checkbox_Minusculas.IsChecked.Value, checkbox_Numeros.IsChecked.Value, checkbox_Especiais.IsChecked.Value, textbox_ComprimentoDasSenhas.Text);
                        textbox_SenhasGeradas.Text += Environment.NewLine;
                    }

                    button_Exportar.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Falha na tentativa de gerar senha(s)");
            }
        }

        private void Button_Exportar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                senhas.Exportar(textbox_SenhasGeradas.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message,"Erro ao exportar para arquivo.");
            }
        }

        private void Button_Sobre_Click(object sender, RoutedEventArgs e)
        {
            Sobre sobre = new Sobre()
            {
                Owner = this
            };
            sobre.ShowDialog();
        }
    }
}
