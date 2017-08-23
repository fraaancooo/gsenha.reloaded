using System;
using System.Reflection;

namespace GSenha.BLL
{
    public class Negocio
    {

        /// <summary>
        /// Captura e retorna o nome do aplicativo.
        /// </summary>
        /// <returns></returns>
        public string GetNomeDoProduto()
        {
            try
            {
                return Assembly.GetEntryAssembly().GetName().Name;
            }
            catch (Exception)
            {
                return "[Não suportado em modo debug]";
            }
        }

        /// <summary>
        /// Captura e retorna a versão do aplicativo.
        /// </summary>
        /// <returns></returns>
        public object GetVersao()
        {
            try
            {
                Version versao = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                return string.Format("Versão {0}.{1}.{2} r{3}", versao.Major, versao.Minor, versao.Build, versao.Revision);
            }
            catch (Exception)
            {
                return "[Não suportado em modo debug]";
            }
        }

        /// <summary>
        /// Captura o arquivo de licença.
        /// </summary>
        /// <returns></returns>
        public string GetArquivoDeLicensa()
        {
            try
            {
                return Properties.Resources.License;
            }
            catch (Exception ex)
            {
                return "Não foi possível carregar o arquivo. Erro: " + ex.Message;
            }
        }
    }
}
