namespace KDG.Common.Tuples
{
    public class PassFail<T> : Tuple<T, T>
    {
        public PassFail(T pass, T fail) : base(pass, fail)
        {
        }

        public T Pass => Item1;
        public T Fail => Item2;
    }
}


