using AcessarBancoDados.ContextoDeDados;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Relatorios
{
    public static class RelatorioDeDespesas
    {
        private static string _nomeDoMetodo = string.Empty;

        public static ListaDeMeses RelatorioDeDespesasGerais(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Fevereiro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Março" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Abril" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Maio" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Junho" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Julho" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Agôsto" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Setembro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Outubro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Novembro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Dezembro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa").Select(d => d.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDeDespesasGerais";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDeDespesasNormais(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Fevereiro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Fevereiro" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Marco =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Março" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Março" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Abril =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Abril" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Abril" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Maio =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Maio" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Maio" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Junho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Junho" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Junho" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Julho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Julho" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Julho" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Agosto =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Agôsto" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Agôsto" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Setembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Setembro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Setembro" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Outubro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Outubro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Outubro" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Novembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Novembro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Novembro" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Dezembro" && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Dezembro" && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa").Select(d => d.Valor).Sum() -
                     contexto.TDespesa.Where(d => d.Ano == ano && new[] { "Caridade", "Despesas Extras", "Informática",
                        "Despesas da Neusa" }.Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;

            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDeDespesasNormais";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDeDespesasExtras(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Fevereiro" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Marco =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Março" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Abril =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Abril" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Maio =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Maio" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Junho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Junho" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Julho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Julho" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Agosto =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Agôsto" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Setembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Setembro" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Outubro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Outubro" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Novembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Novembro" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Dezembro" && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.Ano == ano && new[] { "Despesas Extras", "Informática" }
                    .Contains(d.NomeDaCategoria)).Select(d => d.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDeDespesasExtras";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDeDespesasDeCaridade(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                     contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro" && d.NomeDaCategoria == "Caridade")
                     .Select(d => d.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Fevereiro" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Março" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Abril" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Maio" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Junho" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Julho" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Agôsto" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Setembro" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Outubro" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Novembro" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Dezembro" && d.NomeDaCategoria == "Caridade")
                    .Select(d => d.Valor).Sum(); ;
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.NomeDaCategoria == "Caridade").Select(d => d.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDeDespesasDeCaridade";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDeDespesasDaNeusa(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Fevereiro" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Março" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Abril" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Maio" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Junho" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Julho" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Agôsto" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Setembro" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Outubro" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Novembro" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Dezembro" && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.NomeDaCategoria == "Despesas da Neusa")
                    .Select(d => d.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDeDespesasDaNeusa";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }
    }
}