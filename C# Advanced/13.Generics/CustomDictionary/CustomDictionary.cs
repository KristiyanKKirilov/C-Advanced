using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    public class CustomDictionary<TKey, TValue>
    {
        private List<TKey> keys;
        private List<TValue> values;

        public CustomDictionary()
        {
            keys = new List<TKey>();
            values = new List<TValue>();
        }
        public void Add(TKey key, TValue value)
        {
            keys.Add(key);
            values.Add(value);
        }

        public TValue this[TKey index]
        {
            get
            {
                int found = keys.IndexOf(index);
                return values[found];
            }
        }

    }
}
