using Plugin.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlugin
{
    public class MyCustomPlugin : IPlugin
    {
        public MyCustomPlugin()
        {
            Title = "My plugin";
        }
        public string Title { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("My Plugin has executed");
        }

        public int Do(int x, int y)
        {
            var result = DoPrivate(x, y);
            return result;
        }

        private int DoPrivate(int x, int y)
        {
            return x + y;
        }
    }
}
