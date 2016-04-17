using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Toders.Web.Models.Blocks
{
    [ContentType(GUID = "afa13287-df3f-4564-a220-a32d3c4badee")]
    public class SlideshowBlock : BlockData
    {
        [AllowedTypes(new[] { typeof(SlideBlock) })]
        public virtual ContentArea Slides { get; set; }
    }
}