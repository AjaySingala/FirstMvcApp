namespace FirstMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stringlength_name : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Firstname", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Firstname", c => c.String(nullable: false));
        }
    }
}
