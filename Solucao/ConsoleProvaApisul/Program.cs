using ConsoleProvaApisul.DAO;
using ConsoleProvaApisul.Service;
using System;
using System.Linq;

namespace ProvaAdmissionalCSharpApisul
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("---------------------------------------------------------");
            System.Console.WriteLine("Lendo Dados Histórico dos Elevadores");
            System.Console.WriteLine("---------------------------------------------------------");

            DestinoElevadorDAO dao = new DestinoElevadorDAO();
            var lista = dao.getAll();

            if (lista != null)
            {
                lista = lista.OrderBy(x => x.andar).ToList();
                foreach (var l in lista)
                {
                    Console.WriteLine($"- Andar: {l.andar} - Elevador: {l.elevador} - Turno: {l.turno}.");
                }
            }
            else
            {
                Console.WriteLine("Arquivo de histórico de elevador sem dados.");
            }

            System.Console.WriteLine("---------------------------------------------------------");

            //Serviço de estatíticas
            ElevadorService serv = new ElevadorService(lista);

            System.Console.WriteLine("=========================================================");
            System.Console.WriteLine("Andar menos utilizado");
            System.Console.WriteLine("---------------------------------------------------------");
            var aMenos = serv.andarMenosUtilizado();
            foreach(var am in aMenos)
            {
                System.Console.WriteLine($"andar: {am}");
            }

            System.Console.WriteLine("=========================================================");
            System.Console.WriteLine("Elevador mais Frequentado");
            System.Console.WriteLine("---------------------------------------------------------");
            var eMaisFerq = serv.elevadorMaisFrequentado();
            foreach (var am in eMaisFerq)
            {
                System.Console.WriteLine($"elevador: {am}");
            }

            System.Console.WriteLine("=========================================================");
            System.Console.WriteLine("Elevador menos Frequentado");
            System.Console.WriteLine("---------------------------------------------------------");
            var eMenosFreq = serv.elevadorMenosFrequentado();
            foreach (var am in eMenosFreq)
            {
                System.Console.WriteLine($"elevador: {am}");
            }

            System.Console.WriteLine("=========================================================");
            var Valor = serv.percentualDeUsoElevadorA();
            System.Console.WriteLine($"Precentual de uso do Elevador A : {Valor}");
            System.Console.WriteLine("---------------------------------------------------------");

            System.Console.WriteLine("=========================================================");
            Valor = serv.percentualDeUsoElevadorB();
            System.Console.WriteLine($"Precentual de uso do Elevador B : {Valor}");
            System.Console.WriteLine("---------------------------------------------------------");

            System.Console.WriteLine("=========================================================");
            Valor = serv.percentualDeUsoElevadorC();
            System.Console.WriteLine($"Precentual de uso do Elevador C : {Valor}");
            System.Console.WriteLine("---------------------------------------------------------");

            System.Console.WriteLine("=========================================================");
            Valor = serv.percentualDeUsoElevadorD();
            System.Console.WriteLine($"Precentual de uso do Elevador D : {Valor}");
            System.Console.WriteLine("---------------------------------------------------------");

            System.Console.WriteLine("=========================================================");
            Valor = serv.percentualDeUsoElevadorE();
            System.Console.WriteLine($"Precentual de uso do Elevador E : {Valor}");
            System.Console.WriteLine("---------------------------------------------------------");

            System.Console.WriteLine("=========================================================");
            System.Console.WriteLine("Periodo Maior Fluxo Elevador Mais Frequentado");
            System.Console.WriteLine("---------------------------------------------------------");
            var ePeriodoMaior = serv.periodoMaiorFluxoElevadorMaisFrequentado();
            foreach (var am in ePeriodoMaior)
            {
                System.Console.WriteLine($"periodo: {am}");
            }

            System.Console.WriteLine("=========================================================");
            System.Console.WriteLine("Periodo Maior Utilização do Conjunto de Elevadores");
            System.Console.WriteLine("---------------------------------------------------------");
            var ePeriodoMaiorUtil = serv.periodoMaiorUtilizacaoConjuntoElevadores();
            foreach (var am in ePeriodoMaiorUtil)
            {
                System.Console.WriteLine($"periodo: {am}");
            }

            System.Console.WriteLine("=========================================================");
            System.Console.WriteLine("Periodo Menor Fluxo Elevador Menos Frequentados");
            System.Console.WriteLine("---------------------------------------------------------");
            var ePeriodoFluxoEleMenosFre = serv.periodoMenorFluxoElevadorMenosFrequentado();
            foreach (var am in ePeriodoFluxoEleMenosFre)
            {
                System.Console.WriteLine($"periodo: {am}");
            }


            System.Console.WriteLine("=========================================================");
            System.Console.WriteLine("=========================================================");

        }
    }
}
