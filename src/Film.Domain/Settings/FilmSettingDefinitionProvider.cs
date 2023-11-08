using Volo.Abp.Settings;

namespace Film.Settings;

public class FilmSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FilmSettings.MySetting1));
    }
}
