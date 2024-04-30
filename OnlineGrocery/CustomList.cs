using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery
{
    public  class CustomList<Type>
    {
        private int _count;
        private int _capacity;
        public int Count { get{return _count;}  }
        public int Capacity { get{return _capacity;}  }
        public Type this[int index]{get{return _array[index];}set{_array[index]=value;}}
        private Type[]_array;

        public CustomList()
        {
            _count=0;
            _capacity=4;
            _array=new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count=0;
            _capacity=size;
            _array=new Type[_capacity];
        }
        public void Add(Type element)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
            _array[_count]=element;
            _count++;
        }
        public void GrowSize()
        {
            _capacity=_capacity*2;
            Type[]temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }
       
        
        
    }
}