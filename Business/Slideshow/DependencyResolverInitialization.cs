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
            // This is to remove all implementations of IContentTypeAdvisor and disable the "Suggested Content Types" functionality in Episerver
            context.Container.EjectAllInstancesOf<IContentTypeAdvisor>();

            // Also add this if you only want to use your custom ContentTypeAdvisor instead of just adding it to the existing ones
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
