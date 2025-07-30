using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public interface IPRKeyedValueLike
    {
        public string? value { get; set; }
    }

    public abstract class PRKeyedList<T> : IEnumerable<T> where T : IPRKeyedValueLike, new()
    {
        protected readonly List<T> _items = new();

        protected abstract string GetKey(T item);
        protected abstract void SetKey(T item, string key);

        protected PRKeyedList() { }

        protected PRKeyedList(IEnumerable<T> items)
        {
            _items.AddRange(items);
        }

        public void Add(string key, string value)
        {
            var item = new T { value = value };
            SetKey(item, key);
            _items.Add(item);
        }

        public void Set(string key, string value)
        {
            var existing = _items.FirstOrDefault(i => GetKey(i).Equals(key, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
                existing.value = value;
            else
                Add(key, value);
        }

        public string? Get(string key)
        {
            return _items.FirstOrDefault(i => GetKey(i).Equals(key, StringComparison.OrdinalIgnoreCase))?.value;
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

}
