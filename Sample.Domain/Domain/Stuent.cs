using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Domain
{
    public partial class Student : BaseEntity
    {
        public Student() {
            this.Books = new HashSet<Book>();
            this.Scores = new HashSet<Score>();
        }
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public PersonSex Sex { get; set; }

        public virtual StudentAddress StudentAddress { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Score> Scores { get; set; }

    }
}