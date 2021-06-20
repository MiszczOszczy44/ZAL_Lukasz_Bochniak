namespace ZAL_Lukasz_Bochniak.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ZAL_Lukasz_Bochniak.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZAL_Lukasz_Bochniak.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZAL_Lukasz_Bochniak.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            AddUsers(context);
        }
        void AddUsers(ZAL_Lukasz_Bochniak.Models.ApplicationDbContext context)
        {
            var User = new ApplicationUser { UserName = "lukaszbochniak98@gmail.com" };
            var um = new UserManager<ApplicationUser>( 
                new UserStore<Models.ApplicationUser>(context));
            um.Create(User, "password");
        }
    }
}
