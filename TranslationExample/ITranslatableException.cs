using Microsoft.Extensions.Localization;

namespace TranslationExample
{
    internal interface ITranslatableException
    {
        string GetMessage(IStringLocalizerFactory stringLocalizerFactory);
    }
}
