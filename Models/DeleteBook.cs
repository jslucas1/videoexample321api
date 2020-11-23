using System.Data.SQLite;
using API.Models.Interfaces;

namespace API.Models
{
    public class DeleteBook : IDeleteBook
    {
        public void RemoveBook(int id)
        {
            string cs = @"URI=file:C:\Users\jslucas\source\repos\mis321\database\book.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"DELETE FROM books WHERE id=@id";
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}