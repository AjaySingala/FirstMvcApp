namespace FirstMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Age : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Age");
        }
    }
}
