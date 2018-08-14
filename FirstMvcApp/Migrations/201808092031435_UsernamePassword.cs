namespace FirstMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsernamePassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "Username");
        }
    }
}
