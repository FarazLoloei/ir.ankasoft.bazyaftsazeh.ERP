using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.entities.Enums
{
    public enum VehicleType
    {
        [Display(Name = nameof(MotorCar), ResourceType = typeof(Resource))]
        MotorCar = 1,
        [Display(Name = nameof(Van), ResourceType = typeof(Resource))]
        Van,
        [Display(Name = nameof(Minibus), ResourceType = typeof(Resource))]
        Minibus,
        [Display(Name = nameof(Bus), ResourceType = typeof(Resource))]
        Bus,
        [Display(Name = nameof(Pickup), ResourceType = typeof(Resource))]
        Pickup,
        [Display(Name = nameof(Truck), ResourceType = typeof(Resource))]
        Truck,
        [Display(Name = nameof(Lorry), ResourceType = typeof(Resource))]
        Lorry
    }
}