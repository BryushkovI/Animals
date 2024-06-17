using AnimalModel;
using Animals.Presenter;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Animals
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        static void Main()
        {
            App app = new App();
            MainWindow view = new MainWindow();
            AnimalPresenter presenter = new(new NullAnimal(), view);
            app.Run(view);
        }
    }

}
