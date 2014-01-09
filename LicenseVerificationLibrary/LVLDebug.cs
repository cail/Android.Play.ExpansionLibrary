
namespace LicenseVerificationLibrary{

    public class LVLDebug{
        public static void WriteLine(string line)
        {
#if DEBUG
            System.Console.WriteLine (line);
#else
#endif
        }
    }
}
