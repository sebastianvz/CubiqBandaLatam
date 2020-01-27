using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using wpfCubiqBanda.UI.Models;

namespace wpfCubiqBanda.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Wan data;
        public MainWindow()
        {
            InitializeComponent();
            txtWan.Focus();
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void BtnbuscarWAM_Click(object sender, RoutedEventArgs e)
        {

            #region JsonFromFile
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Assets\dummyData.json");
            var str = File.ReadAllText(path);
            #region TestJson

            //Hawb item11 = new Hawb() { IdHawb = "1a", Pieces = 560 };
            //Hawb item12 = new Hawb() { IdHawb = "1b", Pieces = 100 };
            //Hawb item13 = new Hawb() { IdHawb = "1c", Pieces = 12 };
            //Hawb item14 = new Hawb() { IdHawb = "1d", Pieces = 198 };
            //Hawb item15 = new Hawb() { IdHawb = "1e", Pieces = 210 };


            //Hawb item21 = new Hawb() { IdHawb = "2a", Pieces = 560 };
            //Hawb item22 = new Hawb() { IdHawb = "2b", Pieces = 100 };
            //Hawb item23 = new Hawb() { IdHawb = "2c", Pieces = 12 };
            //Hawb item24 = new Hawb() { IdHawb = "2d", Pieces = 198 };
            //Hawb item25 = new Hawb() { IdHawb = "2e", Pieces = 210 };


            //Hawb item31 = new Hawb() { IdHawb = "3a", Pieces = 560 };
            //Hawb item32 = new Hawb() { IdHawb = "3b", Pieces = 100 };
            //Hawb item33 = new Hawb() { IdHawb = "3c", Pieces = 12 };
            //Hawb item34 = new Hawb() { IdHawb = "3d", Pieces = 198 };
            //Hawb item35 = new Hawb() { IdHawb = "3e", Pieces = 210 };

            //Hawb item41 = new Hawb() { IdHawb = "4a", Pieces = 560 };
            //Hawb item42 = new Hawb() { IdHawb = "4b", Pieces = 100 };
            //Hawb item43 = new Hawb() { IdHawb = "4c", Pieces = 12 };
            //Hawb item44 = new Hawb() { IdHawb = "4d", Pieces = 198 };
            //Hawb item45 = new Hawb() { IdHawb = "4e", Pieces = 210 };

            //List<Hawb> ListHijas1 = new List<Hawb>();
            //ListHijas1.Add(item11);
            //ListHijas1.Add(item12);
            //ListHijas1.Add(item13);
            //ListHijas1.Add(item14);
            //ListHijas1.Add(item15);

            //List<Hawb> ListHijas2 = new List<Hawb>();
            //ListHijas2.Add(item21);
            //ListHijas2.Add(item22);
            //ListHijas2.Add(item23);
            //ListHijas2.Add(item24);
            //ListHijas2.Add(item25);

            //List<Hawb> ListHijas3 = new List<Hawb>();
            //ListHijas3.Add(item31);
            //ListHijas3.Add(item32);
            //ListHijas3.Add(item33);
            //ListHijas3.Add(item34);
            //ListHijas3.Add(item35);

            //List<Hawb> ListHijas4 = new List<Hawb>();
            //ListHijas4.Add(item41);
            //ListHijas4.Add(item42);
            //ListHijas4.Add(item43);
            //ListHijas4.Add(item44);
            //ListHijas4.Add(item45);


            //Mawb itemMa1 = new Mawb() { Id = "m1", Hawbs = ListHijas1 };
            //Mawb itemMa2 = new Mawb() { Id = "m2", Hawbs = ListHijas2 };
            //Mawb itemMa3 = new Mawb() { Id = "m3", Hawbs = ListHijas3};
            //Mawb itemMa4 = new Mawb() { Id = "m4", Hawbs = ListHijas4 };

            //List<Mawb> ListMadres = new List<Mawb>();
            //ListMadres.Add(itemMa1);
            //ListMadres.Add(itemMa2);
            //ListMadres.Add(itemMa3);
            //ListMadres.Add(itemMa4);

            //Wan wan = new Wan
            //{
            //    Mawbs = ListMadres
            //};

            //var y = JsonConvert.SerializeObject(wan);
            #endregion
            var FullwanFromFile = JsonConvert.DeserializeObject<Wan>(str);
            data = FullwanFromFile;
            #endregion

            #region JsonFromEndPoint
            //var testJson = new BandaController();
            //var result =testJson.APi();
            #endregion

            #region Cargar combo
            cmbMawb.ItemsSource = FullwanFromFile.Mawbs.Select(i => i.Id);
            cmbMawb.SelectedIndex = 0;
            #endregion

        }

        private void BtnbuscarWAM_KeyDown(object sender, KeyEventArgs e)
        {
            var oe = txtWan.Text;
            if (e.Key == Key.Return)
            {
                MessageBoxResult result = MessageBox.Show("Enter" + oe);
            }
        }

        private void BtnbuscarWAM_TouchEnter(object sender, TouchEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Enter touch");
        }

        private void CmbMawb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            gridHabuttons.Children.Clear();
            gridHabuttons.RowDefinitions.Clear();
            gridHabuttons.ColumnDefinitions.Clear();

            var itemValue = cmbMawb.SelectedValue.ToString();
            var mawbList = data.Mawbs.Where(c => c.Id == itemValue).ToList();
            var hawbListo = mawbList[0].Hawbs;
            var count = 0;

            for (int i = 0; i < hawbListo.Count; i++)
            {
                var rowDefinition = new RowDefinition();
                rowDefinition.Height = GridLength.Auto;
                gridHabuttons.RowDefinitions.Add(rowDefinition);

                for (int j = 0; j < 4; j++)
                {
                    var columDefinition = new ColumnDefinition();


                    if (count <= (hawbListo.Count - 1))
                    {
                        Button newButton = new Button();
                        newButton.Content = hawbListo[count].IdHawb;
                        newButton.Name = "Button" + hawbListo[count].IdHawb;
                        newButton.Width = 100;
                        newButton.Height = 50;
                        newButton.Tag = hawbListo[count].Pieces;
                        newButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
                        Grid.SetColumn(newButton, j);
                        Grid.SetRow(newButton, i);
                        gridHabuttons.Children.Add(newButton);
                        columDefinition.Width = GridLength.Auto;
                        gridHabuttons.ColumnDefinitions.Add(columDefinition);
                        
                    }
                    count++;
                }
            }
            MessageBoxResult result = MessageBox.Show("Enter touch");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button buttons = (Button)sender;
            txtPiezas.Text = ((Button)sender).Tag.ToString();

        }

        private void txtWan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                MessageBoxResult result = MessageBox.Show("Enter touch");
            }
        }
    }
}
