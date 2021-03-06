﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CST465
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {
        public void Delete(BlogPost entity)
        {
            throw new NotImplementedException();
        }

        public BlogPost Get(int id)
        {
            BlogPost blog = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aura"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * From Blog Where ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (blog == null)
                        {
                            blog = new BlogPost
                            {
                                Author = (string)reader["Author"],
                                Content = (string)reader["Content"],
                                ID = (int)reader["ID"],
                                Timestamp = (DateTime)reader["Timestamp"],
                                Title = (string)reader["Title"]
                            };
                        }
                        else
                        {
                            throw new InvalidOperationException("Blog post data table contains more than one of id: " + id.ToString());
                        }
                    }
                }
            }


            return blog;
        }

        public List<BlogPost> GetList()
        {
            List<BlogPost> blogList = new List<BlogPost>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aura"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    command.CommandText = "Select * From Blog";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        blogList.Add(new BlogPost
                        {
                            Author = (string)reader["Author"],
                            Content = (string)reader["Content"],
                            ID = (int)reader["ID"],
                            Timestamp = (DateTime)reader["Timestamp"],
                            Title = (string)reader["Title"]
                        });

                    }
                }
            }

            return blogList;
        }

        public void Save(BlogPost entity)
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
                        command.CommandText = "INSERT into Blog (Author, Content, Title) Values (@Author, @Content, @Title)";
                    }
                    else
                    {
                        failMessage = "Update operation failed";
                        command.CommandText = "UPDATE Blog SET Author = @Author, Content = @Content, Title=@Title WHERE ID = @ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }

                    command.Parameters.AddWithValue("@Author", entity.Author);
                    command.Parameters.AddWithValue("@Content", entity.Content);
                    command.Parameters.AddWithValue("@Title", entity.Title);

                    if (command.ExecuteNonQuery() < 1)
                    {
                        throw new InvalidOperationException(failMessage);
                    }

                }
            }
        }
    }
}