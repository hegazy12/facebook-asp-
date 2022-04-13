namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<facebook_asp_.Models.datamodel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(facebook_asp_.Models.datamodel context)
        {
         
        }
    }
}
