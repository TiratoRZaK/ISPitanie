using System.Windows;

namespace ISPitanie
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AutoMapperConfig.Initialize();
        }
    }
}