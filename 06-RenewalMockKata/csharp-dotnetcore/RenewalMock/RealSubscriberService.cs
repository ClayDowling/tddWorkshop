using System;
using System.Collections.Generic;

namespace Katas
{
    public class RealSubscriberService : ISubscriberService
    {
        
        public List<string> GetSubscribersThatWillExpireBetweenNowAndDate(DateTime selectedDate)
        {
            Random random = new Random();
            if (random.NextDouble() < 0.5)
            {
                return null;
            }
            else
            {
                String[] strings = { "mysterious email" + random.Next() };
                return new List<string>(strings);
            }
        }
    }
}
