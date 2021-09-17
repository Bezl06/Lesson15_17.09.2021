using System;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;

namespace Lesson15
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=TestDB;Trusted_Connection=true;";
            System.Console.WriteLine("Choose operation Insert(1), SelectAll(2), SelectById(3), Update(4), Delete(5) :");
            int flag = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                switch (flag)
                {
                    case 1:
                        Insert(connection, Person.SetInstance());
                        break;
                    case 2:
                        SelectAll(connection);
                        break;
                    case 3:
                        SelectById(connection, SetId());
                        break;
                    case 4:
                        Update(connection, Person.SetInstance(), SetId());
                        break;
                    case 5:
                        Delete(connection, SetId());
                        break;
                    default:
                        System.Console.WriteLine("ERROR!!!");
                        return;
                }
                System.Console.WriteLine("Completed");
            }
        }
        static void Insert(SqlConnection sqlConnection, Person person)
        {
            string sqlQuery = "INSERT INTO Person(LastName,FirstName,MiddleName,BirthDate) VALUES(@lname,@fname,@mname,@bdate)";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@lname", person.lastName);
            sqlCommand.Parameters.AddWithValue("@fname", person.firstName);
            sqlCommand.Parameters.AddWithValue("@mname", person.middleName);
            sqlCommand.Parameters.AddWithValue("@bdate", person.birthDate);
            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
                System.Console.WriteLine("Successfuly Inserted!");
            else
                System.Console.WriteLine("Eror...");
        }
        static void Update(SqlConnection sqlConnection, Person person, int id)
        {
            string sqlQuery = "UPDATE Person SET LastName=@lname,FirstName=@fname,MiddleName=@mname,BirthDate=@bdate WHERE Id=@id";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@lname", person.lastName);
            sqlCommand.Parameters.AddWithValue("@fname", person.firstName);
            sqlCommand.Parameters.AddWithValue("@mname", person.middleName);
            sqlCommand.Parameters.AddWithValue("@bdate", person.birthDate);
            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
                System.Console.WriteLine("Successfuly Updated!");
            else
                System.Console.WriteLine("Eror...");
        }
        static void Delete(SqlConnection sqlConnection, int id)
        {
            string sqlQuery = $"DELETE FROM Person WHERE Id={id}";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
                System.Console.WriteLine("Successfuly Deleted!");
            else
                System.Console.WriteLine("Eror...");
        }
        static void SelectAll(SqlConnection sqlConnection)
        {
            string sqlQuery = "SELECT * FROM Person";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataReader sqlData = sqlCommand.ExecuteReader();
            if (sqlData.HasRows)
            {
                while (sqlData.Read())
                {
                    System.Console.WriteLine($"Id: {sqlData.GetValue(0)}, LastName: {sqlData.GetValue(1)}, " +
                    $"FirstName: {sqlData.GetValue(2)}, MiddleName: {sqlData.GetValue(3)}, BirthDate: {sqlData.GetValue(4)}");
                }
            }
            else
            {
                System.Console.WriteLine("Nothing...");
            }
            sqlData.Close();
        }
        static void SelectById(SqlConnection sqlConnection, int id)
        {
            string sqlQuery = $"SELECT * FROM Person WHERE Id={id}";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlDataReader sqlData = sqlCommand.ExecuteReader();
            if (sqlData.HasRows)
            {
                while (sqlData.Read())
                {
                    System.Console.WriteLine($"Id: {sqlData.GetValue(0)}, LastName: {sqlData.GetValue(1)}, " +
                    $"FirstName: {sqlData.GetValue(2)}, MiddleName: {sqlData.GetValue(3)}, BirthDate: {sqlData.GetValue(4)}");
                }
            }
            else
            {
                System.Console.WriteLine("Nothing...");
            }
            sqlData.Close();
        }
        static int SetId()
        {
            System.Console.WriteLine("Enter Id : ");
            return int.Parse(Console.ReadLine());
        }
    }
    class Person
    {
        public readonly string firstName, lastName, middleName;
        public readonly DateTime birthDate;
        public Person() { }
        public Person(string fname, string lname, string mname, DateTime bdate)
        {
            firstName = fname;
            lastName = lname;
            middleName = mname;
            birthDate = bdate;
        }
        public static Person SetInstance()
        {
            System.Console.WriteLine("Enter Last Name : ");
            string lastName = Console.ReadLine();
            System.Console.WriteLine("Enter First Name : ");
            string firstName = Console.ReadLine();
            System.Console.WriteLine("Enter Middle Name : ");
            string middleName = Console.ReadLine();
            System.Console.WriteLine("Enter BirthDay MM/DD/YYYY (forExaple:10/25/2021) : ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            return new Person(firstName, lastName, middleName, birthDate);
        }
    }
}
