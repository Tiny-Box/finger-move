using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    class PublicV
    {
        public static string abc = "";
        public static Dictionary<string, string> NameToNum = new Dictionary<string, string>();
        public static Dictionary<int, string> NumToName = new Dictionary<int, string>();
        public static double[,] Parent = new double[3, 26];
        public static double[,] Time = new double[3, 26];
        public static double[,] Kind = new double[3, 26];
        public static double[,] Weight_P = new double[1, 26];
        public static double[,] Weight_T = new double[1, 26];
        public static double[,] Weight_K = new double[1, 26];
        public static int[,] Traffic = new int[26, 26];
        public static List<int> Ticket = new List<int>();
        public static int[] Route;
        public static List<string> RouteName = new List<string>();
    }
}
