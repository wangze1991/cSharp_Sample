using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Sample.Controllers;
using Newtonsoft.Json.Linq;
using Utils;
using System.Web.Routing;
namespace Mvc.Sample
{
    public class ControllerActivate
    {

        public object GetData() {
            HomeController home = new HomeController();
            var  result=  home.SessionTest();
            return result;
        }
        private IDictionary<string, string> GetQueryParam(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return null;
            IDictionary<string, string> arguments = new Dictionary<string, string>();
            JObject jObject = JObject.Parse(json);
            foreach (var item in jObject)
            {
                //因为json没有嵌套，所以只要包含一级就可以了
                arguments.Add(item.Key, item.Value.Value<string>());
            }
            return arguments;
        }
    }
}