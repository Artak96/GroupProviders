using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
