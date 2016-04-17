using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Toders.Web.Models.Blocks
{
    [ContentType(GUID = "c040c4f7-462f-4b23-9913-f475c4315134")]
    public class SlideBlock : BlockData
    {
        public virtual XhtmlString Body { get; set; }
    }
}