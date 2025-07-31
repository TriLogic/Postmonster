using System.Collections;
using System.Text.RegularExpressions;


namespace Postmonster.Asserts
{
    public partial class PAAssert<T>
    {
        public void lengthOf(int expectedLength)
        {
            int actualLength = _actual switch
            {
                string s => s.Length,
                ICollection c => c.Count,
                _ => throw new PAException("LengthOf() only supports strings or collections.")
            };

            if (_negate ? actualLength == expectedLength : actualLength != expectedLength)
                fail($"Expected length {(_negate ? "not " : "")}to be {expectedLength}, but got {actualLength}.");
        }

        public void empty()
        {
            bool result = _actual switch
            {
                string s => s.Length == 0,
                ICollection c => c.Count == 0,
                _ => throw new PAException("Empty() only supports strings or collections.")
            };

            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to be empty.");
        }

        public void include(object item)
        {
            bool result = _actual switch
            {
                string s => s.Contains(item?.ToString()),
                IEnumerable e => e.Cast<object>().Contains(item),
                _ => throw new PAException("Include() only supports strings or collections.")
            };

            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to include {item}.");
        }

        public void contain(string substring)
        {
            if (_actual is not string s)
                throw new PAException("Contain() only supports strings.");

            bool result = s.Contains(substring);
            if (_negate ? result : !result)
                fail($"Expected string {(_negate ? "not " : "")}to contain \"{substring}\".");
        }

        public void startWith(string prefix)
        {
            if (_actual is not string s)
                throw new PAException("StartWith() only supports strings.");

            bool result = s.StartsWith(prefix);
            if (_negate ? result : !result)
                fail($"Expected string {(_negate ? "not " : "")}to start with \"{prefix}\".");
        }

        public void endWith(string suffix)
        {
            if (_actual is not string s)
                throw new PAException("EndWith() only supports strings.");

            bool result = s.EndsWith(suffix);
            if (_negate ? result : !result)
                fail($"Expected string {(_negate ? "not " : "")}to end with \"{suffix}\".");
        }

        public void match(string pattern)
        {
            if (_actual is not string s)
                throw new PAException("Match() only supports strings.");

            bool result = Regex.IsMatch(s, pattern);
            if (_negate ? result : !result)
                fail($"Expected string {(_negate ? "not " : "")}to match regex \"{pattern}\".");
        }


        public void keys(params string[] expectedKeys)
        {
            if (_actual is not IDictionary dict)
                throw new PAException("Keys() only supports dictionaries.");

            foreach (var key in expectedKeys)
            {
                bool contains = dict.Contains(key);
                if (_negate ? contains : !contains)
                    fail($"Expected dictionary {(_negate ? "not " : "")}to contain key \"{key}\".");
            }
        }

        public void members(IEnumerable expected)
        {
            if (_actual is not IEnumerable actualEnum)
                throw new PAException("Members() only supports collections.");

            var actualList = actualEnum.Cast<object>().ToList();
            var expectedList = expected.Cast<object>().ToList();

            foreach (var item in expectedList)
            {
                bool contains = actualList.Contains(item);
                if (_negate ? contains : !contains)
                    fail($"Expected collection {(_negate ? "not " : "")}to contain member {item}.");
            }
        }

    }
}
