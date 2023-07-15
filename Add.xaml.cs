using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;

namespace tiffin
{
    public partial class AddPropertyDetails : Window
    {
        private readonly string _agentIdentifier;
        private readonly Property _propertyToEdit;

        public AddPropertyDetails(string agentIdentifier, Property propertyToEdit = null)
        {
            InitializeComponent();
            _agentIdentifier = agentIdentifier;
            _propertyToEdit = propertyToEdit;

            if (_propertyToEdit != null)
            {
                PropertyNameTextBox.Text = _propertyToEdit.PropertyName;
                LocationTextBox.Text = _propertyToEdit.Location;
                PriceTextBox.Text = _propertyToEdit.Price.ToString();
            }
        }

        private void SavePropertyDetails(string propertyName, string location, decimal price)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            string targetTable = _agentIdentifier == "Agent1" ? "PropertyDetails" : "PropertyDetails2";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query;

                if (_propertyToEdit == null)
                {
                    query = $"INSERT INTO {targetTable} (PropertyName, Location, Price) VALUES (@PropertyName, @Location, @Price)";
                }
                else
                {
                    query = $"UPDATE {targetTable} SET PropertyName=@PropertyName, Location=@Location, Price=@Price WHERE PropertyID=@PropertyID";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (_propertyToEdit != null)
                    {
                        command.Parameters.AddWithValue("@PropertyID", _propertyToEdit.PropertyID);
                    }

                    command.Parameters.AddWithValue("@PropertyName", propertyName);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Price", price);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string propertyName = PropertyNameTextBox.Text;
            string location = LocationTextBox.Text;
            decimal price = Convert.ToDecimal(PriceTextBox.Text);

            SavePropertyDetails(propertyName, location, price);
            MessageBox.Show("Property details saved successfully.");
            this.Close();
        }
    }

    public class Property
    {
        public int PropertyID { get; set; }
        public string PropertyName { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}
