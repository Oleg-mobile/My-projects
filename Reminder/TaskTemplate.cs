using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    public enum TaskType { Important, Usual, Special }
    internal class TaskTemplate
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TaskType Type { get; set; }
    }
}
