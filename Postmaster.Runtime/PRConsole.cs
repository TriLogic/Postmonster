
namespace Postmonster.Runtime
{
    public class PRConsole
    {
        public void log(params object[] args)
        {
            Console.WriteLine(string.Join(" ", args));
        }

        public void error(params object[] args)
        {
            Console.Error.WriteLine(string.Join(" ", args));
        }

        public void warn(params object[] args)
        {
            Console.WriteLine("[warn] " + string.Join(" ", args));
        }
    }
}
