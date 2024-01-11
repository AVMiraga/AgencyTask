using AgencyTask.Core.Entities.Common;

namespace AgencyTask.Core.Entities
{
	public class Category : BaseAuditableEntity
	{
		public string Name { get; set; }
		public List<int>? PortfolioIds { get; set; }
		public List<Portfolio> Portfolio { get; set; }
	}
}
