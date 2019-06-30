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
using System.Data;
using System.Data.SqlClient;

namespace Vault
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<int> ObjectList = new List<int> { };
        public MainWindow()
        {   
            InitializeComponent();
            Console.WriteLine(" ... ");
            Console.WriteLine(ObjectList);
            //canvas__.Background = Brushes;

     
        }

        private void BtnOne_Click(object sender, RoutedEventArgs e)
        {
            int number = 1;
            ObjectList.Add(number);
        }

        private void BtnTwo_Click(object sender, RoutedEventArgs e)
        {
            int number = 2;
            ObjectList.Add(number);
        }

        private void BtnThree_Click(object sender, RoutedEventArgs e)
        {
            int number = 3;
            ObjectList.Add(number);
        }

        private void BtnFour_Click(object sender, RoutedEventArgs e)
        {
            int number = 4;
            ObjectList.Add(number);
        }

        public void VaultDataProcessingSpace()
        {
            int[] ObjArray = ObjectList.ToArray();
            for(int i=0; i < ObjArray.Length; i++)
            {
                txtBox.Text += Convert.ToString(ObjArray[i]);
            }
            
            // SQL Configuration Setting
            string ConnString = "Data Source=(local); Initial Catalog=TacticalDB; Integrated Security=True";
            SqlConnection DataConnection = new SqlConnection(ConnString);
            try
            {
                if (DataConnection.State == ConnectionState.Closed)
                    DataConnection.Open();
                 
                string query = "SELECT * FROM [VaultSecTable]";

                SqlCommand command = new SqlCommand(query, DataConnection);
                command.CommandText = query;
                //command.CommandType = CommandType.Text;
                command.Connection = DataConnection;
                //command.Parameters.AddWithValue("@Code", txtBox.Text);
                
                SqlDataReader reader = command.ExecuteReader();
                //SqlDataAdapter adapter = new SqlDataAdapter(command);
                //DataTable dt = new DataTable();
                //adapter.Fill(dt);
                //Opacity = 01201;
                //Console.WriteLine(dt.Columns[0].ColumnName.ToString());
                //Console.WriteLine(dt.Rows[0].ItemArray.ToString());
                while (reader.Read())
                {
                        MessageBox.Show("Whe have a Match!!  " + reader);
                        txtBox.Text = "";
                        Array.Clear(ObjArray, 0, ObjArray.Length);
                        break;                        
                }
                        Array.Clear(ObjArray, 0, ObjArray.Length);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO Match!!!");
            }

            finally
            {
                DataConnection.Close();
            }
        }
        
        private void BtnDevil_Click(object sender, RoutedEventArgs e)
        {
            VaultDataProcessingSpace();
        }     
    }  
}
    