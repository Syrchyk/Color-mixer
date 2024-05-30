using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Grid grid = new Grid();
            grid.Height = 20;
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            lbC.Items.Add(grid);
            string str = colorB.Background.ToString();
            grid.Children.Add(new TextBlock()
            {
                Text = str,
                Width = 65
            }) ;
            grid.Children.Add(new Canvas()
            {
                Background = colorB.Background,
                Width = 350,
                Height = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            });
            Grid.SetColumn(grid.Children[1], 1);
            Button b = new Button();
            b.Content = "Delete";
            b.Width = 60;
            b.Click += ButtonDel_Click;
            b.Margin = new Thickness(2,0,0,0);
            grid.Children.Add(b);
            Grid.SetColumn(grid.Children[2], 2);
            check();

        }

        private void check()
        {
            foreach (var item in lbC.Items)
            {
                if (((Canvas)((Grid)item).Children[1]).Background.ToString() == colorB.Background.ToString())
                {
                    bAdd.IsEnabled = false; break;
                }
                else
                {
                    bAdd.IsEnabled = true;
                }
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            lbC.Items.Remove(((Button)sender).Parent);
            bAdd.IsEnabled = true;
            check();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int alpha = Convert.ToInt32(sA.Value);
            int red = Convert.ToInt32(sR.Value); ;
            int green = Convert.ToInt32(sG.Value);
            int blue = Convert.ToInt32(sB.Value);
            Grid grid = (Grid)sender;
            foreach (var item in grid.Children)
            {
                if(item is Slider)
                {
                    switch (((Slider)item).Name)
                    {
                        case "sA": tbA.Text = ((int)((Slider)item).Value).ToString(); alpha = (int)((Slider)item).Value; break;
                        case "sR": tbR.Text = ((int)((Slider)item).Value).ToString(); red = (int)((Slider)item).Value; break;
                        case "sG": tbG.Text = ((int)((Slider)item).Value).ToString(); green = (int)((Slider)item).Value; break;
                        case "sB": tbB.Text = ((int)((Slider)item).Value).ToString(); blue = (int)((Slider)item).Value; break;
                    };
                }
            }
            colorB.Background = new SolidColorBrush(Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue));
            check();
        }

        private void CheckBoxA_Click(object sender, RoutedEventArgs e)
        {
            if(((CheckBox)sender).IsChecked == true)
            {
                sA.IsEnabled = true;
            }
            else
            {
                sA.IsEnabled = false;
            }
        }
        private void CheckBoxR_Click(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).IsChecked == true)
            {
                sR.IsEnabled = true;
            }
            else
            {
                sR.IsEnabled = false;
            }
        }
        private void CheckBoxG_Click(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).IsChecked == true)
            {
                sG.IsEnabled = true;
            }
            else
            {
                sG.IsEnabled = false;
            }
        }
        private void CheckBoxB_Click(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).IsChecked == true)
            {
                sB.IsEnabled = true;
            }
            else
            {
                sB.IsEnabled = false;
            }
        }
    }
}
