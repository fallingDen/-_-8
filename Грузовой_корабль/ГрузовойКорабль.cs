using System;
using System.Windows.Controls;

namespace Практическая_работа_8
{
    public class ГрузовойКорабль : ICloneable , IКорабль, IГрузовойТранспорт, IComparable
    {

       public string Name { get; private set; } 
       public int Грузоподъёмность { get; private set; }

        public int N { get; set; }
        
        public ГрузовойКорабль(string name, int грузоподъёмность)
        {
            Name = name;
            Грузоподъёмность = грузоподъёмность;
        }   // конструктор


        public object Clone()
        {
            return new ГрузовойКорабль(Name, Грузоподъёмность);
        }

        public override string ToString()
        {    
            return $"{N}- {Name} его грузоподъёмность- {Грузоподъёмность} тонны";
        }

       

        public int CompareTo(object? obj)
        { 
            ГрузовойКорабль temp = (ГрузовойКорабль)obj;
            if (Грузоподъёмность < temp.Грузоподъёмность) return -1;
            if (Грузоподъёмность > temp.Грузоподъёмность) return  1;
            return 0;
        }
    }
}
