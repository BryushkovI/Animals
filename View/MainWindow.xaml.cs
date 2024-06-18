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

            this.nameing.IsEnabled = false;
            this.legs.IsEnabled = false;
            this.nutrition.IsEnabled = false;
            this.avgLength.IsEnabled = false;
            this.avgWeigth.IsEnabled = false;
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
            try
            {
                OnAnimalSelected(new AnimalEventArgs(e.AddedItems[0].ToString()));
                nameing.Text = string.Empty;
                legs.Text = string.Empty;
                nutrition.Text = string.Empty;
                avgLength.Text = string.Empty;
                avgWeigth.Text = string.Empty;
            }
            catch (Exception) { }
            
        }

        private void MIChange_Click(object sender, RoutedEventArgs e)
        {
            legs.IsEnabled = true;
            nutrition.IsEnabled = true;
            avgLength.IsEnabled = true;
            avgWeigth.IsEnabled = true;
        }

        protected virtual void OnAnimalRemoved(AnimalEventArgs e)
        {
            AnimalRemoved?.Invoke(this, e);
        }

        private void MIDelete_Click(object sender, RoutedEventArgs e)
        {
            OnAnimalRemoved(new AnimalEventArgs(nameing.Text));

        }

        protected virtual void OnAnimalChanged(AnimalEventArgs e)
        {
            AnimalUpdated?.Invoke(this, e);
        }

        private void MISave_Click(object sender, RoutedEventArgs e)
        {
            OnAnimalChanged(new AnimalEventArgs(nameing.Text, 
                                                int.Parse(legs.Text),
                                                int.Parse(nutrition.Text),
                                                double.Parse(avgLength.Text),
                                                double.Parse(avgWeigth.Text)));
        }
    }
}