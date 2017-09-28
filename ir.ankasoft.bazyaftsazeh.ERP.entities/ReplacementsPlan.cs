using ir.ankasoft.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities
{
    public class ReplacementsPlan : Plan
    {
        public ReplacementsPlan()
        {
            base.Type = Enums.PlanType.Replacements;
        }

        public long ImporterRefRecId { get; set; }

        [ForeignKey(nameof(ImporterRefRecId))]
        public Importer BeneficiaryImporter { get; set; }

        public long ReplacementVehicleRefRecId { get; set; }

        [ForeignKey(nameof(ReplacementVehicleRefRecId))]
        public Vehicle ReplacementsVehicle { get; set; }
    }
}
