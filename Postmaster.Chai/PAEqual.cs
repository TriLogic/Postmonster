
namespace Postmonster.Asserts
{
    public partial class PAAssert<T>
    {
        public void equal(object expected)
        {
            bool result = Equals(_actual, expected);
            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to equal {expected}, but got {_actual}.");
        }
    }
}
