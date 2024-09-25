using System;

namespace BasicEvents
{
    // define the delegate for the event handler
    public delegate void ValueChangedHandler(string value);

    class EventPublisher
    {
        private string theVal;

        // TODO: declare the event
        public event ValueChangedHandler valueChanged;

        public string Val
        {
            set {
                this.theVal = value;
                // TODO: when the value changes, fire the event
                this.valueChanged(theVal);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // TODO: use a named function as an event handler
            EventPublisher obj = new EventPublisher();
            // obj.valueChanged += obj_valueChanged;

            // TODO: use an anonymous delegate as an event handler
            obj.valueChanged += delegate (string s)
            {
                Console.WriteLine($"Value changed: {s}");
            };

            string str;
            do {
                Console.WriteLine("Enter a value: ");
                str = Console.ReadLine();
                if (!str.Equals("exit")) {
                    obj.Val = str;
                }
            } while (!str.Equals("exit"));
            Console.WriteLine("Goodbye!");
        }

        // This function will be called when the value changes in the EventPublisher class
        static void obj_valueChanged(string value)
        {
            Console.WriteLine("The value changed to {0}", value);
        }
    }
}
