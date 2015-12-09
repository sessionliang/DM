namespace CMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitCmsNodeAndCmsModelContent : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CmsNodes");
            CreateTable(
                "dbo.CmsModelContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NodeId = c.Int(nullable: false),
                        PublishmentSystemId = c.Int(nullable: false),
                        Taxis = c.Int(nullable: false),
                        Tags = c.String(nullable: false, maxLength: 255),
                        ContentGroupNameCollection = c.String(nullable: false, maxLength: 255),
                        SourceId = c.Int(nullable: false),
                        ReferenceId = c.Int(nullable: false),
                        IsChecked = c.String(nullable: false, maxLength: 18),
                        CheckedLevel = c.Int(nullable: false),
                        Comments = c.Int(nullable: false),
                        Photos = c.Int(nullable: false),
                        Teleplays = c.Int(nullable: false),
                        Hits = c.Int(nullable: false),
                        HitsByDay = c.Int(nullable: false),
                        HitsByWeek = c.Int(nullable: false),
                        HitsByMonth = c.Int(nullable: false),
                        LastHitsDate = c.DateTime(nullable: false),
                        SettingsXml = c.String(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255,defaultValue:""),
                        SubTitle = c.String(nullable: false, maxLength: 255),
                        ImageUrl = c.String(nullable: false, maxLength: 200),
                        VideoUrl = c.String(nullable: false, maxLength: 200),
                        FileUrl = c.String(nullable: false, maxLength: 255),
                        LinkUrl = c.String(nullable: false, maxLength: 255),
                        Content = c.String(nullable: false),
                        Summary = c.String(nullable: false),
                        Author = c.String(nullable: false, maxLength: 255),
                        Source = c.String(nullable: false, maxLength: 255),
                        IsRecommend = c.String(nullable: false, maxLength: 18),
                        IsHot = c.String(nullable: false, maxLength: 18),
                        IsColor = c.String(nullable: false, maxLength: 18),
                        IsTop = c.String(nullable: false, maxLength: 18),
                        CheckTaskDate = c.DateTime(nullable: false),
                        UnCheckTaskDate = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterTableAnnotations(
                "dbo.CmsNodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NodeName = c.String(nullable: false, maxLength: 255),
                        NodeType = c.String(nullable: false, maxLength: 255),
                        PublishmentSystemId = c.Int(nullable: false),
                        ContentModelId = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Int(nullable: false),
                        ParentsPath = c.String(nullable: false, maxLength: 255),
                        ParentsCount = c.Int(nullable: false),
                        ChildrenCount = c.Int(nullable: false),
                        IsLastNode = c.String(nullable: false, maxLength: 18),
                        NodeIndexName = c.String(nullable: false, maxLength: 255),
                        NodeGroupNameCollection = c.String(nullable: false, maxLength: 255),
                        Taxis = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false),
                        ContentNum = c.Int(nullable: false),
                        CommentNum = c.Int(nullable: false),
                        FilePath = c.String(nullable: false, maxLength: 200),
                        ChannelFilePathRule = c.String(nullable: false, maxLength: 200),
                        ContentFilePathRule = c.String(nullable: false, maxLength: 200),
                        LinkUrl = c.String(nullable: false, maxLength: 200),
                        LinkType = c.String(nullable: false, maxLength: 200),
                        ChannelTemplateId = c.Int(nullable: false),
                        ContentTemplateId = c.Int(nullable: false),
                        Keywords = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ExtendValues = c.String(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_CmsNode_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterColumn("dbo.CmsNodes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CmsNodes", "Id");
            DropColumn("dbo.CmsNodes", "NodeId");
            DropColumn("dbo.CmsNodes", "IsDeleted");
            DropColumn("dbo.CmsNodes", "DeleterUserId");
            DropColumn("dbo.CmsNodes", "DeletionTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CmsNodes", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.CmsNodes", "DeleterUserId", c => c.Long());
            AddColumn("dbo.CmsNodes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.CmsNodes", "NodeId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.CmsNodes");
            AlterColumn("dbo.CmsNodes", "Id", c => c.Int(nullable: false));
            AlterTableAnnotations(
                "dbo.CmsNodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NodeName = c.String(nullable: false, maxLength: 255),
                        NodeType = c.String(nullable: false, maxLength: 255),
                        PublishmentSystemId = c.Int(nullable: false),
                        ContentModelId = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Int(nullable: false),
                        ParentsPath = c.String(nullable: false, maxLength: 255),
                        ParentsCount = c.Int(nullable: false),
                        ChildrenCount = c.Int(nullable: false),
                        IsLastNode = c.String(nullable: false, maxLength: 18),
                        NodeIndexName = c.String(nullable: false, maxLength: 255),
                        NodeGroupNameCollection = c.String(nullable: false, maxLength: 255),
                        Taxis = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false),
                        ContentNum = c.Int(nullable: false),
                        CommentNum = c.Int(nullable: false),
                        FilePath = c.String(nullable: false, maxLength: 200),
                        ChannelFilePathRule = c.String(nullable: false, maxLength: 200),
                        ContentFilePathRule = c.String(nullable: false, maxLength: 200),
                        LinkUrl = c.String(nullable: false, maxLength: 200),
                        LinkType = c.String(nullable: false, maxLength: 200),
                        ChannelTemplateId = c.Int(nullable: false),
                        ContentTemplateId = c.Int(nullable: false),
                        Keywords = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ExtendValues = c.String(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_CmsNode_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            DropTable("dbo.CmsModelContents");
            AddPrimaryKey("dbo.CmsNodes", "NodeId");
        }
    }
}
