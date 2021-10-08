using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Reflection;
using Plugin.Infrastructure;

namespace AppForFixingMaterial
{
    /// <summary>
    /// Подписчик. Содержит метод - обработчик события
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {

            EventPublisher eventPublisher = new EventPublisher();
            Sayer sayer = new Sayer();

            // Подписывам методы на события EasyEvent, SimpleEvent и CustomEvent
            eventPublisher.EasyEvent   += sayer.SayHello;
            eventPublisher.EasyEvent   += () => { Console.WriteLine("Привет!"); };
            eventPublisher.SimpleEvent += (o, e) => { Console.WriteLine($"Первое число больше или равно второму. Событие: {e.EventName}"); };
            eventPublisher.CustomEvent += (o, e) => { Console.WriteLine("Первое число меньше второго."); };

            Console.WriteLine("Ведите первое число");
            int firstNumber = int.Parse(Console.ReadLine()); ;
            Console.WriteLine("Ведите второе число");
            int secondNumber = int.Parse(Console.ReadLine()); ;

            eventPublisher.CompareNumbers(firstNumber, secondNumber);

            Console.ReadLine();

            //------------------------------------------------------------

            // Подключаем плагин
            InitializePlugin();

        }

        private static void InitializePlugin()
        {
            // Список путей файлов сборок (dll)
            var files = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.dll", 
                SearchOption.TopDirectoryOnly);

            // Загружаем сборки
            foreach (var file in files)
            {
                var asm = Assembly.LoadFile(file);
                // Получаем типы данных сборки (плагина), которые классы и реализуют наш интерфейс
                var pluginTypes = asm.GetTypes().Where(x => x.IsClass && 
                typeof(IPlugin).IsAssignableFrom(x));

                foreach (var pluginType in pluginTypes)
                {
                    IPlugin plugin = (IPlugin) Activator.CreateInstance(pluginType);
                    // Помещаем куда-либо (в словарь) plugin.Title и (sender, args) => plugin.DoSomething()
                }
            }

        }
    }
}
