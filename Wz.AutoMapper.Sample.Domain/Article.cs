using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wz.AutoMapper.Sample.Domain
{
    public class Article:IEntity
    {

        public Article() {
            this.Id = Guid.NewGuid();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PostTime { get; set; }

        public string Remark { get; set; }
        public string Author { get; set; }

        public Guid Id { get; set; }
    }
}
