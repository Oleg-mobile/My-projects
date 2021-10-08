using System;

namespace AppForFixingMaterial
{
    // Свой делегат - ссылка на метод
    public delegate void CustomDelegate(object sender, System.EventArgs eventArgs);
    public delegate void EasyDelegate();

    /// <summary>
    /// Издатель. Содержет метод, который вызывает событие
    /// </summary>
    class EventPublisher
    {
        // Объявление события (стандартный делегат)
        public event EventHandler<MyEventArgs> SimpleEvent;
        public event CustomDelegate CustomEvent;
        public event EasyDelegate EasyEvent;

        /// <summary>
        /// Сравнивает два числа
        /// </summary>
        /// <param name="firstNumber">Первое число</param>
        /// <param name="secondNumber">Второе число</param>
        public void CompareNumbers(int firstNumber, int secondNumber)
        {
            EasyEvent?.Invoke();

            if (firstNumber >= secondNumber)
            {
                var evArgs = new MyEventArgs { EventName = "SimpleEvent" };
                // Случилось событие - попались равные числа.
                // Вызываем делегат и проверяем его на null
                // Будут вызваны все методы, подписанные на это событие
                // this - ссылка на объект издателя
                // evArgs - дополнительная информация о событии.
                SimpleEvent?.Invoke(this, evArgs);
            }
            else
            {
                // new EventArgs() - дополнительная информация о событии. Здесь пусто
                CustomEvent?.Invoke(this, new EventArgs());
            }
        }
    }


}
