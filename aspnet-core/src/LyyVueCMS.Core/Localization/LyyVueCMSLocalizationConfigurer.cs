using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace LyyVueCMS.Localization
{
    public static class LyyVueCMSLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(LyyVueCMSConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(LyyVueCMSLocalizationConfigurer).GetAssembly(),
                        "LyyVueCMS.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
