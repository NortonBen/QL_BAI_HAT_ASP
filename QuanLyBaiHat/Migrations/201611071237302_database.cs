namespace QuanLyBaiHat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaiHats",
                c => new
                    {
                        MaBH = c.Int(nullable: false, identity: true),
                        TenBH = c.String(nullable: false),
                        url = c.String(),
                        img = c.String(),
                        NoiDung = c.String(),
                        NamSX = c.DateTime(nullable: false),
                        HangSX = c.String(),
                        MaCS = c.Int(nullable: false),
                        MaTG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaBH)
                .ForeignKey("dbo.CaSis", t => t.MaCS, cascadeDelete: true)
                .ForeignKey("dbo.TacGias", t => t.MaTG, cascadeDelete: true)
                .Index(t => t.MaCS)
                .Index(t => t.MaTG);
            
            CreateTable(
                "dbo.CaSis",
                c => new
                    {
                        MaCS = c.Int(nullable: false, identity: true),
                        TenCS = c.String(nullable: false),
                        MaTo = c.String(),
                    })
                .PrimaryKey(t => t.MaCS);
            
            CreateTable(
                "dbo.TacGias",
                c => new
                    {
                        MaTG = c.Int(nullable: false, identity: true),
                        TenTG = c.String(nullable: false),
                        Mota = c.String(),
                    })
                .PrimaryKey(t => t.MaTG);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        url = c.String(),
                        name = c.String(),
                        extension = c.String(),
                        date = c.DateTime(nullable: false),
                        size = c.Long(nullable: false),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_id = c.Int(nullable: false),
                        permission = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_id, cascadeDelete: true)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "User_id", "dbo.Users");
            DropForeignKey("dbo.BaiHats", "MaTG", "dbo.TacGias");
            DropForeignKey("dbo.BaiHats", "MaCS", "dbo.CaSis");
            DropIndex("dbo.Roles", new[] { "User_id" });
            DropIndex("dbo.BaiHats", new[] { "MaTG" });
            DropIndex("dbo.BaiHats", new[] { "MaCS" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Media");
            DropTable("dbo.TacGias");
            DropTable("dbo.CaSis");
            DropTable("dbo.BaiHats");
        }
    }
}
