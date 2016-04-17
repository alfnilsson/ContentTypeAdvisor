using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Cms.Shell.UI.Rest;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Security;
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
        private readonly ContentTypeAvailabilityService _contentTypeAvailablilityService;

        public SlideshowContentTypeAdvisor(IContentLoader contentLoader, BlockTypeRepository blockTypeTypeRepository, ContentTypeAvailabilityService contentTypeAvailablilityService)
        {
            _contentLoader = contentLoader;
            _blockTypeTypeRepository = blockTypeTypeRepository;
            _contentTypeAvailablilityService = contentTypeAvailablilityService;
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

            int slideBlockTypeId = slideBlockType.ID;

            // Make sure that the SlideBlock is available as child to the parent content, and that the editor has proper access rights to create the Slide Block
            IEnumerable<int> listAvailable = this._contentTypeAvailablilityService.ListAvailable(parent, contentFolder, PrincipalInfo.Current.Principal)
                .Select(contentType => contentType.ID)
                .Distinct();
            if (listAvailable.Contains(slideBlockTypeId) == false)
            {
                return Enumerable.Empty<int>();
            }

            return new[] {slideBlockTypeId};
        }
    }
}
