namespace ZAL_Lukasz_Bochniak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lista_ToDo", "Gotowe", c => c.Boolean(nullable: false));
            DropColumn("dbo.Lista_ToDo", "Done");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lista_ToDo", "Done", c => c.Boolean(nullable: false));
            DropColumn("dbo.Lista_ToDo", "Gotowe");
        }
    }
}
