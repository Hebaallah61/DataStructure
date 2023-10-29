using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash.HashTable
{
    public class HashTable<TKey,TValue> where TKey: class
    {
        KeyValuePair[] entries;
        int initialSize;
        int entriesCount;

        public HashTable()
        {
            initialSize = 3;
            entriesCount = 0;
            entries = new KeyValuePair[initialSize];
        }

        public int GetHash(TKey key)
        {
            uint OffsetBasis = 2166136261;
            uint FNVPrime = 16777619;
            byte[] data = Encoding.ASCII.GetBytes(key.ToString());
            
            uint hash = OffsetBasis;
            for (int i = 0; i < data.Length; i++)
            {
                hash = hash ^ data[i];
                hash = hash * FNVPrime;
            }

            Console.WriteLine("[hash] " + key.ToString() + " " + hash + " " + hash.ToString("x")
                    + " " + hash % (uint)this.entries.Length);

            return (int)(hash % (uint)entries.Length);
        }

        public int CollisionHandling(TKey key, int hash, bool set)
        {
            int newHash;
            for(int i=1; i < entries.Length; i++)
            {
                newHash= (hash+i) % (entries.Length);
                Console.WriteLine("[coll] " + key.ToString()+ " " + hash + ", new hash: " + newHash);
                if(set && entries[newHash]==null || entries[newHash].Key == key)
                {
                    return newHash;
                }
                else if(!set && entries[newHash].Key == key)
                {
                    return newHash;
                }
                else
                {
                    continue;
                }
            }
            return -1;
        }

        public void AddEntries(TKey key, TValue value)
        {
            int hash = GetHash(key);
            var item = entries[hash];
            if (item != null && item.Key != key)
            {
                hash = CollisionHandling(key, hash, true);
            }
            if (hash == -1)
            {
                throw new Exception("Invalid Hashtable!");
            }
            if (entries[hash] == null)
            {
                KeyValuePair newPair = new KeyValuePair(key, value);
                entries[hash] = newPair;
                entriesCount++;
            }
            else if (entries[hash].Key == key)
            {
                entries[hash].Value = value;
            }
            else
            {
                throw new Exception("Invalid Hashtable!");
            }
        }
        public void Set(TKey key, TValue value)
        {
            ResizeOrNot();
            AddEntries(key, value);
        }

        public TValue Get(TKey key)
        {
            var hash = GetHash(key);
            var item= entries[hash];
            if (item !=null && item.Key!= key)
            {
                hash = CollisionHandling(key, hash, false);
            }
            if(hash == -1)
            {
                return default(TValue);
            }
            if(item.Key == key)
            {
                return entries[hash].Value;
            }
            else
            {
                throw new Exception("Invalid Hashtable(..)");
            }
        }

        public Boolean Remove(TKey key)
        {
            if (key == null) return false;
            var hash = GetHash(key);

            if (entries[hash] != null && entries[hash].Key == key)
            {
                entries[hash] = null;
                entriesCount--;
                var entriesCopy = new KeyValuePair[entries.Length];
                Array.Copy(entries, entriesCopy, entriesCopy.Length);
                for (int i = 0; i < entries.Length; i++)
                {
                    entries[i] = null;
                }
                entriesCount = 0;
                foreach (var entry in entriesCopy)
                {
                    if (entry != null)
                    {
                        AddEntries(entry.Key, entry.Value);
                    }
                }

                Console.WriteLine("Remove one element true");
                return true;
            }
            return false;
        }

        private void ResizeOrNot()
        {
            if (entriesCount < entries.Length - 1)
            {
                return;
            }
            var newSize =  entries.Length * 2;
            var entriesCopy= new KeyValuePair[entries.Length];
            Array.Copy(entries, entriesCopy, entriesCopy.Length);
            entries= new KeyValuePair[newSize];
            entriesCount = 0;
            for(int i = 0;i < entriesCopy.Length;i++)
            {
                if (entriesCopy[i] == null) continue;
                AddEntries(entriesCopy[i].Key, entriesCopy[i].Value);
            }
            Console.WriteLine($"Resize Dictionary From {entries.Length}: To {newSize}");
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
