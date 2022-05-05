using ConsoleProvaApisul.Model;
using ProvaAdmissionalCSharpApisul.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleProvaApisul.Service
{
    public class ElevadorService : IElevadorService
    {
        IList<DestinoElevador> _historico = null;
        public ElevadorService(IList<DestinoElevador> historico)
        {
            this._historico = historico;
        }

        public List<int> andarMenosUtilizado()
        {
            var porAndar = this._historico.OrderBy(x => x.andar).ToList();
            var ret = porAndar
                .GroupBy(a => a.andar)
                .Select(x => new histogramaAndar
                {
                    andar = x.First().andar,
                    contador = x.Sum(b => 1)
                }).ToList();

            ret = ret.OrderBy(a => a.contador).ToList();

            var retorno = ret.Select(y => y.andar).ToList();

            return retorno;
        }

        public List<char> elevadorMaisFrequentado()
        {
            var porElevador = this._historico.OrderBy(x => x.elevador).ToList();
            var ret = porElevador
                .GroupBy(a => a.elevador)
                .Select(x => new histogramaElevador
                {
                    elevador = x.First().elevador.Trim()[0],
                    contador = x.Sum(b => 1)
                }).ToList();

            ret = ret.OrderBy(a => a.contador).ToList();

            var retorno = ret.Select(y => y.elevador).ToList();

            return retorno;
        }

        public List<char> elevadorMenosFrequentado()
        {
            var porElevador = this._historico.OrderBy(x => x.elevador).ToList();
            var ret = porElevador
                .GroupBy(a => a.elevador)
                .Select(x => new histogramaElevador
                {
                    elevador = x.First().elevador.Trim()[0],
                    contador = x.Sum(b => 1)
                }).ToList();

            ret = ret.OrderByDescending(a => a.contador).ToList();

            var retorno = ret.Select(y => y.elevador).ToList();

            return retorno;
        }

        public float percentualDeUsoElevadorA()
        {
            int total = this._historico.Count;
            var porElevador = this._historico
                .Where(y => y.elevador.ToUpperInvariant().Equals("A"))
                .OrderBy(x => x.andar).ToList();
            int totalUsoElevador = porElevador.Count;

            float percentualDeUso = totalUsoElevador / total;

            return percentualDeUso;
        }

        public float percentualDeUsoElevadorB()
        {
            int total = this._historico.Count;
            var porElevador = this._historico
                .Where(y => y.elevador.ToUpperInvariant().Equals("B"))
                .OrderBy(x => x.andar).ToList();
            int totalUsoElevador = porElevador.Count;

            float percentualDeUso = totalUsoElevador / total;

            return percentualDeUso;
        }

        public float percentualDeUsoElevadorC()
        {
            int total = this._historico.Count;
            var porElevador = this._historico
                .Where(y => y.elevador.ToUpperInvariant().Equals("C"))
                .OrderBy(x => x.andar).ToList();
            int totalUsoElevador = porElevador.Count;

            float percentualDeUso = totalUsoElevador / total;

            return percentualDeUso;
        }

        public float percentualDeUsoElevadorD()
        {
            int total = this._historico.Count;
            var porElevador = this._historico
                .Where(y => y.elevador.ToUpperInvariant().Equals("D"))
                .OrderBy(x => x.andar).ToList();
            int totalUsoElevador = porElevador.Count;

            float percentualDeUso = totalUsoElevador / total;

            return percentualDeUso;
        }

        public float percentualDeUsoElevadorE()
        {
            int total = this._historico.Count;
            var porElevador = this._historico
                .Where(y => y.elevador.ToUpperInvariant().Equals("E"))
                .OrderBy(x => x.andar).ToList();
            int totalUsoElevador = porElevador.Count;

            float percentualDeUso = totalUsoElevador / total;

            return percentualDeUso;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            List<char> retorno = new List<char>();

            var porTurno = this._historico.OrderBy(x => x.turno).ToList();

            var retT = porTurno
                .GroupBy(a => a.elevador)
                .Select(x => new histogramaTurno
                {
                    turno = x.First().turno.Trim()[0],
                    contador = x.Sum(b => 1)
                }).ToList();
            
            retT = retT.OrderBy(a => a.contador).ToList();

            var rT = retT.Select(y => y.turno).ToList();

            var TurnoMaior = rT.FirstOrDefault();

            if (TurnoMaior != null && TurnoMaior.ToString().Length > 0)
            {
                var porElevador = this._historico.OrderBy(x => x.elevador).ToList();
                var ret = porElevador
                    .Where(k => k.turno.Equals(TurnoMaior.ToString().Trim().ToUpperInvariant()))
                    .GroupBy(a => a.elevador)
                    .Select(x => new histogramaElevadorTurno
                    {
                        elevador = x.First().elevador.Trim()[0],
                        turno = x.First().turno.Trim()[0],
                        contador = x.Sum(b => 1)
                    }).ToList();

                ret = ret.OrderBy(a => a.contador).ToList();

                retorno = ret.Select(y => y.elevador).ToList();
            }

            return retorno;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var porTurno = this._historico.OrderBy(x => x.turno).ToList();

            var retT = porTurno
                .GroupBy(a => a.elevador)
                .Select(x => new histogramaTurno
                {
                    turno = x.First().turno.Trim()[0],
                    contador = x.Sum(b => 1)
                }).ToList();

            retT = retT.OrderBy(a => a.contador).ToList();

            var rT = retT.Select(y => y.turno).ToList();

            return rT;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            List<char> retorno = new List<char>();

            var porTurno = this._historico.OrderBy(x => x.turno).ToList();

            var retT = porTurno
                .GroupBy(a => a.elevador)
                .Select(x => new histogramaTurno
                {
                    turno = x.First().turno.Trim()[0],
                    contador = x.Sum(b => 1)
                }).ToList();

            retT = retT.OrderByDescending(a => a.contador).ToList();

            var rT = retT.Select(y => y.turno).ToList();

            var TurnoMaior = rT.FirstOrDefault();

            if (TurnoMaior != null && TurnoMaior.ToString().Length > 0)
            {
                var porElevador = this._historico.OrderBy(x => x.elevador).ToList();
                var ret = porElevador
                    .Where(k => k.turno.Equals(TurnoMaior.ToString().Trim().ToUpperInvariant()))
                    .GroupBy(a => a.elevador)
                    .Select(x => new histogramaElevadorTurno
                    {
                        elevador = x.First().elevador.Trim()[0],
                        turno = x.First().turno.Trim()[0],
                        contador = x.Sum(b => 1)
                    }).ToList();

                ret = ret.OrderBy(a => a.contador).ToList();

                retorno = ret.Select(y => y.elevador).ToList();
            }

            return retorno;
        }
    }


    public class histogramaAndar 
    {
        public int andar { get; set; }
        public int contador { get; set; }
    }


    public class histogramaElevador
    {
        public char elevador { get; set; }
        public int contador { get; set; }
    }

    public class histogramaElevadorTurno
    {
        public char elevador { get; set; }
        public char turno { get; set; }
        public int contador { get; set; }
    }

    public class histogramaTurno
    {
        public char turno { get; set; }
        public int contador { get; set; }
    }


}
