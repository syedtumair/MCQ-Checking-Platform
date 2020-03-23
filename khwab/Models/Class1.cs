using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using khwab.Models;

namespace khwab.Models
{
    public class Class1
    {
        private khwabEntities db = new khwabEntities();
        public List<mcq> mcqs = new List<mcq>();
        public string paperId { get; set; }
        public void read(string id)
        {
            mcqs = db.mcqs.Where(x => x.paperId == id).ToList();
        }
    }
}