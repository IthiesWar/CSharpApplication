using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CafeteriaCard
{
    public class CustomList1<Type>
    {
        private int  _count1;
        private int _capacity1;

        public int count { get{return _count1;}  }
        public int capacity {get{return _capacity1;} }
        private Type []_array;
        
        public Type this[int index] { get{return _array[ index];} set{_array[index]=value;}}
        
        
        public CustomList1()
        {
            _count1=0;
            _capacity1=4;
            _array=new Type[_capacity1];
        }

        public CustomList1(int size)
        {
            _count1=0;
            _capacity1=size;
            _array=new Type[_capacity1];
        }
        public void Add(Type element)
        {
            if(_count1==_capacity1)
            {
                GrowSize();
            }
            _array[_count1]=element;
            _count1++;
        }
        //Grow size
        public void GrowSize()
        {
            _capacity1=_capacity1*2;
            Type[] temp=new Type[_capacity1];
            //To change the array to temp
            for(int i=0;i<_count1;i++)
            {
                temp[i]=_array[i];//to change array to temp
            }
            _array=temp;//To store the memory address
        }
        //Add range
        public void AddRange(CustomList<Type> ele)
        {
            _capacity1=_count1+ele.+4;
            Type[] temp=new Type[_capacity];
            //To change the array to temp
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];//to change array to temp
            }
            int k=0;
           for(int i=_count;i<_count+element.count;i++)
           {
            temp[i]=element[k];
            k++;
           }
           _array=temp;
           _count=_count+element.;
        }
        
    }
}