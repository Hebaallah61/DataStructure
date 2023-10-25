using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Dictionary
{
    public class Dictionary<TKey, TValue> where TKey : class
    {
        KeyValuePair[] entries;
        int initialSize;
        int entriesCount;

        public Dictionary()
        {
            initialSize = 3;
            entries = new KeyValuePair[initialSize];
        }

        public void Set(TKey key, TValue value)
        {
            var index= entries.FirstOrDefault(e => e != null && e.Key == key);
            if (index != null)
            {
                index.Value = value;
            }
            else
            {
                ResizeOrNot();
                var newKeyValue= new KeyValuePair(key, value);
                entries[entriesCount] = newKeyValue;
                entriesCount++;
            }
        }

        public TValue Get(TKey key)
        {
            var index = entries.FirstOrDefault(e => e != null && e.Key == key);
            if(index != null)
            {
                return index.Value;
            }
            else
            {
                return default;
            }
        }

        public Boolean Remove(TKey key)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i] != null && entries[i].Key == key)
                {
                    entries[i] = entries[entriesCount - 1]; 
                    entries[entriesCount - 1] = null; 
                    entriesCount--;
                    return true;
                }
            }
            return false;
        }

        private void ResizeOrNot()
        {
            if(entriesCount < entries.Length-1)
            {
                return;
            }
            var newSize = initialSize + entries.Length;
            var newEntries= new KeyValuePair[newSize];
            Array.Copy(entries, newEntries, entries.Length);
            Console.WriteLine($"Resize Dictionary From {entries.Length}: To {newSize}");
            entries = newEntries;
        } 

        public int Size()
        {
            return entriesCount;
        }

        public void Print()
        {
            Console.WriteLine($"Size: {Size()}");
            foreach (var entry in entries)
            {
                if (entry != null)
                {
                    Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
                }
            }
        }

        public class KeyValuePair
        {
            TKey key;
            TValue value;
            public TKey Key
            {
                get { return key; }
            }

            public TValue Value
            {
                get { return value; }
                set { value = value; }
            }

            public KeyValuePair(TKey _key, TValue _value)
            {
                key = _key;
                value = _value;
            }
        }
    }
}
