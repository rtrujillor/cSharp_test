using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublishSubscribe
{
    // main program class
    class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber subscriber1 = new Subscriber("subscriber1", pub);
            Subscriber subscriber2 = new Subscriber("subscriber2", pub);

            // Call the methods that raises the events.
            pub.Started();
            pub.Completed();

            // Keep the console window open
            Console.WriteLine("Press Enter to close this window.");
            Console.ReadLine();
        }
    }
    
    // Class to hold custom event info 
    public class CustomEventArguments : EventArgs
    {
        private string message;

        public CustomEventArguments(string s)
        {
            message = s;
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
    
    // Publisher class
    public class Publisher
    {
        // Declare the event 
        public event EventHandler<CustomEventArguments> RaiseCustomEvent;

        public void Started()
        {
            OnRaiseCustomEvent(new CustomEventArguments(" Publisher Started!!"));

        }
        
        public void Completed()
        {
            OnRaiseCustomEvent(new CustomEventArguments("Publisher Completed!!"));

        }
        
         protected virtual void OnRaiseCustomEvent(CustomEventArguments e)
        {
            EventHandler<CustomEventArguments> handler = RaiseCustomEvent;

            if (handler != null)
            {
                e.Message += String.Format(" at {0}", DateTime.Now.ToString());

                handler(this, e);
            }
        }
        
    }
    
    // Subscriber class
    public class Subscriber
    {
        private string id;

        public Subscriber(string ID, Publisher pub)
        {
            id = ID;
            // Subscribe to the event
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        // Define what actions to take when the event is raised. 
        void HandleCustomEvent(object sender, CustomEventArguments e)
        {
            Console.WriteLine(" Subscriber " + id + " received this message: {0}", e.Message);
        }
    }
        
}
