using Microsoft.Win32;
using System;
using System.IO;

namespace GSenha.BLL
{
    public class Senhas
    {
        //Método de gerar senhas aleatórias.
        public string Gerar(bool maiusculas, bool minusculas, bool numericas, bool especiais, string comprimentoDasSenhas)
        {
            //Ele inicia limpando as variáveis.
            string sequenciaDeCaracteres = String.Empty;
            string senha = String.Empty;

            //Depois cria a sequencia de caracteres de acordo com o que foi definido pelo usuário (e passado pelos parâmetros)
            if (maiusculas)
            {
                sequenciaDeCaracteres += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            if (minusculas)
            {
                sequenciaDeCaracteres += "abcdefghijklmnopqrstuvwxyz";
            }

            if (numericas)
            {
                sequenciaDeCaracteres += "0123456789";
            }

            if (especiais)
            {
                sequenciaDeCaracteres += "!@#$%&()_.";
            }

            //Então ele pega o primeiro caractere...
            for (int i = 0; i < Convert.ToInt32(comprimentoDasSenhas); i++)
            {
                
                System.Threading.Thread.Sleep(1);
                senha += sequenciaDeCaracteres[new Random(DateTime.Now.Millisecond).Next(0, sequenciaDeCaracteres.Length)].ToString();
            }

            return senha;
        }

        //Método de exportar, trazendo como parâmentro as senhas geradas.
        public void Exportar(string senhasGeradas)
        {
            //Exibe uma caixa de diálogo do tipo 'Salvar'...
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                //...que permite salvar arquivos com extensão '.txt'.
                Filter = "Arquivo de texto (*.txt)|*.txt",
                //Opcionalmente podemos definir o diretório padrão para gravar o arquivo.
                InitialDirectory = @"%userprofile%\Desktop\"
            };

            //Se o usuário clicar em salvar...
            if (saveFileDialog.ShowDialog() == true)
            {
                //...as senhas geradas serão armazenadas no arquivo .txt.
                File.WriteAllText(saveFileDialog.FileName, senhasGeradas);
            }
        }
    }
}
