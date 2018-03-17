using System;
using System.Data.SqlClient;

namespace Example.Connection
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"data source=VINÍCIUSRODRIGU\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=ExampleDB");
            connection.Open();

            Console.WriteLine("Choose your option: \n 1 - Find all users; \n 2 - Update user; \n 3 - Change user");
            string options = Console.ReadLine();

            switch (options)
            {
                default:
                    Console.WriteLine("Option invalid");
                    break;

                case "1":
                    string strQuerySelect = "SELECT * FROM Users";
                    SqlCommand sqlCommandSelect = new SqlCommand(strQuerySelect, connection);
                    SqlDataReader dataReader = sqlCommandSelect.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Console.WriteLine("Id:{0}, Name:{1}, Office:{2}, Date:{3}", dataReader["UserId"], dataReader["Name"], dataReader["Office"], dataReader["Date"]);
                    }
                    break;

                case "2":
                    string strQueryUpdate = "UPDATE Users SET name = 'Danilo' WHERE UserId = 1";
                    SqlCommand sqlCommandUpdate = new SqlCommand(strQueryUpdate, connection);
                    sqlCommandUpdate.ExecuteNonQuery();
                    Console.WriteLine("Successfully changed data");
                    break;

                case "3":
                    string strQueryDelete = "DELETE FROM Users WHERE UserId = 1";
                    SqlCommand sqlCommandDelete = new SqlCommand(strQueryDelete, connection);
                    sqlCommandDelete.ExecuteNonQuery();
                    Console.WriteLine("Successfully deleted data");
                    break;
                case "4":
                    Console.WriteLine("Enter the username");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter the office");
                    string office = Console.ReadLine();

                    Console.WriteLine("Enter the date");
                    string date = Console.ReadLine();

                    string strQueryInsert = String.Format("INSERT INTO Users(Name, Office, Date) VALUES('{0}', '{1}', '{2}')", name, office, date);
                    SqlCommand sqlCommandInsert = new SqlCommand(strQueryInsert, connection);
                    sqlCommandInsert.ExecuteNonQuery();
                    Console.WriteLine("Successfully inserted data");
                    break;
            }
        }
    }
}
