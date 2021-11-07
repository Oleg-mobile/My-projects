using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LinqToDB.Mapping;
using LinqToDB.Data;
using LinqToDB;
using static LinqToDB.DataProvider.SqlServer.SqlServerProviderAdapter;

namespace Linq2DBSamples
{
    [Table("Categories")] // атрибуты для мапинга
    public class Category
    {
        [Column("CategoryID")]
        [PrimaryKey]
        [Identity] // id из базы
        public int Id { get; set; }
        [Column("CategoryName")]
        public string Name { get; set; }
        [Column]  // тут имя совпадает
        public string Description { get; set; }
    }

    // контекс - аналог точки входа
    public class Northwind : DataConnection
    {
        // конструктор - определяет как делается подключение
        public Northwind() : base("Northwind")  // имя строки подключения в конф. файле
        { }

        // свойство для доступа, дженеринг интерфейс, возвращает категории
        public ITable<Category> Categories { get { return GetTable<Category>(); } }  // для удобства обращения
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var connection = new Northwind())
            {
                foreach (var cat in connection.Categories)
                    Console.WriteLine("{0} {1} | {2}", cat.Id, cat.Name, cat.Description);

            }
        }
    }
}
