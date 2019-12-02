using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E324
{
    public class Record
    {
        int id;
        string categoryName;

        string description;

        public Record(int id, string categoryName, string description)
        {
            this.id = id;
            this.categoryName = categoryName;
            this.description = description;
        }
        public int Id { get { return this.id; } }
        public string CategoryName { get { return categoryName; } }
        public string Description { get { return description; } }
    }
}