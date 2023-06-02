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
            string sSQL = $"INSERT INTO Warehouse VALUES ({product.ProductNumber}, '{product.ProductName}', {product.NetPrice}, {product.GrossPrice}, {product.Qty});";

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
            reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetInt32(4));
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

            string sSQL = $"UPDATE Warehouse SET ProductNumber = {updateProduct.ProductNumber}, ProductName = '{updateProduct.ProductName}', NetPrice = {updateProduct.NetPrice}, GrossPrice = {updateProduct.GrossPrice}, Qty = {updateProduct.Qty} Where ProductNumber = {editedNum};";

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

            string sSQL = $"DELETE FROM Warehouse WHERE ProductNumber = {prodNum};";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// // Read SUM of Warehouse net price
        /// </summary>
        public static void ReadWarehouseNetPriceSum()
        {
            SqlConnection conn = new SqlConnection(strconn);

            string sSQL = $"SELECT SUM(NetPrice) FROM Warehouse;";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

            string showSUM = $"SELECT * FROM Warehouse WHERE (No column name);";

            conn.Open();
            SqlCommand showcommand = new SqlCommand(showSUM, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Total net value of Warehouse is: {0} kr.", reader.GetDouble(0));
            }
            conn.Close();
        }

        /// <summary>
        /// Creates dummy data in the database
        /// </summary>
        public static void CreateDummyData()
        {
            SqlConnection conn = new SqlConnection(strconn);

            string sSQL = $"INSERT INTO Warehouse VALUES ({5}, '{"Søm"}', {200}, {100}, {5});";

            SqlCommand command = new SqlCommand(sSQL, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            conn.Close();
        }

    }
}
