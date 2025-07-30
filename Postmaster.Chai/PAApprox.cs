
namespace Postmonster.Asserts
{
    public partial class PAAssert<T>
    {
        public void closeTo(double expected, double delta)
        {
            if (_actual is not IConvertible)
                throw new PAException("CloseTo() only supports numeric values.");

            double actualVal = Convert.ToDouble(_actual);
            bool result = Math.Abs(actualVal - expected) <= delta;

            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to be within {delta} of {expected}, but got {actualVal}.");
        }

        public void withinPercent(double expected, double percent)
        {
            if (_actual is not IConvertible)
                throw new PAException("WithinPercent() only supports numeric values.");

            double actualVal = Convert.ToDouble(_actual);
            double delta = expected * percent / 100.0;
            bool result = Math.Abs(actualVal - expected) <= delta;

            if (_negate ? result : !result)
                fail($"Expected value {(_negate ? "not " : "")}to be within {percent}% of {expected}, but got {actualVal}.");
        }
    }
}
