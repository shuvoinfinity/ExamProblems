using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProductsInformationApp.DLL.DAO;

namespace ProductsInformationApp.DLL.Gateway
{
    class ProductGateway
    {
        private SqlConnection connection;
        public ProductGateway()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
        }

        public string SaveProduct(Product aProduct)
        {
            connection.Open();
            string query = string.Format("INSERT INTO t_product VALUES('{0}','{1}',{2})", aProduct.Code, aProduct.Name,
                aProduct.Quantity);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "insert success";
            return "Product Code must be will in 3 Character and name in 5 Character!";

        }

        public List<Product> ShowProducts()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_product");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Product aProduct = new Product();
                    aProduct.Code = (string) aReader[0];
                    aProduct.Name = (string) aReader[1];
                    aProduct.Quantity = (int) aReader[2];
                    products.Add(aProduct);
                }
                
            }
            connection.Close();
                return products;
        }

        public bool HasThisCode(string code)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_product WHERE ProductCode='{0}'", code);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public bool HasThisName(string name)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_product WHERE ProductName='{0}'", name);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;   
        }
    }
}
