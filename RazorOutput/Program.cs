using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Templating;
using RazorEngine.Configuration;

namespace RazorOutput
{
    internal class Program
    {
        static Program()
        {
            TemplateServiceConfiguration config = new TemplateServiceConfiguration();
            config.DisableTempFileLocking = true;
            var service = RazorEngineService.Create(config);
            Engine.Razor = service;
        }

        private static void Main(string[] args)
        {
            string template = "Hello @Model.Name,welcome to RazorEngine";
            string result = Engine.Razor.RunCompile(template, "templatekey", null, new { Name = "World" });
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}