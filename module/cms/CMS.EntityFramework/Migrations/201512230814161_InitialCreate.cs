namespace CMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.model_Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
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
                        Title = c.String(nullable: false, maxLength: 255),
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
                        TenantId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ContentInfo_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ContentInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.dm_Node",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NodeName = c.String(nullable: false, maxLength: 255),
                        NodeType = c.String(nullable: false, maxLength: 255),
                        PublishmentSystemId = c.Long(nullable: false),
                        ContentModelId = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Long(nullable: false),
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
                        ChannelTemplateId = c.Long(nullable: false),
                        ContentTemplateId = c.Long(nullable: false),
                        Keywords = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ExtendValues = c.String(nullable: false),
                        TenantId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_NodeInfo_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_NodeInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.dm_Node",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_NodeInfo_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_NodeInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.model_Content",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ContentInfo_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ContentInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
