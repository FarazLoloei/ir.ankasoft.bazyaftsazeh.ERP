using System.ComponentModel.DataAnnotations.Schema;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class GovernmentPlan : Plan
    {
        public GovernmentPlan()
        {
            base.Type = Enums.PlanType.Government;
        }

        public long OrganizationRefRecId { get; set; }

        [ForeignKey(nameof(OrganizationRefRecId))]
        public Organization Organization { get; set; }

        public string PermissionNumber { get; set; }
    }
}