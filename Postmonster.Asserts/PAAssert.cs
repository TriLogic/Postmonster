using System.Collections;
using System.Reflection;

namespace Postmonster.Asserts
{
    public partial class PAAssert<T>
    {
        private readonly T _actual;
        private readonly bool _negate;

        public PAAssert(T actual, bool negate = false)
        {
            _actual = actual;
            _negate = negate;
        }

        public PAAssert<T> to => this;
        public PAAssert<T> be => this;
        public PAAssert<T> have => this;
        public PAAssert<T> not => new PAAssert<T>(_actual, !_negate);

        private void fail(string message) => throw new PAException(message);

        public void @null()
        {
            bool result = object.Equals(_actual, null);
            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to be null.");
        }

        public void ok()
        {
            bool result = _actual switch
            {
                null => false,
                bool b => b,
                string s => s.Length > 0,
                ICollection c => c.Count > 0,
                IEnumerable e => e.Cast<object>().Any(),
                _ => true
            };

            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to be truthy.");
        }


        public void a<U>()
        {
            bool result = _actual is U;
            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to be of type {typeof(U).Name}.");
        }

        public void instanceOf<U>()
        {
            bool result = _actual?.GetType() == typeof(U);
            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to be instance of {typeof(U).Name}, but got {_actual?.GetType().Name}.");
        }

        public void property(string name)
        {
            if (_actual == null)
                fail("Expected object to have property, but value was null.");

            var type = _actual.GetType();
            var prop = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            bool result = prop != null;

            if (_negate ? result : !result)
                fail($"Expected object {(_negate ? "not " : "")}to have property \"{name}\".");
        }

        public void ownProperty(string name)
        {
            if (_actual == null)
                fail("Expected object to have own property, but value was null.");

            var type = _actual.GetType();
            var prop = type.GetProperty(name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            bool result = prop != null;

            if (_negate ? result : !result)
                fail($"Expected object {(_negate ? "not " : "")}to have own property \"{name}\".");
        }

        public void satisfy(Func<T, bool> predicate)
        {
            bool result = predicate(_actual);
            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to satisfy predicate, but it did{(_negate ? "" : " not")}.");
        }
    }

}
