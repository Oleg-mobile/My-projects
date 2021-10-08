using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Infrastructure
{
    /// <summary>
    /// Точка расширения для подключения плагинов (сборки)
    /// </summary>
    public interface IPlugin
    {
        // Заголовок
        string Title { get; set; }

        void DoSomething();
    }
}
