using System.Collections;

namespace Postmonster.Asserts
{
    public partial class PAAssert<T>
    {
        public void @true()
        {
            bool result = _actual is bool b && b;
            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to be true.");
        }

        public void @false()
        {
            bool result = _actual is bool b && !b;
            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to be false.");
        }

        public void falsy()
        {
            bool result = _actual switch
            {
                null => true,
                bool b => !b,
                string s => s.Length == 0,
                ICollection c => c.Count == 0,
                IEnumerable e => !e.Cast<object>().Any(),
                _ => false
            };

            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to be falsy.");
        }
    }
}
