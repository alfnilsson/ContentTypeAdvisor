using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Cms.Shell.UI.Rest;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using Toders.Web.Models.Blocks;

namespace Toders.Web.Business.Slideshow
{
	// Register your implementation if you want to add it to the existing implementations of IContentTypeAdvisor
    [ServiceConfiguration(typeof(IContentTypeAdvisor))]
    public class SlideshowContentTypeAdvisor : IContentTypeAdvisor
    {
        private readonly IContentLoader _contentLoader;
        private readonly BlockTypeRepository _blockTypeTypeRepository;

        public SlideshowContentTypeAdvisor(IContentLoader contentLoader, BlockTypeRepository blockTypeTypeRepository)
        {
            _contentLoader = contentLoader;
            _blockTypeTypeRepository = blockTypeTypeRepository;
        }

        public IEnumerable<int> GetSuggestions(IContent parent, bool contentFolder, IEnumerable<string> requestedTypes)
        {
            var children = _contentLoader.GetChildren<SlideshowBlock>(parent.ContentLink);
            if (!children.Any())
            {
                return Enumerable.Empty<int>();
            }

            BlockType slideBlockType = _blockTypeTypeRepository.Load<SlideBlock>();
            if (slideBlockType == null)
            {
                return Enumerable.Empty<int>();
            }

            return new[] {slideBlockType.ID};
        }
    }
}
