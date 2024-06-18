using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Animals.View.Abstract;
using Animals.View.EventsArgs;

namespace Animals
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowView
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public event EventHandler<AnimalEventArgs> AnimalSelected;
        public event EventHandler<AnimalEventArgs> AnimalUpdated;
        public event EventHandler<AnimalEventArgs> AnimalRemoved;

        public void SetAnimalDetails(string nameing, int legs, int nutrition, double avgLength, double avgWeigth)
        {
            this.nameing.Text = nameing;
            this.legs.Text = legs.ToString();
            this.nutrition.Text = nutrition.ToString();
            this.avgLength.Text = avgLength.ToString();
            this.avgWeigth.Text = avgWeigth.ToString();
        }

        public void SetAnimals(ObservableCollection<string> animals)
        {
            animalList.ItemsSource = animals;
        }

        protected virtual void OnAnimalSelected(AnimalEventArgs e)
        {
            AnimalSelected?.Invoke(this, e);
        }

        private void AnimalList_Selected(object sender, SelectionChangedEventArgs e)
        {
            OnAnimalSelected(new AnimalEventArgs(e.AddedItems[0].ToString()));
        }
    }
}