using System.Collections;

namespace Postmonster.Collections
{
    public interface IPCValuedItem
    {
        public string? Value { get; set; }
    }

    public interface IPCNamedItem
    { 
        public string Name { get; set; }
    }

    public interface IPCKeyedItem
    {
        public string Key { get; set; }
    }

    public interface IPCKeyedValueItem : IPCKeyedItem, IPCValuedItem
    {
    }

    public interface IPCNamedValueItem : IPCKeyedItem, IPCValuedItem
    {
    }

    public abstract class PCAbstractKeyedList<T> : IEnumerable<T> where T : IPCKeyedValueItem, new()
    {
        protected readonly List<T> _items = new();

        protected abstract string GetKey(T item);
        protected abstract void SetKey(T item, string key);

        protected PCAbstractKeyedList() { }

        protected PCAbstractKeyedList(IEnumerable<T> items)
        {
            _items.AddRange(items);
        }

        public void Add(string key, string value)
        {
            var item = new T { Value = value };
            SetKey(item, key);
            _items.Add(item);
        }

        public void Set(string key, string value)
        {
            var existing = _items.FirstOrDefault(i => GetKey(i).Equals(key, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
                existing.Value = value;
            else
                Add(key, value);
        }

        public string? Get(string key)
        {
            return _items.FirstOrDefault(i => GetKey(i).Equals(key, StringComparison.OrdinalIgnoreCase))?.Value;
        }

        public T? GetObject(string key)
        {
            return _items.FirstOrDefault(i => GetKey(i).Equals(key, StringComparison.OrdinalIgnoreCase));
        }

        public bool Has(string key) => _items.Any(i => GetKey(i).Equals(key, StringComparison.OrdinalIgnoreCase));

        public void Remove(string key) => _items.RemoveAll(i => GetKey(i).Equals(key, StringComparison.OrdinalIgnoreCase));

        public void Unset(string key) => Remove(key);

        public List<T> All() => _items.ToList();

        public object ToJson() => _items;

        public int Count => _items.Count;

        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PCKeyedListOf<T> : PCAbstractKeyedList<T> where T: IPCKeyedValueItem, new()
    {
        public PCKeyedListOf() : base() { }
        public PCKeyedListOf(IEnumerable<T> items) : base(items) { }
        protected override string GetKey(T item) => item.Key;
        protected override void SetKey(T item, string key) => item.Key = key;
    }

    public class PCNamedListOf<T> : PCAbstractKeyedList<T> where T : IPCKeyedValueItem, new()
    {
        public PCNamedListOf() : base() { }
        public PCNamedListOf(IEnumerable<T> items) : base(items) { }
        protected override string GetKey(T item) => item.Key;
        protected override void SetKey(T item, string key) => item.Key = key;
    }

}
