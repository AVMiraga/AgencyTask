using AgencyTask.Core.Entities.Common;

namespace AgencyTask.Core.Entities
{
	public class Portfolio : BaseAuditableEntity
	{
		public string Title { get; set; }
		public string HtmlBody { get; set; }
		public List<int>? CategoryIds { get; set; }
		public ICollection<Category> Categories { get; set; }
		public string CoverImage { get; set; }
		public string MainImage { get; set; }
	}
}
