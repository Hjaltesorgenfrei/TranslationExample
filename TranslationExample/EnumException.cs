using System;
using Microsoft.Extensions.Localization;

namespace TranslationExample
{
    internal sealed class EnumException<TEnum> : Exception, ITranslatableException
        where TEnum : Enum
    {
        private readonly TEnum _value;

        internal EnumException(TEnum value) => _value = value;

        public string GetMessage(IStringLocalizerFactory stringLocalizerFactory)
        {
            var enumType = _value.GetType();
            return stringLocalizerFactory.Create(enumType).GetString(Enum.GetName(enumType, _value));
        }
    }
}
