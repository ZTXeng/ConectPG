using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

namespace LinkPG
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            conn.Open();
            var comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = System.Data.CommandType.Text;
            comm.CommandText = "SELECT * FROM public.student";
            var dr = comm.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            gird1.ItemsSource = dt.DefaultView;
            comm.Dispose();
            conn.Close();
        }
    }
}
