using System;
using System.Collections.Generic;
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

namespace Practic11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> buttons;
        string botSymbol = "O";
        string playerSymbol = "X";
        public MainWindow()
        {
            InitializeComponent();
            buttons = new List<Button>{_1, _2, _3, _4, _5, _6, _7,_8,_9};
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = playerSymbol;
            (sender as Button).IsEnabled = false;
            foreach (Button button in buttons)
            {
                if (button.Name == (sender as Button).Name)
                {
                    buttons.Remove(button);
                    break;
                }
            }
            if (buttons.Count > 0)
            {
                if (_1.Content == playerSymbol && _2.Content == playerSymbol && _3.Content == playerSymbol || _4.Content == playerSymbol && _5.Content == playerSymbol && _6.Content == playerSymbol || _7.Content == playerSymbol && _8.Content == playerSymbol && _9.Content == playerSymbol || _1.Content == playerSymbol && _5.Content == playerSymbol && _9.Content == playerSymbol || _3.Content == playerSymbol && _5.Content == playerSymbol && _7.Content == playerSymbol || _1.Content == playerSymbol && _4.Content == playerSymbol && _7.Content == playerSymbol || _2.Content == playerSymbol && _5.Content == playerSymbol && _8.Content == playerSymbol || _3.Content == playerSymbol && _6.Content == playerSymbol && _9.Content == playerSymbol)
                {
                    Result.Text = "Победа";
                    NewGame.IsEnabled = true;
                    foreach (Button button in buttons)
                    {
                        button.IsEnabled = false;
                    }
                }
                else
                {
                    Logic_Bot();
                }
            }
            else
            {
                if(_1.Content == playerSymbol && _2.Content == playerSymbol && _3.Content == playerSymbol || _4.Content == playerSymbol && _5.Content == playerSymbol && _6.Content == playerSymbol || _7.Content == playerSymbol && _8.Content == playerSymbol && _9.Content == playerSymbol || _1.Content == playerSymbol && _5.Content == playerSymbol && _9.Content == playerSymbol || _3.Content == playerSymbol && _5.Content == playerSymbol && _7.Content == playerSymbol || _1.Content == playerSymbol && _4.Content == playerSymbol && _7.Content == playerSymbol || _2.Content == playerSymbol && _5.Content == playerSymbol && _8.Content == playerSymbol || _3.Content == playerSymbol && _6.Content == playerSymbol && _9.Content == playerSymbol)
                {
                    Result.Text = "Победа";
                    NewGame.IsEnabled = true;
                    foreach (Button button in buttons)
                    {
                        button.IsEnabled = false;
                    }
                }
                else
                {
                    Result.Text = "Ничья";
                    NewGame.IsEnabled = true;
                }
                
            }
        }
        private void Logic_Bot()
        {
            Random r = new Random();
            int currentButton = r.Next(0, buttons.Count);
            buttons[currentButton].Content = botSymbol;
            buttons[currentButton].IsEnabled = false;
            foreach (Button button in buttons)
            {
                if (button.Name == buttons[currentButton].Name)
                {
                    buttons.Remove(button);
                    break;
                }
            }
            if (_1.Content == botSymbol && _2.Content == botSymbol && _3.Content == botSymbol ||  _4.Content == botSymbol && _5.Content == botSymbol && _6.Content == botSymbol || _7.Content == botSymbol && _8.Content == botSymbol && _9.Content == botSymbol || _1.Content == botSymbol && _5.Content == botSymbol && _9.Content == botSymbol || _3.Content == botSymbol && _5.Content == botSymbol && _7.Content == botSymbol || _1.Content == botSymbol && _4.Content == botSymbol && _7.Content == botSymbol || _2.Content == botSymbol && _5.Content == botSymbol && _8.Content == botSymbol || _3.Content == botSymbol && _6.Content == botSymbol && _9.Content == botSymbol)
            {
                Result.Text = "Поражение";
                NewGame.IsEnabled = true;
                foreach (Button button in buttons)
                {
                    button.IsEnabled = false;
                }
            }
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = "";
            if (playerSymbol == "X")
            {
                botSymbol = "X";
                playerSymbol = "O";
            }
            else
            { 
                botSymbol = "O";
                playerSymbol = "X";
            }
            buttons = new List<Button>() { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
            NewGame.IsEnabled = false;
        }
    }
}
