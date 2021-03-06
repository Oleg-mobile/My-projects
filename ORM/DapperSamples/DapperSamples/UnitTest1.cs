using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace DapperSamples
{
    // готовим модель - описание класса, в который мапим
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30";

        [TestMethod]
        public void TestMethod1()
        {
            // создаём подключение
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var categories = SqlMapper.Query<Category>(
                    connection, "select * from Categories");

                foreach (var cat in categories)
                    Console.WriteLine("{0} {1} | {2}", cat.CategoryID, cat.CategoryName, cat.Description);
            }
        }
    }
}
