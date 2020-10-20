using Volo.Abp.Settings;

namespace MemoryLeakTest.Settings
{
    public class MemoryLeakTestSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(MemoryLeakTestSettings.MySetting1));
        }
    }
}
