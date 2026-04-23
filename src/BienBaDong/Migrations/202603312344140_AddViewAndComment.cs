namespace BienBaDong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewAndComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DestinationId = c.Int(nullable: false),
                        AuthorName = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .Index(t => t.DestinationId);
            
            AddColumn("dbo.Destinations", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "DestinationId", "dbo.Destinations");
            DropIndex("dbo.Comments", new[] { "DestinationId" });
            DropColumn("dbo.Destinations", "ViewCount");
            DropTable("dbo.Comments");
        }
    }
}
