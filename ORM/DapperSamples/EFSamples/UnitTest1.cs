using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EFSamples
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new Model1())
            {
                foreach (var cat in context.Categories)
                    Console.WriteLine("{0} {1} | {2}", cat.CategoryID, cat.CategoryName, cat.Description);
            }
        }
    }
}