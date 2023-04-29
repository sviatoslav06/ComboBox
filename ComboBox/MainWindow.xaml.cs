using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace ComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //INotifyCollectionChanged
        ObservableCollection<Person> people = null;
        //List<Person> people = null;
        public MainWindow()
        {
            InitializeComponent();

            //people = new List<Person>()
            //{
            //    new Person() {Name = "Bogdan", Surname="Bogdan",Birth = new System.DateTime(1990,1,2)},
            //    new Person() {Name = "Viktoria", Surname="Leveg",Birth = new System.DateTime(2000,3,4)},
            //    new Person() {Name = "Sasha", Surname="Kofae",Birth = new System.DateTime(2010,1,5)}
            //};

            people = new ObservableCollection<Person>()
            {
                new Person() {Name = "Bogdan", Surname="Bogdan",Birth = new System.DateTime(1990,1,2)},
                new Person() {Name = "Viktoria", Surname="Leveg",Birth = new System.DateTime(2000,3,4)},
                new Person() {Name = "Sasha", Surname="Kofae",Birth = new System.DateTime(2010,1,5)}
            };

            comboBox.Items.Clear();

            //foreach (var item in people)
            //{
            //    comboBox.Items.Add(item);
            //}

            comboBox.ItemsSource = people;

            //comboBox.DisplayMemberPath = nameof(Person.Name);
            comboBox.DisplayMemberPath = nameof(Person.FullName);
            //comboBox.DisplayMemberPath = $"{nameof(Person.Birth)}.{nameof(Person.Birth.Year)}";
            //comboBox.DisplayMemberPath = null;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBox.SelectedItem != null)
            {
                MessageBox.Show(comboBox.SelectedItem.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newPerson = new Person() { Name = "New Name", Surname = "New Surname", Birth = new System.DateTime(1990, 1, 1) };
            people.Add(newPerson);
            //comboBox.Items.Add(newPerson);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedItem != null) people.RemoveAt(comboBox.SelectedIndex);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            people.Clear();
        }
    }
}
