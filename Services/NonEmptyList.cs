namespace KDG.Common.Services
{
    public class NonEmptyList<T>
    {
        private readonly List<T> _items;

        public NonEmptyList(T first)
        {
            _items = new List<T> { first };
        }

        public NonEmptyList(T first, List<T> rest)
        {
            _items = new List<T> { first };
            _items.AddRange(rest);
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public T First => _items[0];
        public List<T> ExceptHead => _items.Skip(1).ToList();

        public IReadOnlyList<T> Items => _items.AsReadOnly();

        public int Count => _items.Count;
    }
}