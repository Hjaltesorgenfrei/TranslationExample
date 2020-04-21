using System;
using System.Globalization;
using System.Threading;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace TranslationExample
{
    public static class Program
    {
        public static void Main()
        {
            Example("da-dk");
            Example("en-ca");
            Example("en-gb");
            Example("en-us");
        }

        private static void Example(string culture)
        {
            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            Console.Out.WriteLine($"{cultureInfo.EnglishName}:");
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            try
            {
                ThrowException();
            }
            catch (Exception exception)
            {
                if (exception is ITranslatableException translatableException)
                {
                    var x = new ResourceManagerStringLocalizerFactory(Options.Create(new LocalizationOptions()), NullLoggerFactory.Instance);
                    Console.Error.WriteLine(translatableException.GetMessage(x));
                }
                else
                {
                    throw new NotSupportedException();
                }
                Console.Error.WriteLine();
            }
        }

        private static void ThrowException()
        {
            throw new EnumException<ErrorCodes>(ErrorCodes.Forbidden);
        }
    }
}
