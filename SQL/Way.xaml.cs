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

namespace SQL
{
    /// <summary>
    /// Way.xaml 的交互逻辑
    /// </summary>
    public partial class Way : Window
    {
        public Way()
        {
            InitializeComponent();
        }

        public double[] customerWeight = new double[9];

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void updateList(List<string> list)
        {
            Combobox1.ItemsSource = list;
        }

        private void background_Loaded(object sender, RoutedEventArgs e)
        {
            //SpotEntities spotdata = new SpotEntities();

            //var retRows = from spot in spotdata.景点介绍
            //              select spot.名称;

            //Combobox1.ItemsSource = retRows.ToList();
        }

        public delegate void updatelist(List<string> list);
        private void ButtonS_Click(object sender, RoutedEventArgs e)
        {
            if ((Parent1.IsChecked == true||Parent2.IsChecked == true||Parent3.IsChecked == true)
               &&(Time1.IsChecked == true||Time2.IsChecked == true||Time3.IsChecked == true)
               &&(Kind1.IsChecked == true||Kind2.IsChecked == true||Kind3.IsChecked == true))
            {
                //WayResult form = new WayResult();
                //update d = form.updata;

                updata(Combobox1.SelectedItem.ToString(), Budget.Text, customerWeight);
                Matrix Weight_P = new Matrix(3, 26, PublicV.Parent);
                Matrix Weight_K = new Matrix(3, 26, PublicV.Kind);
                Matrix Weight_T = new Matrix(3, 26, PublicV.Time);
                double[,] Weight = new double[9, 26];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        Weight[i, j] = Weight_P.GetValue(i, j);
                        Weight[i + 3, j] = Weight_T.GetValue(i, j);
                        Weight[i + 6, j] = Weight_K.GetValue(i, j);
                    }
                }

                Matrix Message = new Matrix(9, 26, Weight);
                Message = Algorithm.CityCash * Message;
                Message = Message.MulCount(0, 10);

                AntAlgorithm way = new AntAlgorithm();
                way.AntSet(PublicV.Traffic, Message.ToArray(), 0.8, 1, 1, 0.7, 1);
                PublicV.Route = way.FindingWay(Algorithm.BeginPoint);

