using EPiServer.Cms.Shell.UI.Rest;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace Toders.Web.Business.Slideshow
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.EjectAllInstancesOf<IContentTypeAdvisor>();
            context.Container.Configure(x => x.For<IContentTypeAdvisor>().Use<SlideshowContentTypeAdvisor>());
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}
