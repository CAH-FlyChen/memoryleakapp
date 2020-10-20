using Volo.Abp.Ui.Branding;

namespace MemoryLeakTest.Blazor
{
    public class MemoryLeakTestBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "MemoryLeakTest";
    }
}
