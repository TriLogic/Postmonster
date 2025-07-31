
using System.Collections;

namespace Postmonster.Asserts
{
    public partial class PAAssert<T>
    {
        public void deepEqual(object expected)
        {
            bool result = DeepEquals(_actual, expected);
            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to deeply equal {expected}.");
        }

        private bool DeepEquals(object a, object b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a == null || b == null) return false;
            if (a.Equals(b)) return true;
            if (a is IEnumerable ae && b is IEnumerable be)
            {
                var aeEnum = ae.Cast<object>().ToList();
                var beEnum = be.Cast<object>().ToList();
                return aeEnum.Count == beEnum.Count && !aeEnum.Where((t, i) => !DeepEquals(t, beEnum[i])).Any();
            }
            return false;
        }
    }
}
