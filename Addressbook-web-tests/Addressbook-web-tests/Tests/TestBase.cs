using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble()*max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return StringCaseRandomizer(builder.ToString());
        }

        public static string StringCaseRandomizer(string textToTweakCase)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < textToTweakCase.Length; i++)
            {
                int l = Convert.ToInt32(rnd.NextDouble() * 2);
                if (l > 1)
                {
                    builder.Append(textToTweakCase.Substring(i, 1).ToLower());
                }
                else
                {
                    builder.Append(textToTweakCase.Substring(i, 1).ToUpper());
                }
            }
            return builder.ToString();
        }
    }
}
