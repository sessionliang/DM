using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace CMS
{
    [DependsOn(typeof(CMSCoreModule), typeof(AbpAutoMapperModule))]
    public class CMSApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
