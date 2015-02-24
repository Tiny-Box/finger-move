using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace SQL
{
    /// <summary>
    /// Log.xaml 的交互逻辑
    /// </summary>
    public partial class Log : Window
    {
        
        public Log()
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
        private void ButtonS_Click(object sender, RoutedEventArgs e)
        {
            string daily = "";
            daily += title.Text + "\n";
            daily += context.Text + "\n";
            

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = title.Text; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                // Write the string to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter(dlg.FileName.ToString());
                file.WriteLine(daily);

                file.Close();
            }
        }
        private void ButtonQ_Click(object sender, RoutedEventArgs e)
        {
            title.Text = "Title";
            context.Text = "Day1:";

        }
    }
}
