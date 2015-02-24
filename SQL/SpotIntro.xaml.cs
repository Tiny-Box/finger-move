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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SQL
{
    /// <summary>
    /// SpotIntro.xaml 的交互逻辑
    /// </summary>
    public partial class SpotIntro : Window
    {
        SpotEntities spotdata = new SpotEntities();

        public SpotIntro()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            PublicV.RouteName.Clear();
            this.Close();
        }

        public void updateList(List<string> list)
        {
            ComboBox1.ItemsSource = list;
        }
        public void updatelist(List<string> list)
        {
            ComboBox1.ItemsSource = list;
        }

        private void background_Loaded(object sender, RoutedEventArgs e)
        {
            //SpotEntities spotdata = new SpotEntities();

            //var retRows = from spot in spotdata.景点介绍
            //              select spot.名称;

            //ComboBox1.ItemsSource = retRows.ToList();
        }

        public delegate void updatetxt(string list);
        private void ButtonS_Click(object sender, RoutedEventArgs e)
        {
            detail form = new detail();
            updatetxt d = form.updatetext;
            d(introduction);
            form.Show();
        }

        public string SpotNum;
        public int index = 0;
        public string introduction;

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string spotname = ComboBox1.SelectedItem.ToString();
            //string SpotNum = "";

            var retRows = from spot in spotdata.景点介绍
                          where spot.名称 == spotname
                          select new { openTime = spot.开放时间, price = spot.门票, address = spot.地址, introduction = spot.简介, num = spot.序号 };
            foreach (var item in retRows)
            {
                Price.Text = item.price;
                OpenTime.Text = item.openTime;
                Address.Text = item.address;
                Introduction.Text = item.introduction;
                SpotNum = item.num;
            }

            introduction = Introduction.Text;
            Image1.Source = new BitmapImage(new Uri(@System.AppDomain.CurrentDomain.BaseDirectory + "image/" + SpotNum + "_3.jpg"));

            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 4);
            dispatcherTimer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            List<string> imageAddress = new List<string>(); 
            
            imageAddress.Add(System.AppDomain.CurrentDomain.BaseDirectory + "image/" + SpotNum + "_1.jpg");
            imageAddress.Add(System.AppDomain.CurrentDomain.BaseDirectory + "image/" + SpotNum + "_2.jpg");
            imageAddress.Add(System.AppDomain.CurrentDomain.BaseDirectory + "image/" + SpotNum + "_3.jpg");

            if (true)
            {
                Image1.Source = new BitmapImage(new Uri(@imageAddress[index%3]));

                index++;
            }
               
        }


    }
}
