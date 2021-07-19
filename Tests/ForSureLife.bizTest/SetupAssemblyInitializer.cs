using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForSureLife.BizTest
{
    [TestClass]
    public class SetupAssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Initalization code goes here
            SetTheWorkingDirectoryForSureLife();
        }

        private static void SetTheWorkingDirectoryForSureLife()
        {
            var path = "../../../../../../ForSureLife/Assets";
            while (path.Length > "ForSureLife/Assets".Length)
            {
                if (Directory.Exists(path))
                {
                    Directory.SetCurrentDirectory(new DirectoryInfo(path).Parent.FullName);
                    break;
                }
                path = path.Substring(3);
            }
        }
    }
}