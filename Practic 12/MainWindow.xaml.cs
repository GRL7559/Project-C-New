using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practic_12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// public class Note
    /// 
    public class CRUD
    {
        public static void Create()
        {

        }
        public static List<Note> Read(string path)
        {
        }
        public static void Update()
        {
        }
        public static void Delete()
        {

        }
        }

    public class Note
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public partial class MainWindow : Window
    {
        private List<Note> notes;
        private string path = "notes.json";
        public MainWindow()
        {
            InitializeComponent();
            notes = CRUD.Read(path);
            Records.ItemsSource = notes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void Days_Filter()
        {
            foreach (Note item in notes)
            {
                if (item.Date == Calendar.DisplayDate)
                {
                    
                }

            }
        }
    }
}
