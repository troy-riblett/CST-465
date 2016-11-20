using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CST465
{
    public class ProductDBRepository : IDataEntityRepository<Product>
    {
        public Product Get(int id)
        {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aura"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * From Product INNER JOIN Category ON Product.CategoryID = Category.ID Where Product.ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (product == null)
                        {
                            product = new Product
                            {
                                ID = (int)reader["Product.ID"],
                                Name = (string)reader["ProductName"],
                                //CategoryID = (int)reader["CategoryID"],
                                CategoryName = (string)reader["CategoryName"],
                                Code = (string)reader["ProductCode"],
                                Description = (string)reader["ProductDescription"],
                                Price = (string)reader["Price"],
                                Quantity = (int)reader["Quantity"]
                            };


                        }
                        else
                        {
                            throw new InvalidOperationException("Product data table contains more than one of id: " + id.ToString());
                        }
                    }
                }
            }


            return product;
        }

        public List<Product> GetList()
        {
            List<Product> productList = new List<Product>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aura"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    command.CommandText = "Select Product.ID as PID, ProductName as PName, CategoryName as CName, ProductCode as PCode, ProductDescription as PDesc, Price, Quantity From Product INNER JOIN Category ON Product.CategoryID = Category.ID";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        productList.Add(new Product
                        {
                            ID = (int)reader["PID"],
                            Name = (string)reader["PName"],
                            //CategoryID = (int)reader["CategoryID"],
                            CategoryName = (string)reader["CName"],
                            Code = (string)reader["PCode"],
                            Description = (string)reader["PDesc"],
                            Price = reader["Price"].ToString(),
                            Quantity = (int)reader["Quantity"]
                        });

                    }
                }
            }

            return productList;
        }

        public void Save(Product entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aura"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    String failMessage = "";

                    if (entity.ID == 0)
                    {
                        failMessage = "Insert operation failed";
                        command.CommandText = "INSERT into Product (ProductName, CategoryID, ProductCode, ProductDescription, Price, Quantity) " +
                            "Values (@ProductName, (Select ID FROM Category WHERE CategoryName = @CategoryName), @ProductCode, @ProductDescription, @Price, @Quantity)";
                    }
                    else
                    {
                        failMessage = "Update operation failed";
                        command.CommandText = "UPDATE Product SET ProductName = @ProductName, CategoryID = (Select ID From Category WHERE CategoryName = @CategoryName), " +
                            "ProductDescription = @ProductDescription, Price = @Price, Quantity = @Quantity WHERE ID = @ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }

                    command.Parameters.AddWithValue("@ProductName", entity.Name);
                    command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
                    command.Parameters.AddWithValue("@ProductCode", entity.Code);
                    command.Parameters.AddWithValue("@ProductDescription", entity.Description);
                    command.Parameters.AddWithValue("@Price", entity.Price);
                    command.Parameters.AddWithValue("@Quantity", entity.Quantity);

                    if (command.ExecuteNonQuery() < 1)
                    {
                        throw new InvalidOperationException(failMessage);
                    }

                }
            }
        }

        public void Delete(Product entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aura"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    command.CommandText = "Delete Product WHERE ID = @ID";
                    command.Parameters.AddWithValue("@ID", entity.ID);

                    if (command.ExecuteNonQuery() < 1)
                    {
                        throw new InvalidOperationException("Unable to delete product");
                    }

                }
            }
        }
    }
}