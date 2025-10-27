namespace FleetZone_NET.Application.Common
{
    public record LinkDto(string Rel, string Href, string Method);

    public static class HateoasBuilder
    {
        public static IEnumerable<LinkDto> ForPatio(Guid id, Microsoft.AspNetCore.Mvc.IUrlHelper url)
        {
            return new[]
            {
                new LinkDto("self",  url.Link("GetPatioById", new { id })!, "GET"),
                new LinkDto("update",url.Link("UpdatePatio",  new { id })!, "PUT"),
                new LinkDto("delete",url.Link("DeletePatio",  new { id })!, "DELETE")
            };
        }
    }
}
