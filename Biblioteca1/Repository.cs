using Biblioteca1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Biblioteca1
{
    public class Repository
    {
        const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";


        const string GetAllBooksQuery = "Select * From Books";
        const string InsertBookQuery = @"INSERT INTO Books (Name, AuthorName, ISBN, Year)
            VALUES(@name, @authorName, @isbn, @year);";
        const string DelteBookQuery = @"Delete From Books where Id = @id";

        public List<BookModel> GetBooks()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString;


            SqlCommand command = new SqlCommand(GetAllBooksQuery, connection);
            //command.Parameters.AddWithValue("@pricePoint", paramValue);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<BookModel> bookList = new List<BookModel>();

            while (reader.Read())
            {
                BookModel book = new BookModel();
                book.Id = reader.GetInt32(0);
                book.Name = reader.GetString(1);
                book.AuthorName = reader.GetString(2);
                book.ISBN = reader.GetString(3);
                book.Year = reader.GetInt32(4);

                bookList.Add(book);
            }

            reader.Close();

            connection.Close();

            return bookList;
        }

        public void AddBook(BookModel book)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString;


            SqlCommand command = new SqlCommand(InsertBookQuery, connection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = book.Name;
            command.Parameters.Add("@authorName", SqlDbType.VarChar).Value = book.AuthorName;
            command.Parameters.Add("@isbn", SqlDbType.VarChar).Value = book.ISBN;
            command.Parameters.Add("@Year", SqlDbType.Int).Value = book.Year;

            connection.Open();
            command.ExecuteNonQuery();
            
            connection.Close();
        }

        public void DeleteBook(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString;

            SqlCommand command = new SqlCommand(DelteBookQuery, connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}