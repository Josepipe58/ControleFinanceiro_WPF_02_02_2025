﻿using System.Globalization;

namespace GerenciarDados.Listas
{
    public class ListaDeStringMeses
    {
        public static List<string> CarregarComboBoxDeMeses()
        {
            DateTime mes = DateTime.Now;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            string mesAtual = textInfo.ToTitleCase(mes.ToString("MMMM"));
            mesAtual = (mesAtual == "Agosto") ? "Agôsto" : mesAtual;
            var listaDeMeses = new List<string>()
            {
                mesAtual,
                "Janeiro",
                "Fevereiro",
                "Março",
                "Abril",
                "Maio",
                "Junho",
                "Julho",
                "Agôsto",
                "Setembro",
                "Outubro",
                "Novembro",
                "Dezembro",
            };
            return listaDeMeses;
        }
    }
}
