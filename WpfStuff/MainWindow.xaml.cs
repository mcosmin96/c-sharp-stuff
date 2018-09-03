using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCommon;

namespace WpfStuff
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        public void CheckBox_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            opmsgs = new msgobj[]
            {
                new msgobj("System", "Very long message that needs to wrap on two lines to check if there's a way to expand single rows in this control or not hopefully there is"),
                new msgobj("System", "Message 2"),
                new msgobj("System", "Message 3"),
                new msgobj("System", "Message 4"),
                new msgobj("System", "Message 5")
            };
            Property1 = "This is property 1";
            ItemArray = new ObservableCollection<ItemClass>()
            {
                new ItemClass()
                {
                    BoolProp = true,
                    StringProp = "First Item"
                },
                new ItemClass()
                {
                    BoolProp = false,
                    StringProp = "Second Item"
                }
            };

            SelectedOption = "Option 1";
        }

        public msgobj[] opmsgs { get; set; }


        public string Property1 { get; set; }
        public ObservableCollection<ItemClass> ItemArray { get; set; }

        private string _selectedOption;
        public string SelectedOption
        {
            get => _selectedOption;
            set
            {
                _selectedOption = value;
                OnPropertyChanged("SelectedOption");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class msgobj
    {
        public msgobj(string _sender, string _msg)
        {
            sender = _sender;
            msg = _msg;
        }
        public string sender { get; set; }
        public string msg { get; set; }
    }
}
