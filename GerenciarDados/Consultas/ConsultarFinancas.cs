using AcessarDadosDoBanco.ContextoDeDados;
using AcessarDadosDoBanco.Modelos;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Consultas
{
    public static class ConsultarFinancas
    {
        public static string _nomeDoMetodo = string.Empty;

        public static List<Poupanca> ObterListaDeFinancas()
        {
            try
            {
                using (var context = new Contexto())
                {
                    List<Poupanca> listaDePoupanca = [];
                    var listaCombinada = context.TPoupanca.Select(d => new
                    {
                        d.Id, d.NomeDaCategoria, d.NomeDaSubCategoria, d.Valor, d.Tipo, d.Data, d.Mes, d.Ano

                    }).Union(context.TInvestimento.Select(p => new
                    {
                        p.Id, p.NomeDaCategoria, p.NomeDaSubCategoria, p.Valor, p.Tipo, p.Data, p.Mes, p.Ano

                    })).ToList();
                    foreach (var item in listaCombinada)
                    {
                        Poupanca poupanca = new()
                        {
                            Id = item.Id,
                            NomeDaCategoria = item.NomeDaCategoria,
                            NomeDaSubCategoria = item.NomeDaSubCategoria,
                            Valor = item.Valor,
                            Tipo = item.Tipo,
                            Data = item.Data,
                            Mes = item.Mes,
                            Ano = item.Ano,
                        };
                        listaDePoupanca.Add(poupanca);
                    }
                    return [.. listaDePoupanca.OrderByDescending(p => p.Id).ToList()];
                }
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterListaDeFinancas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarFinancasGeraisDeTodosOsAnos()
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TInvestimento.Where(d => d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TInvestimento.Where(d => d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TInvestimento.Where(d => d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TInvestimento.Where(d => d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TInvestimento.Where(d => d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TInvestimento.Where(d => d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TInvestimento.Where(d => d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TInvestimento.Where(d => d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TInvestimento.Where(d => d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TInvestimento.Where(d => d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TInvestimento.Where(d => d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TInvestimento.Where(d => d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TInvestimento.Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarFinancasGeraisDeTodosOsAnos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoria(string nomeDaCategoria)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoria";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaESubCategoria(string nomeDaCategoria, string nomeDaSubCategoria)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Mairo").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria)
                    .Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria)
                    .Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaESubCategoria";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaSubCategoriaEMes(string nomeDaCategoria, string nomeDaSubCategoria, string selecionarMes)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                              contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                              && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                              contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                              && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Mes == selecionarMes).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaSubCategoriaEMes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaSubCategoriaEAno(string nomeDaCategoria, string nomeDaSubCategoria, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaSubCategoriaEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaSubCategoriaMesEAno(string nomeDaCategoria, string nomeDaSubCategoria, string selecionarMes, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria 
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaSubCategoriaMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaEMes(string nomeDaCategoria, string selecionarMes)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaEMes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaEAno(string nomeDaCategoria, int ano)
        {

            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Ano == ano).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaMesEAno(string nomeDaCategoria, string selecionarMes, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TInvestimento.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorMes(string selecionarMes)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorMes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorMesEAno(string selecionarMes, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                           contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                           contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                                break;

                    case "Junho":
                        meses.Junho =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                        contexto.TInvestimento.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                        contexto.TPoupanca.Where(p => p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorAno(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Janeiro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Fevereiro =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Fevereiro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Marco =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Março" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Abril =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Abril" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Maio =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Maio" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Junho =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Junho" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Julho =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Julho" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Agosto =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Agôsto" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Setembro =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Setembro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Outubro =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Outubro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Novembro =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Novembro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Dezembro =
                    contexto.TInvestimento.Where(d => d.Ano == ano && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Mes == "Dezembro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.TotalAno =
                    contexto.TInvestimento.Where(d => d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

    }
}
