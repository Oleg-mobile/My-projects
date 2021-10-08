using System;

namespace AppForFixingMaterial
{
    /// <summary>
    /// Предоставляет данные для событий, такие как Имя события.
    /// </summary>
    public class MyEventArgs : EventArgs
    {
        /// <summary>
        /// Имя события
        /// </summary>
        public string EventName { get; set; }

    }


}
