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

namespace _05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection("data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user45_db;user id=user45_db;password=user45;MultipleActiveResultSets=True;App=EntityFramework");

        private void LoadGrid()
        {

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Client", con);
            con.Open();
            Label2.Content = command.ExecuteScalar().ToString();
            con.Close();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "")
            {
                Label1.Content = TextBox1.Text;
                SqlCommand cmd = new SqlCommand("select top " + TextBox1.Text + " * from [Client]", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGridView1.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else 
            {
                MessageBox.Show("Введите необходимое количество строк!");
            }
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1_Copy.Text == "ж")
            {
                SqlCommand cmd = new SqlCommand("SELECT top " + TextBox1.Text + " * FROM Client WHERE GenderCode = '1'", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGridView1.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else
            {
                if (ComboBox1_Copy.Text == "м")
                {
                    SqlCommand cmd = new SqlCommand("SELECT top " + TextBox1.Text + " * FROM Client WHERE GenderCode = '2'", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                    sdr.Fill(dt);
                    dataGridView1.ItemsSource = dt.DefaultView;
                    con.Close();

                }
                else
                {
                    if (ComboBox1_Copy.Text == "все")
                    {
                        SqlCommand cmd = new SqlCommand("SELECT top " + TextBox1.Text + " * FROM Client", con);
                        DataTable dt = new DataTable();
                        con.Open();
                        SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                        sdr.Fill(dt);
                        dataGridView1.ItemsSource = dt.DefaultView;
                        con.Close();

                    }
                }
            }
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox2.Text != "")
            {
                SqlCommand cmd = new SqlCommand("select top " + TextBox1.Text + " * from [Client] WHERE FirstName = '" + TextBox2.Text + "' or LastName ='" + TextBox2.Text + "' or Patronymic ='" + TextBox2.Text + "' or Email ='" + TextBox2.Text + "' or Phone ='" + TextBox2.Text + "'", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGridView1.ItemsSource = dt.DefaultView;
                con.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT top " + TextBox1.Text + " * FROM Client", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGridView1.ItemsSource = dt.DefaultView;
                con.Close();
            }
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBox1.IsChecked == true) 
            {
                SqlCommand cmd = new SqlCommand("SELECT top " + TextBox1.Text + " * FROM Client ORDER BY FirstName", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGridView1.ItemsSource = dt.DefaultView;
                con.Close();
            }

        }

        private void CheckBox3_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBox3.IsChecked == true)
            {
                SqlCommand cmd = new SqlCommand(" SELECT* FROM Client ORDER BY RegistrationDate DESC", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(dt);
                dataGridView1.ItemsSource = dt.DefaultView;
                con.Close();
            }

           
        }
    }
}
