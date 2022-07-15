using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Kursach_5sem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string Connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StructureAuto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nameTable = "";
            if (ComboBoxAllTables.Text == "ДВИГАТЕЛЬ")
                nameTable = "Engine";
            if (ComboBoxAllTables.Text == "КПП")
                nameTable = "KPP";
            if (ComboBoxAllTables.Text == "ЦВЕТ")
                nameTable = "Color";
            if (ComboBoxAllTables.Text == "МОДЕЛЬ АВТОМОБИЛЯ")
                nameTable = "Model";
            if (ComboBoxAllTables.Text == "ЭЛЕМЕНТ КОМПЛЕКТАЦИИ")
                nameTable = "ElementComplectation";
            if (ComboBoxAllTables.Text == "КОЛЕСО")
                nameTable = "Wheel";
            if (ComboBoxAllTables.Text == "МАРКА АВТОМОБИЛЯ")
                nameTable = "Brand";
            if (ComboBoxAllTables.Text == "КУЗОВ")
                nameTable = "Body";
            if (ComboBoxAllTables.Text == "РЕГИСТРАЦИОННЫЕ ДАННЫЕ АВТОМОБИЛЯ")
                nameTable = "RegisterDataOfAuto";
            if (nameTable != "")
            {
                DataTable dt = LoadData($"SELECT * FROM {nameTable}");
                viewinfo.ItemsSource = dt.DefaultView;
                
            }
            else
                MessageBox.Show("Нет таблицы");
        }
        private DataTable LoadData(string s)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Connection);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(s, conn);
                SqlDataReader read = cmd.ExecuteReader();
                using (read)
                {
                    using (read)
                    {
                        dt.Load(read);
                    }
                }
            }

            return dt;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBoxDelete.Text != "")
            {
                try
                {
                    string s = $"delete from RegisterDataOfAuto where vin=N'{textBoxDelete.Text}'";
                    SqlConnection conn = new SqlConnection(Connection);
                    using (conn)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(s, conn);
                        SqlDataReader read = cmd.ExecuteReader();
                    }
                    MessageBox.Show("Успешно!");
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
            else
                MessageBox.Show("Введите существующие данные!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(textBoxNumberTypeEngine.Text=="" || textBoxVolume.Text == "" || textBoxHP.Text == "")
            {
                MessageBox.Show("Введите корректные данные.");
            }
            string vin = textBoxNumberTypeEngine.Text;
            string volume = textBoxVolume.Text;
            string hp = textBoxHP.Text;
            string s = $"insert into Engine values(N'{vin}',{volume},{hp})";
            SqlConnection conn = new SqlConnection(Connection);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(s, conn);
                try
                {
                    SqlDataReader read = cmd.ExecuteReader();
                }
                catch
                {
                    MessageBox.Show("Введены некорректные данные.");
                }
            }
            MessageBox.Show("Успешно!");
        }

        private void viewinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
