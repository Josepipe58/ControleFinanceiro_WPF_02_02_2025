﻿using AcessarDadosDoBanco.ContextoDeDados;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Relatorios
{
    public static class RelatorioDePoupanca
    {
        private static string _nomeDoMetodo = string.Empty;
        private static readonly string[] despesaDebito = ["Despesa", "Débito"];// 
        private static readonly string[] rendaCreditosPoupanca = ["Renda", "Créditos da Poupança"];
        private static readonly string[] rendaCreditosInvestimento = ["Renda de Investimentos", "Créditos de Investimentos"];

        public static ListaDeMeses RelatorioDoSaldoTotalDaPoupancaReceitasEInvestimentos(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Saldo Anterior" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.Tipo == "Saldo Anterior" && i.Mes == "Janeiro").Select(i => i.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Janeiro").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Janeiro").Select(i => i.Valor).Sum());

                meses.Fevereiro =
                    meses.Janeiro +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Saldo Anterior" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.Tipo == "Saldo Anterior" && i.Mes == "Fevereiro").Select(i => i.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Fevereiro").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Fevereiro").Select(i => i.Valor).Sum());

                meses.Marco =
                    meses.Fevereiro +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Março").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Março").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Março").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Março").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Março").Select(i => i.Valor).Sum());


                meses.Abril =
                    meses.Marco +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Abril").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Abril").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Abril").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Abril").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Abril").Select(i => i.Valor).Sum());

                meses.Maio =
                    meses.Abril +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Maio").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Maio").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Maio").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Maio").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Maio").Select(i => i.Valor).Sum());

                meses.Junho =
                    meses.Maio +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Junho").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Junho").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Junho").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Junho").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Junho").Select(i => i.Valor).Sum());

                meses.Julho =
                    meses.Junho +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Julho").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Julho").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Julho").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Julho").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Julho").Select(i => i.Valor).Sum());

                meses.Agosto =
                    meses.Julho +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Agôsto").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Agôsto").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Agôsto").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Agôsto").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Agôsto").Select(i => i.Valor).Sum());

                meses.Setembro =
                    meses.Agosto +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Setembro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Setembro").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Setembro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Setembro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Setembro").Select(i => i.Valor).Sum());

                meses.Outubro =
                    meses.Setembro +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Outubro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Outubro").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Outubro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Outubro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Outubro").Select(i => i.Valor).Sum());

                meses.Novembro =
                    meses.Outubro +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Novembro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Novembro").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Novembro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Novembro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Novembro").Select(i => i.Valor).Sum());

                meses.Dezembro =
                    meses.Novembro +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Dezembro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && rendaCreditosInvestimento.Contains(i.NomeDaCategoria) && i.Mes == "Dezembro").Select(i => i.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Dezembro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Dezembro").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Dezembro").Select(i => i.Valor).Sum());

                meses.TotalAno = meses.Dezembro;

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDoSaldoTotalDaPoupancaReceitasEInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses RelatorioDoSaldoTotalDaPoupanca(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Saldo Anterior" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Janeiro").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    meses.Janeiro +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Saldo Anterior" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    meses.Fevereiro +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Março").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    meses.Marco +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Abril").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    meses.Abril +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Maio").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    meses.Maio +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Junho").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    meses.Junho +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Julho").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    meses.Julho +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Agôsto").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    meses.Agosto +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Setembro").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Setembro").Select(p => p.Valor).Sum();

                meses.Outubro =
                    meses.Setembro +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Outubro").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Outubro").Select(p => p.Valor).Sum();

                meses.Novembro =
                    meses.Outubro +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Novembro").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Novembro").Select(p => p.Valor).Sum();

                meses.Dezembro =
                    meses.Novembro +
                    contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Dezembro").Select(p => p.Valor).Sum() -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo) && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno = meses.Dezembro;

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDoSaldoTotalDaPoupanca";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses RelatorioDosJurosDaPoupanca(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança").Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDosJurosDaPoupanca";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses RelatorioDosRendimentosEntreDepositosJurosESaques(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Janeiro").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Janeiro").Select(p => p.Valor).Sum());

                meses.Fevereiro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum());

                meses.Marco =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Março").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Março").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Março").Select(p => p.Valor).Sum());

                meses.Abril =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Abril").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Abril").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Abril").Select(p => p.Valor).Sum());

                meses.Maio =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Maio").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Maio").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Maio").Select(p => p.Valor).Sum());

                meses.Junho =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Junho").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Junho").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Junho").Select(p => p.Valor).Sum());

                meses.Julho =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Julho").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Julho").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Julho").Select(p => p.Valor).Sum());

                meses.Agosto =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Agôsto").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Agôsto").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Agôsto").Select(p => p.Valor).Sum());

                meses.Setembro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Setembro").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Setembro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Setembro").Select(p => p.Valor).Sum());

                meses.Outubro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Outubro").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Outubro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Outubro").Select(p => p.Valor).Sum());

                meses.Novembro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Novembro").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Novembro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Novembro").Select(p => p.Valor).Sum());

                meses.Dezembro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo) && p.Mes == "Dezembro").Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Dezembro").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Dezembro").Select(p => p.Valor).Sum());

                meses.TotalAno =
                    contexto.TPoupanca.Where(p => p.Ano == ano && new[] { "Crédito", "Receita" }.Contains(p.Tipo)).Select(p => p.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa").Select(p => p.Valor).Sum());

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDosRendimentosEntreDepositosJurosESaques";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses RelatorioDePagamentosETranferencias(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa").Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDePagamentosETranferencias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
