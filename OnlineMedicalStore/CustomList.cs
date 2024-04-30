using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    
    public class CustomList<Type>
    {
        private int _count;//field
        private int _capacity;//field
        public int Count { get{return _count;}  }
        public int Capacity { get{return _capacity;} }

        private Type[]_array;//Array

        public Type this[int index]{get{return _array[index];} set{_array[index]=value;}}
        
        
        public CustomList()//Constructor
        {
            _count=0;
            _capacity=4;//initally capacity is 4
            _array=new Type[_capacity];
        }

        public CustomList(int size)//user size
        {
            _count=0;
            _capacity=size;
            _array=new Type[_capacity];
        }
        
        //Add method
        public void Add(Type element)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
            _array[_count]=element;
            _count++;
        }
        //Grow Size
        public void GrowSize()
        {
            _capacity=_capacity*2;
            Type[] temp=new Type[_capacity];//to store the array elements
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;

        }
        //Add range
        public void AddRange(CustomList<Type> elements)
        {
            _count=_count+elements._count+4;
            Type[] temp=new Type[_capacity];//to store the array elements
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            int k=0;
            for(int i=_count;i<_count+elements.Count;i++)
            {
                temp[i]=elements[k];
                k++;
            }
            _array=temp;
            _count=_count+elements._count;

        }

    }
}