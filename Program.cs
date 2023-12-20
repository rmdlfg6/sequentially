using System;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
                 
        var con = new SqlConnection(@"Data Source=DESKTOP-FPCMKB1; Initial Catalog=TSQL2012; Integrated Security=true;TrustServerCertificate=True");
        con.Open();

        var sw = new Stopwatch();
        sw.Start();

        string sql = "SELECT categoryname FROM Production.Categories UNION ALL SELECT productname FROM Production.Products UNION ALL SELECT address FROM Production.Suppliers";
        using var cmd = new SqlCommand(sql, con);

        using SqlDataReader rdr = cmd.ExecuteReader();
        var res = "";

        while (rdr.Read())
            {
                res = rdr.GetString(0);
                Console.WriteLine(res);                               
            }

        sw.Stop();
        Console.WriteLine($"Время выполнения: {sw.Elapsed.Milliseconds} мс");
    }
}
