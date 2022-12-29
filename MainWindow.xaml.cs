using System;
using System.Collections.Generic;
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
using ToDoApp.Models;
using ToDoApp.IOData;

namespace ToDoApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private readonly string jsoneFile = $"{Environment.CurrentDirectory}\\listOfData.json";
        private FileIOManager fileOPManager;

        private BindingList<ToDoModel> listOfData;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileOPManager = new FileIOManager(jsoneFile);
            try
            {
                listOfData = fileOPManager.OutputData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dgToDoList.ItemsSource = listOfData;
            listOfData.ListChanged += ListOfData_ListChanged;
        }

        private void ListOfData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    fileOPManager.SaveData(listOfData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
