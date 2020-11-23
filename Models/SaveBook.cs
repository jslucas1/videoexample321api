using System.Data.SQLite;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class SaveBook : IInsertBook, IUpdateBook
    {
        public void InsertBook(Book value)
        {

            // string cs = @"URI=file:C:\Users\jslucas\source\repos\mis321\database\book.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen){
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"INSERT INTO books(title, author) VALUES(@title, @author)";
                cmd.Parameters.AddWithValue("@title",value.Title);
                cmd.Parameters.AddWithValue("@author",value.Author);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }

        public void UpdateBook(Book value)
        {

            // string cs = @"URI=file:C:\Users\jslucas\source\repos\mis321\database\book.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen){
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"UPDATE books SET title = @title, author = @author WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", value.Id);
                cmd.Parameters.AddWithValue("@title",value.Title);
                cmd.Parameters.AddWithValue("@author",value.Author);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }

            
        }
    }
}