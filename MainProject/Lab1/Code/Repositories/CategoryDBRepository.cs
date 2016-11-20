using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CST465
{
    public class CategoryDBRepository : IDataEntityRepository<CategoryData>
    {
        public CategoryData Get(int id)
        {
            CategoryData category = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aura"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * From Category Where ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (category == null)
                        {
                            category = new CategoryData
                            {
                                ID = (int)reader["ID"],
                                Name = (string)reader["CategoryName"]
                            };
                        }
                        else
                        {
                            throw new InvalidOperationException("Category data table contains more than one of id: " + id.ToString());
                        }
                    }
                }
            }


            return category;
        }

        public List<CategoryData> GetList()
        {
            List<CategoryData> categoryList = new List<CategoryData>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aura"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    command.CommandText = "Select * From Category";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        categoryList.Add(new CategoryData
                        {
                            ID = (int)reader["ID"],
                            Name = (string)reader["CategoryName"]
                        });

                    }
                }
            }

            return categoryList;
        }

        public void Save(CategoryData entity)
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
                        command.CommandText = "INSERT into Category (CategoryName) Values (@CategoryName)";
                    }
                    else
                    {
                        failMessage = "Update operation failed";
                        command.CommandText = "UPDATE Category SET CategoryName = @CategoryName WHERE ID = @ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }

                    command.Parameters.AddWithValue("@CategoryName", entity.Name);

                    if (command.ExecuteNonQuery() < 1)
                    {
                        throw new InvalidOperationException(failMessage);
                    }

                }
            }
        }

        public void Delete(CategoryData entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aura"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    command.CommandText = "Delete Category WHERE ID = @ID";
                    command.Parameters.AddWithValue("@ID", entity.ID);

                    if (command.ExecuteNonQuery() < 1)
                    {
                        throw new InvalidOperationException("Unable to delete category");
                    }

                }
            }
        }
    }
}