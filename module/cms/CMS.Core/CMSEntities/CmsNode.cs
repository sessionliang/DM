using System;
using Abp.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace CMS.CMSEntities
{
    /// <summary>
    /// 栏目实体类
    /// </summary>
    public class CmsNode : AuditedEntity
    {
        ///// <summary>
        ///// 栏目主键ID
        ///// </summary>
        //[Key, Description("栏目主键ID")]
        //public int NodeId { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        [MaxLength(255), Required, DefaultValue(""), Description("栏目名称")]
        public string NodeName { get; set; }

        /// <summary>
        /// 栏目类型
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string NodeType { get; set; }

        /// <summary>
        /// 系统发布ID
        /// </summary>
        [Required, DefaultValue(0)]
        public int PublishmentSystemId { get; set; }

        /// <summary>
        /// 内容主键ID
        /// </summary>
        [Required, MaxLength(50), DefaultValue("")]
        public string ContentModelId { get; set; }

        /// <summary>
        /// 父级节点主键ID
        /// </summary>
        [Required, DefaultValue(0)]
        public int ParentId { get; set; }

        /// <summary>
        /// 父级节点路径
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string ParentsPath { get; set; }

        /// <summary>
        /// 父级节点个数
        /// </summary>
        [Required, DefaultValue(0)]
        public int ParentsCount { get; set; }

        /// <summary>
        /// 子级节点个数
        /// </summary>
        [Required, DefaultValue(0)]
        public int ChildrenCount { get; set; }

        /// <summary>
        /// 是否叶子节点
        /// </summary>
        [Required, MaxLength(18), DefaultValue("")]
        public string IsLastNode { get; set; }

        /// <summary>
        /// 栏目索引名
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string NodeIndexName { get; set; }

        /// <summary>
        /// todo::有待补充
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string NodeGroupNameCollection { get; set; }

        /// <summary>
        /// todo::有待补充
        /// </summary>
        [Required, DefaultValue(0)]
        public int Taxis { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        [Required, MaxLength(200), DefaultValue("")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required, DefaultValue("")]
        public string Content { get; set; }

        /// <summary>
        /// 内容数量
        /// </summary>
        [Required, DefaultValue(0)]
        public int ContentNum { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        [Required, DefaultValue(0)]
        public int CommentNum { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [Required, MaxLength(200), DefaultValue("")]
        public string FilePath { get; set; }

        /// <summary>
        /// 频道文件路径规则
        /// </summary>
        [Required, MaxLength(200), DefaultValue("")]
        public string ChannelFilePathRule { get; set; }

        /// <summary>
        /// 内容文件路径规则
        /// </summary>
        [Required, MaxLength(200), DefaultValue("")]
        public string ContentFilePathRule { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [Required, MaxLength(200), DefaultValue("")]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 链接类型
        /// </summary>
        [Required, MaxLength(200), DefaultValue("")]
        public string LinkType { get; set; }

        /// <summary>
        /// 频道模版ID
        /// </summary>
        [Required, DefaultValue(0)]
        public int ChannelTemplateId { get; set; }

        /// <summary>
        /// 内容模版ID
        /// </summary>
        [Required, DefaultValue(0)]
        public int ContentTemplateId { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string Keywords { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [Required, DefaultValue("")]
        public string ExtendValues { get; set; }


        #region 字段对照 
        //[NodeID] [int] IDENTITY(1,1) NOT NULL,
        //[NodeName] [nvarchar](255) NOT NULL DEFAULT (''),
        //[NodeType] [varchar](50) NOT NULL DEFAULT (''),
        //[PublishmentSystemID] [int] NOT NULL DEFAULT ((0)),
        //[ContentModelID] [varchar](50) NOT NULL DEFAULT (''),
        //[ParentID] [int] NOT NULL DEFAULT ((0)),
        //[ParentsPath] [nvarchar](255) NOT NULL DEFAULT (''),
        //[ParentsCount] [int] NOT NULL DEFAULT ((0)),
        //[ChildrenCount] [int] NOT NULL DEFAULT ((0)),
        //[IsLastNode] [varchar](18) NOT NULL DEFAULT (''),
        //[NodeIndexName] [nvarchar](255) NOT NULL DEFAULT (''),
        //[NodeGroupNameCollection] [nvarchar](255) NOT NULL DEFAULT (''),
        //[Taxis] [int] NOT NULL DEFAULT ((0)),
        //[AddDate] [datetime] NOT NULL DEFAULT (getdate()),
        //[ImageUrl] [varchar](200) NOT NULL DEFAULT (''),
        //[Content] [ntext] NOT NULL DEFAULT (''),
        //[ContentNum] [int] NOT NULL DEFAULT ((0)),
        //[CommentNum] [int] NOT NULL DEFAULT ((0)),
        //[FilePath] [varchar](200) NOT NULL DEFAULT (''),
        //[ChannelFilePathRule] [varchar](200) NOT NULL DEFAULT (''),
        //[ContentFilePathRule] [varchar](200) NOT NULL DEFAULT (''),
        //[LinkUrl] [varchar](200) NOT NULL DEFAULT (''),
        //[LinkType] [varchar](200) NOT NULL DEFAULT (''),
        //[ChannelTemplateID] [int] NOT NULL DEFAULT ((0)),
        //[ContentTemplateID] [int] NOT NULL DEFAULT ((0)),
        //[Keywords] [nvarchar](255) NOT NULL DEFAULT (''),
        //[Description] [nvarchar](255) NOT NULL DEFAULT (''),
        //[ExtendValues] [ntext] NOT NULL DEFAULT (''), 
        #endregion

    }
}
