using System;
using System.Collections.Generic;
using RGM.Items;

namespace RGM.General.EventHandling
{

    public static class EventHandler
    {
        private static readonly List<dEvents> eventList = new List<dEvents>();
        private static readonly Dictionary<dEvents, Action<dEvents>> subscribers = new Dictionary<dEvents, Action<dEvents>>();

        public static void checkEvents()
        {
            foreach (dEvents e in eventList)
            {
                
                foreach (var subscriber in subscribers)
                {
                    if (subscriber.Key == e)
                    {
                        subscriber.Value(e);
                    }
                }
                
            }
        }
        
        public static void subscribe(BaseItem item, dEvents e)
        {
            subscribers.Add(e, item.activate);
        }
        
        public static void clearEvents()
        {
            eventList.Clear();
        }
        
        public static void fireEvent(dEvents e)
        {
            eventList.Add(e);
        }
    }
}