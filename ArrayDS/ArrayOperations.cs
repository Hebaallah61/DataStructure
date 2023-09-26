using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDS
{
    public class ArrayOperations
    {
        public void Resize<T>(ref T[] myArr,int newSize)
        {
            if(newSize == 0) return;
            if(myArr == null) return;
            if (newSize == myArr.Length) return;

            T[] newArr = new T[newSize];
            Buffer.BlockCopy(myArr, 0, newArr, 0, Buffer.ByteLength(myArr));
            myArr= newArr;
        }

        public T GetAt<T>(T[] source, int index, int sizeOf)
        {
            if (index < 0) return default(T);
            ref byte zeroAdrr = ref MemoryMarshal.GetArrayDataReference((Array)source);
            ref byte indexRef = ref Unsafe.Add(ref zeroAdrr, index * sizeOf);
            ref T item = ref Unsafe.As<byte, T>(ref indexRef);
            return item;
        }
    }
}
