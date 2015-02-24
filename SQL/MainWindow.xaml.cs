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

namespace SQL
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }    

        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Log form = new Log();
            form.Show();
            //this.Close();
        }

        public delegate void updateList(List<string> list);

        private void Rectangle_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            

            SpotIntro form = new SpotIntro();
            updateList d = form.updateList;
            d(spotList);
            form.Show();
            //this.Close();
        }

        private void Rectangle_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            Way form = new Way();
            updateList d = form.updateList;
            d(spotList);
            form.Show();
            //this.Close();
        }

        public List<string> spotList = new List<string>();
        private void background_Loaded(object sender, RoutedEventArgs e)
        {
            Image1.Source = new BitmapImage(new Uri(@System.AppDomain.CurrentDomain.BaseDirectory + "title.png"));

            SpotEntities spotdata = new SpotEntities();

            var retRows = from spot in spotdata.景点介绍
                          select new { name = spot.名称, num = spot.序号, price = spot.门票 };
            foreach( var item in retRows )
            {
                spotList.Add(item.name);
                PublicV.NameToNum.Add(item.name, item.num);
                PublicV.NumToName.Add(int.Parse(item.num), item.name);
                PublicV.Ticket.Add(int.Parse(item.price));
            }

            var parent = from spot in spotdata.number
                          select new { zero = spot.C_1, one = spot.C_2to3, two = spot.C_4to8 };
            int index = 0;
            foreach( var item in parent )
            {
                PublicV.Parent[0, index] = double.Parse(item.zero);
                PublicV.Parent[1, index] = double.Parse(item.one);
                PublicV.Parent[2, index] = double.Parse(item.two);
                index++;
            }

            var time = from spot in spotdata.times
                       select new { zero = spot.C_0to1h, one = spot.C_1to3h, two = spot.over3h };
            index = 0;
            foreach( var item in time )
            {
                PublicV.Time[0, index] = double.Parse(item.zero);
                PublicV.Time[1, index] = double.Parse(item.one);
                PublicV.Time[2, index] = double.Parse(item.two);
                index++;
            }

            var kind = from spot in spotdata.type
                       select new { zero = spot.study, one = spot.entertainment, two = spot.sightseeing };
            index = 0;
            foreach( var item in kind )
            {
                PublicV.Kind[0, index] = double.Parse(item.zero);
                PublicV.Kind[1, index] = double.Parse(item.one);
                PublicV.Kind[2, index] = double.Parse(item.two);
                index++;
            }

            var fare = from spot in spotdata.fare
                       select new
                       {
                           a = spot.外滩,
                           b = spot.东方明珠,
                           c = spot.城隍庙,
                           d = spot.上海环球金融中心,
                           e = spot.上海野生动物园,
                           f = spot.朱家角古镇,
                           g = spot.上海博物馆,
                           h = spot.新天地,
                           i = spot.上海杜莎夫人蜡像馆,
                           j = spot.欢乐谷,
                           k = spot.上海科技馆,
                           l = spot.田子坊,
                           m = spot.豫园,
                           n = spot.上海植物园,
                           o = spot.上海海洋水族馆,
                           p = spot.金茂大厦88层观光厅,
                           q = spot.外白渡桥,
                           r = spot.巧克力开心公园,
                           s = spot.佘山国家森林公园,
                           t = spot.七宝老街,
                           u = spot.宋庆龄故居纪念馆,
                           v = spot.徐家汇天主教堂,
                           w = spot.中华艺术宫,
                           x = spot.南京路步行街,
                           y = spot.张爱玲故居,
                           z = spot.人民广场
                       };
            index = 0;
            foreach( var item in fare )
            {
                PublicV.Traffic[0, index] = item.a.Value;
                PublicV.Traffic[1, index] = item.b.Value;
                PublicV.Traffic[2, index] = item.c.Value;
                PublicV.Traffic[3, index] = item.d.Value;
                PublicV.Traffic[4, index] = item.e.Value;
                PublicV.Traffic[5, index] = item.f.Value;
                PublicV.Traffic[6, index] = item.g.Value;
                PublicV.Traffic[7, index] = item.h.Value;
                PublicV.Traffic[8, index] = item.i.Value;
                PublicV.Traffic[9, index] = item.j.Value;
                PublicV.Traffic[10, index] = item.k.Value;
                PublicV.Traffic[11, index] = item.l.Value;
                PublicV.Traffic[12, index] = item.m.Value;
                PublicV.Traffic[13, index] = item.n.Value;
                PublicV.Traffic[14, index] = item.o.Value;
                PublicV.Traffic[15, index] = item.p.Value;
                PublicV.Traffic[16, index] = item.q.Value;
                PublicV.Traffic[17, index] = item.r.Value;
                PublicV.Traffic[18, index] = item.s.Value;
                PublicV.Traffic[19, index] = item.t.Value;
                PublicV.Traffic[20, index] = item.u.Value;
                PublicV.Traffic[21, index] = item.v.Value;
                PublicV.Traffic[22, index] = item.w.Value;
                PublicV.Traffic[23, index] = item.x.Value;
                PublicV.Traffic[24, index] = item.y.Value;
                PublicV.Traffic[25, index] = item.z.Value;
                index++;
            }
        }
    }
}
