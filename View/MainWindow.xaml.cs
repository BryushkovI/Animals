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
        public Dictionary<int, string> Nutritions {  get; set; }
        public Dictionary<int, string> Types { get; set; }

        int animalType = -1;

        public MainWindow()
        {
            InitializeComponent();
            nameing.IsEnabled = false;
            legs.IsEnabled = false;
            nutrition.IsEnabled = false;
            avgLength.IsEnabled = false;
            avgWeigth.IsEnabled = false;
        }

        public event EventHandler<AnimalEventArgs> AnimalSelected;
        public event EventHandler<AnimalEventArgs> AnimalUpdated;
        public event EventHandler<AnimalEventArgs> AnimalRemoved;
        public event EventHandler<AnimalEventArgs> AnimalCreated;
        

        public void SetAnimalDetails(string nameing, int legs, string nutrition, double avgLength, double avgWeigth)
        {
            this.nameing.Text = nameing;
            this.legs.Text = legs.ToString();
            this.nutrition.SelectedItem = Nutritions.Single(n => n.Value == nutrition);
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
            nutrition.ItemsSource = Nutritions;
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
            }
            catch (Exception)
            {
                nameing.Text = string.Empty;
                legs.Text = string.Empty;
                nutrition.Text = string.Empty;
                avgLength.Text = string.Empty;
                avgWeigth.Text = string.Empty;
            }
            finally { animalType = -1; }
            
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
            if (animalType == -1)
            {
                OnAnimalChanged(new AnimalEventArgs(nameing.Text,
                                                int.Parse(legs.Text),
                                                Nutritions.Single(n => n.Key == nutrition.SelectedIndex).Value,
                                                double.Parse(avgLength.Text),
                                                double.Parse(avgWeigth.Text)));
            }
            else
            {
                OnAnimalCreated(new AnimalEventArgs(nameing.Text,
                                                int.Parse(legs.Text),
                                                Nutritions.Single(n => n.Key == nutrition.SelectedIndex).Value,
                                                double.Parse(avgLength.Text),
                                                double.Parse(avgWeigth.Text),
                                                animalType));
                nameing.IsEnabled = false;
                legs.IsEnabled = false;
                nutrition.IsEnabled = false;
                avgLength.IsEnabled = false;
                avgWeigth.IsEnabled = false;
            }
            
        }

        protected virtual void OnAnimalCreated(AnimalEventArgs e)
        {
            AnimalCreated?.Invoke(this, e);
        }

        private void MICrt_Click(object sender, RoutedEventArgs e)
        {
            nameing.IsEnabled = true;
            legs.IsEnabled = true;
            nutrition.IsEnabled = true;
            avgLength.IsEnabled = true;
            avgWeigth.IsEnabled = true;

            nameing.Text = string.Empty;
            legs.Text = string.Empty;
            nutrition.Text = string.Empty;
            avgLength.Text = string.Empty;
            avgWeigth.Text = string.Empty;

            MenuItem menuItem = e.Source as MenuItem;
            animalType = Types.Single(t => t.Value == menuItem.Name).Key;
        }
    }
}