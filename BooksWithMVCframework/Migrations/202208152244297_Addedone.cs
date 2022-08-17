namespace BooksWithMVCframework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedone : DbMigration
    {
        //when make update DB exec Up()
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Author = c.String(nullable: false, maxLength: 125),
                        Description = c.String(nullable: false, maxLength: 2000),
                        categoriesId = c.Byte(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.categoriesId, cascadeDelete: true)
                .Index(t => t.categoriesId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Action = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        //when make numbers of migrations and we need to go back to special migration 
        public override void Down()
        {
            DropForeignKey("dbo.Books", "categoriesId", "dbo.Category");
            DropIndex("dbo.Books", new[] { "categoriesId" });
            DropTable("dbo.Category");
            DropTable("dbo.Books");
        }
    }
}
