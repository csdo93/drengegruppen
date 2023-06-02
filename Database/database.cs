using _230313_SYS_Warehouse_2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230313_SYS_Warehouse_2.Services
{

    public class Database
    {
        // Conntects to the database 
        static string strconn = "Data Source=mssql6.unoeuro.com;Initial Catalog=csdo_dk_db_datamatiker;User ID=csdo_dk;Password=Ecy325kRAHbxham6G94f";


        /// <summary>
        /// Creates an instance of the class Product within the database
        /// </summary>
        /// <param name="product"></param>
        public static void CreateProduct(Models.Product product)
        {
            SqlConnection conn = new SqlConnection(strconn);

            //Sends string of values to DB
            string sSQL = $"INSERT INTO varer VALUES ({product.ProductNumber}, '{product.ProductName}', {product.ProductType}, {product.GrossPrice}, {product.Qty});";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            //Exceutes (INSERT) the values into the database
            command.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Selects and reads the product from the database
        /// </summary>
        /// <param name="enteredProduct"></param>
        public static void ReadProduct(int enteredProduct)
        {
            SqlConnection conn = new SqlConnection(strconn);

            string sSQL = $"SELECT * FROM Warehouse WHERE ProductNumber = {enteredProduct};";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //Column headers with tab [\t] spaces between them
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}",
            reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3), reader.GetInt32(4));
            }
            conn.Close();
        }
        /// <summary>
        /// Updates the product in the database 
        /// </summary>
        /// <param name="editedNum"></param>
        /// <param name="updateProduct"></param>
        public static void UpdateProduct(int editedNum, Models.Product updateProduct)
        {
            SqlConnection conn = new SqlConnection(strconn);

            string sSQL = $"UPDATE varer SET varenr = {updateProduct.ProductNumber}, varenavn = '{updateProduct.ProductName}', varetype = {updateProduct.ProductType}, varepris = {updateProduct.GrossPrice}, varebeholdning = {updateProduct.Qty} Where varenr = {editedNum};";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Deletes a product from the database
        /// </summary>
        /// <param name="prodNum"></param>
        public static void DeleteProduct(int prodNum)
        {
            SqlConnection conn = new SqlConnection(strconn);

            string sSQL = $"DELETE FROM varer WHERE varenr = {prodNum};";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// // Reads the sum of the wares' prices
        /// </summary>
        public static void ReadWarehouseNetPriceSum()
        {
            SqlConnection conn = new SqlConnection(strconn);

            string sSQL = $"SELECT SUM(varepris) FROM varer;";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

            string showSUM = $"SELECT * FROM varer WHERE (No column name);";

            conn.Open();
            SqlCommand showcommand = new SqlCommand(showSUM, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Total net value of Wares is: {0} kr.", reader.GetDouble(0));
            }
            conn.Close();
        }

        /// <summary>
        /// Creates an instance of the class Customer within the database
        /// </summary>
        /// <param name="customer"></param>
        public static void CreateCustomer(Models.CustomerModel customer)
        {
            SqlConnection conn = new SqlConnection(strconn);

            //Sends string of values to DB
            string sSQL = $"INSERT INTO kunder VALUES ({customer.CustomerNumber}, '{customer.FirstName}', {customer.LastName}, {customer.MobileNumber}, {customer.LeftStrength}, {customer.RightStrength});";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            //Exceutes (INSERT) the values into the database
            command.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Selects and reads the customer from the database
        /// </summary>
        /// <param name="enteredCustomer"></param>
        public static void ReadCustomer(int enteredCustomer)
        {
            SqlConnection conn = new SqlConnection(strconn);

            string sSQL = $"SELECT * FROM kunder WHERE kundenr = {enteredCustomer};";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //Column headers with tab [\t] spaces between them
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t{5}",
            reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
            }
            conn.Close();
        }
        /// <summary>
        /// Updates the customer in the database 
        /// </summary>
        /// <param name="editedNum"></param>
        /// <param name="updateCustomer"></param>
        public static void UpdateProduct(int editedNum, Models.CustomerModel updateCustomer)
        {
            SqlConnection conn = new SqlConnection(strconn);

            string sSQL = $"UPDATE kunder SET kundenr = {updateCustomer.CustomerNumber}, fornavn = '{updateCustomer.FirstName}', efternavn = {updateCustomer.LastName}, telefon = {updateCustomer.MobileNumber}, vsyn = {updateCustomer.LeftStrength}, hsyn = {updateCustomer.RightStrength} Where kundenr = {editedNum};";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Deletes a customer from the database
        /// </summary>
        /// <param name="prodNum"></param>
        public static void DeleteCustomer(int custNum)
        {
            SqlConnection conn = new SqlConnection(strconn);

            string sSQL = $"DELETE FROM kunder WHERE kundenr = {custNum};";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
