namespace CaseClosed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSmokeTestsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SmokeTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSuccess = c.Boolean(nullable: false),
                        Message = c.String(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SmokeTests");
        }
    }
}
