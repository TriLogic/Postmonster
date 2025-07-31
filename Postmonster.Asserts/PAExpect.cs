
namespace Postmonster.Asserts
{
    public class PAExpect
    {
        public PAExpect() { }

        public PAAssert<T> that<T>(T actual) => new PAAssert<T>(actual);
    }
}
