using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Application.Ashx
{
    /// <summary>
    /// CascadeSelect 的摘要说明
    /// </summary>
    public class CascadeSelect : IHttpHandler
    {

        private static readonly List<RegionConfig> _config =new List<RegionConfig>(){
        new RegionConfig(){ Id=1,Name="江苏"}
       ,new RegionConfig(){ Id=2,Name="浙江"}
       ,new RegionConfig(){ Id=3,Name="安徽"}
       ,new RegionConfig(){ Id=4,Name="常州",ParentId=1}
       ,new RegionConfig(){ Id=5,Name="徐州",ParentId=1}
       ,new RegionConfig(){ Id=6,Name="苏州",ParentId=1}
        
       };

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var parentId=context.Request.QueryString["parentId"];
            switch (parentId)
            {
                case "0": break;
                default: break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    public class RegionConfig
    
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }
            
    }
}