                PublicV.RouteName.Add(PublicV.NumToName[Algorithm.BeginPoint]);
                for (int i = 0; i < PublicV.Route.Length - 1; i++)
                {
                    //if (cash + PublicV.Traffic[PublicV.Route[i], PublicV.Route[i + 1]] + PublicV.Ticket[Algorithm.BeginPoint] > Algorithm.limitcash)
                    //{
                    //    break;
                    //}
                    if (i == Algorithm.BeginPoint-1)
                    {
                        continue;
                    }
                    if (i >= Algorithm.lengthmax)
                    {
                        break;
                    }
                    PublicV.RouteName.Add(PublicV.NumToName[PublicV.Route[i] + 1]);
                }
                SpotIntro form = new SpotIntro();
                updatelist d = form.updatelist;
                d(PublicV.RouteName);
                form.Show();
                this.Close();
                //form.Show();

            }
            else
            {
                MessageBox.Show("请填写相关信息！");
            }

            
        }

        public void updata(string beginPoint, string limitCash, double[] customerWeight)
        {
            Algorithm.BeginPoint = int.Parse(PublicV.NameToNum[beginPoint]);
            Algorithm.limitcash = int.Parse(limitCash);
            Algorithm.CityCash = new Matrix(1, 9, customerWeight);

        }

        private void Parent1_Checked(object sender, RoutedEventArgs e)
        {
            customerWeight[0] = 0.7;
            customerWeight[1] = 0.2;
            customerWeight[2] = 0.1;
        }

        private void Parent2_Checked(object sender, RoutedEventArgs e)
        {
            customerWeight[0] = 0;
            customerWeight[1] = 0.7;
            customerWeight[2] = 0.3;
        }

        private void Parent3_Checked(object sender, RoutedEventArgs e)
        {
            customerWeight[0] = 0;
            customerWeight[1] = 0;
            customerWeight[2] = 1;
        }

        private void Time1_Checked(object sender, RoutedEventArgs e)
        {
            customerWeight[3] = 1;
            customerWeight[4] = 0;
            customerWeight[5] = 0;
        }

        private void Time2_Checked(object sender, RoutedEventArgs e)
        {
            customerWeight[3] = 0.3;
            customerWeight[4] = 0.7;
            customerWeight[5] = 0;
        }

        private void Time3_Checked_1(object sender, RoutedEventArgs e)
        {
            customerWeight[3] = 0.1;
            customerWeight[4] = 0.2;
            customerWeight[5] = 0.7;
        }

        private void Kind1_Checked(object sender, RoutedEventArgs e)
        {
            customerWeight[6] = 1;
            customerWeight[7] = 0;
            customerWeight[8] = 0;
        }

        private void Kind2_Checked(object sender, RoutedEventArgs e)
        {
            customerWeight[6] = 0;
            customerWeight[7] = 1;
            customerWeight[8] = 0;
        }

        private void Kind3_Checked(object sender, RoutedEventArgs e)
        {
            customerWeight[6] = 0;
            customerWeight[7] = 0;
            customerWeight[8] = 1;
        }
        
        

    }

    class Algorithm
    {
        public static int BeginPoint;
        public static double[,] Weight = new double[1, 9];
        public static Matrix CityCash;

        //public static double[,] test = new double[3, 3]
        //                                {{1, 2, 6},
        //                                {0.5, 1, 4},
        //                                {1/6, 1/4, 1}};
        //public static double[,] City_Cash = new double[6, 6]
        //                                { { 0, 0, 0, 0, 0, 0 }, 
        //                                { 0, 0, 5, 4, 7, 3 },
        //                                { 0, 5, 0, 6, 2, 1 },
        //                                { 0, 4, 6, 0, 4, 3 },
        //                                { 0, 7, 2, 4, 0, 5 },
        //                                { 0, 3, 1, 3, 5, 0 }};
        public static int[] City = new int[26] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static int lengthmax = 8;
        public static int limitcash;
        public static string temp = "";

        //public static void FindWay(int CityX, int CityY, double cash, List<int> route, int length)
        //{

        //    //Console.WriteLine(CityY.ToString());
        //    if (cash + PublicV.Traffic[CityX-1, CityY-1] + PublicV.Ticket[CityY-1] >= limitcash || length >= lengthmin)
        //    {
        //        //temp = string.Join(",", route.ToArray());
        //        if (Algorithm.SameWay(temp, PublicV.Route)&&temp != PublicV.Route[PublicV.Route.Count-1])
        //        {
        //            PublicV.Route.Add(temp);

        //            PublicV.SameRoute.Add(Algorithm.Sort(temp.Split(new[] { ',' })));
        //            return;
        //        }


        //    }


        //    route.Add(CityY);
        //    temp = string.Join(",", route.ToArray());
        //    cash += PublicV.Traffic[CityX-1, CityY-1] + PublicV.Ticket[CityY-1];
        //    City[CityY-1] = 1;


        //    for (int i = 1; i < 27; i++)
        //    {
        //        temp = string.Join(",", route.ToArray());
        //        if (CityY == i || City[i - 1] == 1 || StaSameWay(temp+","+i.ToString()))
        //        {
        //            continue;
        //        }
        //        FindWay(CityY, i, cash, route, length + 1);
        //    }

        //    City[CityY-1] = 0;
        //    cash -= PublicV.Traffic[CityX - 1, CityY - 1] + PublicV.Ticket[CityY - 1];
        //    route.Remove(CityY);
        //}

        public static bool SameWay(string temp, List<string> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (temp == numbers[i])
                {
                    return false;
                }
            }
            return true;
        }
        //public static bool StaSameWay(string temp)
        //{
        //    string[] results = temp.Split(new[] { ',' });
        //    string Temp = Sort(results);
        //    for(int i = 0; i < PublicV.SameRoute.Count; i++)
        //    {
        //        if (Temp == PublicV.SameRoute[i])
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public static string Sort(string[] numbers)
        {
            QuickSort(numbers, 0, numbers.Length - 1);
            return string.Join(",", numbers.ToArray());
        }
        private static void QuickSort(string[] numbers, int left, int right)
        {
            if (left < right)
            {
                string middle = numbers[(left + right) / 2];
                int i = left - 1;
                int j = right + 1;
                while (true)
                {
                    while (int.Parse(numbers[++i]) < int.Parse(middle)) ;

                    while (int.Parse(numbers[--j]) > int.Parse(middle)) ;

                    if (i >= j)
                        break;

                    Swap(numbers, i, j);
                }

                QuickSort(numbers, left, i - 1);
                QuickSort(numbers, j + 1, right);
            }
        }

        private static void Swap(string[] numbers, int i, int j)
        {
            string number = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = number;
        }
    }

    class AntAlgorithm
    {
        private const int N = 26;//城市的个数
        private const int M = 10;//每一轮中蚂蚁的个数
        private const int RcMax = 5000;//迭代次数
        //private const int IN = 1;//信息素的初始量
        private double[,] graph = new double[N, N];//城市图

        private double[,] add = new double[N, N];//每一段的信息素增量数组
        private int[,] map = new int[M, N];//每一只蚂蚁的所走的路线记录
        private int[,] vis = new int[M, N];//记录每一只访问过的城市，0表示未访问，1表示以访问
        private double[,] expectVa = new double[N, N];//每一段路径的期望值 = 1.0/距离
        double[,] phe = new double[N, N];//每一段路径上的信息素
        private double MAX = 0x7fffffff;

        private double alphe, betra, rout, Q;//alphe信息素的影响因子，betra路线距离的影响因子，rout信息素的保持度，Q用于计算每只蚂蚁在其路迹留下的信息素增量
        private double bestSolution = 0x7fffffff;//最短距离
        private int[] bestWay = new int[N];//最优路线

        public void AntSet(int[,] city, double[,] message, double Lo, double Alpha, int Beta, double Rout, double Qi)
        {
            //初始化变量参数和信息数组
            this.alphe = Alpha;
            this.betra = Beta;
            this.rout = Rout;
            this.Q = Qi;
            //初始化城市图  TODO
            for (int i = 0; i < N; i++)
            {
                this.graph[i, i] = this.MAX;
            }
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    this.graph[i, j] = 2;
                    this.graph[j, i] = 2;
                    //this.graph[i,j] = city[i,j];
                    //this.graph[j,i] = city[j,i];
                }
            }

            //初始化路线记录数组
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    this.map[i, j] = -1;
                    this.vis[i, j] = 0;
                }
            }
            //初始化期望值数组
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    this.expectVa[i, j] = 1.0 / this.graph[i, j];
                }
            }
            //初始化信息素数组
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    phe[i, j] = message[0, j];
                }
            }
        }

        private void SetBegin(int Begin)
        {
            for (int i = 0; i < M; i++)
            {
                this.map[i, 0] = Begin;
                this.vis[i, Begin] = 1;
            }
        }

        private void choiceRoute()
        {
            int s = 1;
            while (s < N)
            {
                for (int i = 0; i < M; i++)
                {
                    double psum = 0;
                    for (int j = 0; j < N; j++)
                    {
                        if (this.vis[i, j] == 0)
                        {
                            psum += Math.Pow(phe[this.map[i, s - 1], j], this.alphe) * Math.Pow(this.expectVa[this.map[i, s - 1], j], this.betra);
                        }
                    }
                    Random ro = new Random();
                    double drand = (double)(ro.Next()) / (MAX + 1);

                    double pro = 0;
                    int last = N - 1;
                    for (int j = 0; j < N; j++)
                    {
                        if (this.vis[i, j] == 0)
                        {
                            pro += (Math.Pow(this.phe[this.map[i, s - 1], j], this.alphe) * Math.Pow(this.expectVa[this.map[i, s - 1], j], this.betra)) / psum;
                            if (pro >= drand)
                            {
                                last = j;
                                break;
                            }
                        }

                    }
                    this.vis[i, last] = 1;
                    this.map[i, s] = last;
                }
                s++;
            }
        }

        private void getBestWay()
        {
            double solution = 0;
            for (int i = 0; i < M; i++)
            {
                solution = 0;
                for (int a = 0; a < N - 1; a++)
                {
                    solution += this.graph[this.map[i, a], this.map[i, a + 1]];
                }
                if (solution < this.bestSolution)
                {
                    for (int j = 0; j < N; j++)
                    {
                        this.bestWay[j] = this.map[i, j];
                    }
                    this.bestSolution = solution;
                }
            }
        }

        private void updateMessage()
        {
            //计算每一只蚂蚁在其每一段路径上留下的信息素增量
            //初始化信息素增量数组
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    this.add[i, j] = 0;
                }
            }

            for (int i = 0; i < M; i++)
            {
                //先算出每只蚂蚁的路线的总距离solu
                double solu = 0;
                for (int a = 0; a < N - 1; a++)
                {
                    solu += this.graph[this.map[i, a], this.map[i, a + 1]];
                }

                double d = this.Q / solu;
                for (int j = 0; j < N - 1; j++)
                {
                    this.add[this.map[i, j], this.map[i, j + 1]] += d;
                }
                //注意由于每一只蚂蚁的起始点是随机设置的，所以从终点到起点也要有增加信息素
                this.add[this.map[i, N - 1], this.map[i, 0]] += d;
            }

            //更新信息素
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    this.phe[i, j] = this.phe[i, j] * this.rout + this.add[i, j];
                    //为信息素设置一个下限值和上限值
                    if (this.phe[i, j] < 0.0001)
                    {
                        this.phe[i, j] = 0.0001;
                    }
                    if (this.phe[i, j] > 20)
                    {
                        this.phe[i, j] = 20;
                    }
                }
            }
        }

        private void resetRoute()
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    this.map[i, j] = -1;
                    this.vis[i, j] = 0;
                }
            }
        }
        public int[] FindingWay(int Begin)
        {
            SetBegin(Begin);
            choiceRoute();
            getBestWay();
            updateMessage();
            resetRoute();
            return bestWay;
        }
    }
}
