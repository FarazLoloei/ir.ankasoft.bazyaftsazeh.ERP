﻿using System.Data.Entity;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF
{
    /// <summary>
    /// A custom implementation of ContactManagerContext that creates a new contact person with address details.
    /// </summary>
    public class DropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        /// <summary>
        /// Creates a new contact person.
        /// </summary>
        /// <param name="context">The context to which the new seed data is added.</param>
        protected override void Seed(ApplicationDbContext context)
        {
            //var person = new Person
            //{
            //    FirstName = "Imar",
            //    LastName = "Spaanjaars",
            //    DateOfBirth = new DateTime(1971, 8, 9),
            //    Type = PersonType.Friend,
            //    HomeAddress = CreateAddress(),
            //    WorkAddress = CreateAddress()
            //};
            //context.People.Add(person);
        }

        //private static Address CreateAddress()
        //{
        //    return new Address("Street", "City", "ZipCode", "Country", ContactType.Business);
        //}
    }
}