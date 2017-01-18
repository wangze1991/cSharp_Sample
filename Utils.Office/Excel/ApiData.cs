using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utils.Helper;
namespace Utils.Office
{
    public class ApiData:IApiData
    {
        public object GetData(HttpContext context) 
        {
            try
            {
                var pageParam =new {page=1,rows=int.MaxValue };
                var param = JsonConvert.DeserializeAnonymousType(context.Request["dataParams"],pageParam);
                var titles = JsonConvert.DeserializeObject<IEnumerable<IEnumerable<Column>>>(context.Request["titles"]);
                var url = context.Request["action"];
                var result = JsonConvert.DeserializeObject<dynamic>(HttpHelper.GetHtml(url));
                if (result.rows != null)
                {
                    return result.rows;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
