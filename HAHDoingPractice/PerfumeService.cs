using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAHDoingPractice;

public class PerfumeService
{

    private readonly SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "HAHDoingPracticeDb",
        UserID = "sa",
        Password = "sa@123",
        TrustServerCertificate = true,
    };

    public void GetAllPerfumes()
    {
        SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
        connection.Open();

        string query = "select * from tbl_perfume";

        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Company: {reader["company"]}, Price: {reader["price"]}, Quantity: {reader["quantity"]}");
        }

        connection.Close();
    }

    public void GetPerfumeById()
    {
        Console.WriteLine("Enter Perfume Id : ");
        int id = int.Parse(Console.ReadLine()!);

        SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
        connection.Open();

        string query = $"select * from tbl_perfume where id = @id ";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id); 
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Console.WriteLine($"ID: {reader["id"]}, " +
                              $"Name: {reader["name"]}, Company: {reader["company"]}, Price: {reader["price"]}, Quantity: {reader["quantity"]}");
        }
        else
        {
            Console.WriteLine("Perfume not found.");
        }

        connection.Close();
    }

    public void CreatePerfume()
    {
        Console.WriteLine("Enter Perfume Name : ");
        string name = Console.ReadLine()!;

        Console.WriteLine("Enter Perfume Company : ");
        string companyName = Console.ReadLine()!;

        Console.WriteLine("Enter Perfume Price : ");
        decimal price = decimal.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Perfume Quanity : ");
        string quantity = Console.ReadLine()!;

        SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
        connection.Open();

        string query = "INSERT INTO tbl_perfume (name, company, price, quantity) VALUES (@name, @company, @price, @quantity)";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@company", companyName);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.Parameters.AddWithValue("@quantity", quantity);

        int result = cmd.ExecuteNonQuery();
        connection.Close();

        Console.WriteLine("Perfume Created Successfully.");

    }

    public void UpdatePerfume()
    {
        Console.WriteLine("Enter Id : ");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Perfume Name : ");
        string name = Console.ReadLine()!;

        Console.WriteLine("Enter Perfume Company : ");
        string companyName = Console.ReadLine()!;

        Console.WriteLine("Enter Perfume Price : ");
        string price = Console.ReadLine()!;

        Console.WriteLine("Enter Perfume Quanity : ");
        string quantity = Console.ReadLine()!;

        SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
        connection.Open();

        string query = "INSERT INTO tbl_perfume (name, company, price, quantity) VALUES (@name, @company, @price, @quantity)";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@companay", companyName);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.Parameters.AddWithValue("@quantity", quantity);

        int result = cmd.ExecuteNonQuery();
        connection.Close();

        if(result > 0)
        {
            Console.WriteLine("Perfume Updated Successfully.");
        }
        else
        {
            Console.WriteLine("This Perfume Not found.");
        }
    }

    public void DeletePerfume()
    {
        Console.WriteLine("Enter Perfume Id : ");
        int id = int.Parse(Console.ReadLine()!);

        SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
        connection.Open();

        string query = "Delete from tbl_Perfume where id = @id";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);

        int result = cmd.ExecuteNonQuery();

        connection.Close();

        if(result > 0)
        {
            Console.WriteLine("Perfume Deleted Successfully.");
        }
        else
        {
            Console.WriteLine("This Perfume Not Found.");
        }
    }
}
