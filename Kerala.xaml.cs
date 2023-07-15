using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace tiffin
{
    public class FoodItem
    {
        public string CuisineName { get; set; }
        public string FoodItemName { get; set; }
        public decimal Price { get; set; }
    }

    public partial class kerala : Window
    {
        public ObservableCollection<FoodItem> FoodItems { get; set; }

        public kerala()
        {
            InitializeComponent();
            FoodItems = new ObservableCollection<FoodItem>();
            DataContext = FoodItems;

            // TODO: Replace with your actual connection string.
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT CuisineName, FoodItemName, Price FROM TiffinMenu WHERE CuisineName = 'Kerala Cuisine'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var foodItem = new FoodItem
                            {
                                CuisineName = reader["CuisineName"].ToString(),
                                FoodItemName = reader["FoodItemName"].ToString(),
                                Price = (decimal)reader["Price"]
                            };

                            FoodItems.Add(foodItem);
                        }
                    }
                }
            }
        }

        private void PayNowButton_Click(object sender, RoutedEventArgs e)
        {
            //Add your logic for Pay Now button
            MessageBox.Show("Payment Successful. Your order will be delivered in 2 hours. Our delivery agent will call you when the order is ready.");
        }

        private void CallKitchenButton_Click(object sender, RoutedEventArgs e)
        {
            //Add your logic for Call Kitchen button
            MessageBox.Show("Kitchen Offline now");
        }
    }
}
