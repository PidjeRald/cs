namespace lab21.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
        }
    }
}
