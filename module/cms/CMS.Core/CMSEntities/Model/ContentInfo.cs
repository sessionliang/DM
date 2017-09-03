using System;
using Abp.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.CMSEntities
{
    /// <summary>
    /// 内容实体类
    /// </summary>
    [Table("model_Content")]
    public class ContentInfo : FullAuditedEntity<long>, IMustHaveTenant
    {
        /// <summary>
        /// 栏目主键ID
        /// </summary>
        [Description("栏目主键ID")]
        public int NodeId { get; set; }

        /// <summary>
        /// 站点主键ID
        /// </summary>
        [Required, DefaultValue(0)]
        public int PublishmentSystemId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required, DefaultValue(0)]
        public int Taxis { get; set; }

        /// <summary>
        /// 标记
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string Tags { get; set; }

        /// <summary>
        /// 所属内容组集合
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string ContentGroupNameCollection { get; set; }

        /// <summary>
        /// 资源ID
        /// </summary>
        [Required, DefaultValue(0)]
        public int SourceId { get; set; }

        /// <summary>
        /// 引用ID
        /// </summary>
        [Required, DefaultValue(0)]
        public int ReferenceId { get; set; }

        /// <summary>
        /// 是否审核通过
        /// </summary>
        [Required, MaxLength(18), DefaultValue("")]
        public string IsChecked { get; set; }

        /// <summary>
        /// 审核通过级别
        /// </summary>
        [Required, DefaultValue(0)]
        public int CheckedLevel { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        [Required, DefaultValue(0)]
        public int Comments { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [Required, DefaultValue(0)]
        public int Photos { get; set; }

        /// <summary>
        /// 引用ID
        /// </summary>
        [Required, DefaultValue(0)]
        public int Teleplays { get; set; }

        /// <summary>
        /// 热点
        /// </summary>
        [Required, DefaultValue(0)]
        public int Hits { get; set; }


        /// <summary>
        /// 热点周
        /// </summary>
        [Required, DefaultValue(0)]
        public int HitsByDay { get; set; }

        /// <summary>
        /// 热点周
        /// </summary>
        [Required, DefaultValue(0)]
        public int HitsByWeek { get; set; }

        /// <summary>
        /// 热点月份
        /// </summary>
        [Required, DefaultValue(0)]
        public int HitsByMonth { get; set; }

        /// <summary>
        /// 最后一次点击时间
        /// </summary>
        [Required, DefaultValue(0)]
        public DateTime LastHitsDate { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [Required, DefaultValue("")]
        public string SettingsXml { get; set; }

        /// <summary>
        /// 内容标题
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string Title { get; set; }

        /// <summary>
        /// 内容副标题
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string SubTitle { get; set; }

        /// <summary>
        /// 内容图片地址
        /// </summary>
        [Required, MaxLength(200), DefaultValue("")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 视频路径
        /// </summary>
        [Required, MaxLength(200), DefaultValue("")]
        public string VideoUrl { get; set; }

        /// <summary>
        /// 内容附件地址
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string FileUrl { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 内容正文
        /// </summary>
        [Required, DefaultValue("")]
        public string Content { get; set; }

        /// <summary>
        /// 概要
        /// </summary>
        [Required, DefaultValue("")]
        public string Summary { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string Author { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [Required, MaxLength(255), DefaultValue("")]
        public string Source { get; set; }

        /// <summary>
        /// 是否推荐内容
        /// </summary>
        [Required, MaxLength(18), DefaultValue("")]
        public string IsRecommend { get; set; }

        /// <summary>
        /// 是否热点内容
        /// </summary>
        [Required, MaxLength(18), DefaultValue("")]
        public string IsHot { get; set; }

        /// <summary>
        /// 是否醒目内容
        /// </summary>
        [Required, MaxLength(18), DefaultValue("")]
        public string IsColor { get; set; }

        /// <summary>
        /// 是否置顶内容
        /// </summary>
        [Required, MaxLength(18), DefaultValue("")]
        public string IsTop { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CheckTaskDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UnCheckTaskDate { get; set; }

        #region 字段对照
        //[ID] [int] IDENTITY(1,1) NOT NULL,
        //[NodeID] [int] NOT NULL DEFAULT ((0)),
        //[PublishmentSystemID] [int] NOT NULL DEFAULT ((0)),
        //[AddUserName] [nvarchar](255) NOT NULL DEFAULT (''),
        //[LastEditUserName] [nvarchar](255) NOT NULL DEFAULT (''),
        //[LastEditDate] [datetime] NOT NULL DEFAULT (getdate()),
        //[Taxis] [int] NOT NULL DEFAULT ((0)),
        //[ContentGroupNameCollection] [nvarchar](255) NOT NULL DEFAULT (''),
        //[Tags] [nvarchar](255) NOT NULL DEFAULT (''),
        //[SourceID] [int] NOT NULL DEFAULT ((0)),
        //[ReferenceID] [int] NOT NULL DEFAULT ((0)),
        //[IsChecked] [varchar](18) NOT NULL DEFAULT (''),
        //[CheckedLevel] [int] NOT NULL DEFAULT ((0)),
        //[Comments] [int] NOT NULL DEFAULT ((0)),
        //[Photos] [int] NOT NULL DEFAULT ((0)),
        //[Teleplays] [int] NOT NULL DEFAULT ((0)),
        //[Hits] [int] NOT NULL DEFAULT ((0)),
        //[HitsByDay] [int] NOT NULL DEFAULT ((0)),
        //[HitsByWeek] [int] NOT NULL DEFAULT ((0)),
        //[HitsByMonth] [int] NOT NULL DEFAULT ((0)),
        //[LastHitsDate] [datetime] NOT NULL DEFAULT (getdate()),
        //[SettingsXML] [ntext] NOT NULL DEFAULT (''),
        //[Title] [nvarchar](255) NOT NULL DEFAULT (''),
        //[SubTitle] [nvarchar](255) NOT NULL DEFAULT (''),
        //[ImageUrl] [varchar](200) NOT NULL DEFAULT (''),
        //[VideoUrl] [varchar](200) NOT NULL DEFAULT (''),
        //[FileUrl] [varchar](200) NOT NULL DEFAULT (''),
        //[LinkUrl] [nvarchar](200) NOT NULL DEFAULT (''),
        //[Content] [ntext] NOT NULL DEFAULT (''),
        //[Summary] [ntext] NOT NULL DEFAULT (''),
        //[Author] [nvarchar](255) NOT NULL DEFAULT (''),
        //[Source] [nvarchar](255) NOT NULL DEFAULT (''),
        //[IsRecommend] [varchar](18) NOT NULL DEFAULT (''),
        //[IsHot] [varchar](18) NOT NULL DEFAULT (''),
        //[IsColor] [varchar](18) NOT NULL DEFAULT (''),
        //[IsTop] [varchar](18) NOT NULL DEFAULT (''),
        //[AddDate] [datetime] NOT NULL DEFAULT (getdate()),
        //[CheckTaskDate] [datetime] NULL,
        //[UnCheckTaskDate] [datetime] NULL,
        #endregion


        public int TenantId
        {
            get;
            set;
        }
    }
}
