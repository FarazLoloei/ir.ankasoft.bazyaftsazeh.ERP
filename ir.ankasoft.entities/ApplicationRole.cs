using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ir.ankasoft.entities
{
    public class ApplicationRole : IdentityRole<long, ApplicationUserRole>, IRole<long>
    {
        public string Description { get; set; }

        public ApplicationRole()
        {
        }

        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }

        //public ApplicationRole(string name, string description)
        //    : this(name)
        //{
        //    this.Description = description;
        //}
    }
}