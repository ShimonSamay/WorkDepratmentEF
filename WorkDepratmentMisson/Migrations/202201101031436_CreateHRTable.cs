namespace WorkDepratmentMisson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateHRTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HRs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        WorkExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HRs");
        }
    }
}
