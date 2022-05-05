using ConsoleProvaApisul.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleProvaApisul.DAO
{
    public class DestinoElevadorDAO
    {

        public IList<DestinoElevador> getAll()
        {
            IList<DestinoElevador> retorno = new List<DestinoElevador>();

            string diretorioDataSet = ConfigurationManager.AppSettings["dir"].Replace('/', Path.DirectorySeparatorChar);
            string arquivoDataSet = ConfigurationManager.AppSettings["file"].Replace('/', Path.DirectorySeparatorChar);

            string fileDS = System.IO.Path.Combine(diretorioDataSet, arquivoDataSet);

            DirectoryInfo directoryFiles = new DirectoryInfo(diretorioDataSet);
            FileInfo fileDataSet = new FileInfo(fileDS);

            if (directoryFiles.Exists && fileDataSet.Exists)
            {
                LerArquivoJsonHistorico(fileDataSet.FullName, ref retorno);
            }

            return retorno;
        }

        public void LerArquivoJsonHistorico(string pathFileName, ref IList<DestinoElevador> historico)
        {
            string jsonString = File.ReadAllText(pathFileName);
            IList<DestinoElevador> destinos = JsonSerializer.Deserialize<IList<DestinoElevador>>(jsonString)!;
            if(destinos != null && destinos.Count > 0)
            {
                historico = destinos;
            }
        }

    }
}
