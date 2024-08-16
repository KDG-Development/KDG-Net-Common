using System;

namespace KDG.Common.Map
{
    public class Mapper<T>
    {
        public string Column { get; }
        public Func<T, object?> Getter { get; }
        public Mapper(string column,Func<T,object?> getter)
        {
            Column = column;
            Getter = getter;
        }
    }
}

