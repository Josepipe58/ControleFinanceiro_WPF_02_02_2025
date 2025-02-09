using AppControleFinanceiro.Telas.Menus;
using System.Windows;

namespace AppControleFinanceiro
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MenuIniciar();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
