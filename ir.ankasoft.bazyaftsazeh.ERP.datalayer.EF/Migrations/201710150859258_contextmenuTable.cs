namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contextmenuTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContextMenuItems",
                c => new
                    {
                        recId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ParentRefRecId = c.Long(nullable: false),
                        RoleRefRecId = c.Long(nullable: false),
                        ShowOnHeader = c.Boolean(nullable: false),
                        DisableOnHeader = c.Boolean(nullable: false),
                        ShowOnRow = c.Boolean(nullable: false),
                        DisableOnRow = c.Boolean(nullable: false),
                        createdDateTime = c.DateTime(nullable: false),
                        modifiedDateTime = c.DateTime(),
                        creatorUserRefRecId = c.Long(nullable: false),
                        modifierUserRefRecId = c.Long(),
                        ContextMenu_recId = c.Long(),
                    })
                .PrimaryKey(t => t.recId)
                .ForeignKey("dbo.Users", t => t.creatorUserRefRecId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.modifierUserRefRecId)
                .ForeignKey("dbo.ContextMenus", t => t.ContextMenu_recId)
                .ForeignKey("dbo.ContextMenus", t => t.ParentRefRecId)
                .ForeignKey("dbo.Roles", t => t.RoleRefRecId, cascadeDelete: true)
                .Index(t => t.ParentRefRecId)
                .Index(t => t.RoleRefRecId)
                .Index(t => t.creatorUserRefRecId)
                .Index(t => t.modifierUserRefRecId)
                .Index(t => t.ContextMenu_recId);
            
            CreateTable(
                "dbo.ContextMenus",
                c => new
                    {
                        recId = c.Long(nullable: false, identity: true),
                        Controller = c.String(nullable: false),
                        createdDateTime = c.DateTime(nullable: false),
                        modifiedDateTime = c.DateTime(),
                        creatorUserRefRecId = c.Long(nullable: false),
                        modifierUserRefRecId = c.Long(),
                    })
                .PrimaryKey(t => t.recId)
                .ForeignKey("dbo.Users", t => t.creatorUserRefRecId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.modifierUserRefRecId)
                .Index(t => t.creatorUserRefRecId)
                .Index(t => t.modifierUserRefRecId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContextMenuItems", "RoleRefRecId", "dbo.Roles");
            DropForeignKey("dbo.ContextMenuItems", "ParentRefRecId", "dbo.ContextMenus");
            DropForeignKey("dbo.ContextMenus", "modifierUserRefRecId", "dbo.Users");
            DropForeignKey("dbo.ContextMenuItems", "ContextMenu_recId", "dbo.ContextMenus");
            DropForeignKey("dbo.ContextMenus", "creatorUserRefRecId", "dbo.Users");
            DropForeignKey("dbo.ContextMenuItems", "modifierUserRefRecId", "dbo.Users");
            DropForeignKey("dbo.ContextMenuItems", "creatorUserRefRecId", "dbo.Users");
            DropIndex("dbo.ContextMenus", new[] { "modifierUserRefRecId" });
            DropIndex("dbo.ContextMenus", new[] { "creatorUserRefRecId" });
            DropIndex("dbo.ContextMenuItems", new[] { "ContextMenu_recId" });
            DropIndex("dbo.ContextMenuItems", new[] { "modifierUserRefRecId" });
            DropIndex("dbo.ContextMenuItems", new[] { "creatorUserRefRecId" });
            DropIndex("dbo.ContextMenuItems", new[] { "RoleRefRecId" });
            DropIndex("dbo.ContextMenuItems", new[] { "ParentRefRecId" });
            DropTable("dbo.ContextMenus");
            DropTable("dbo.ContextMenuItems");
        }
    }
}
