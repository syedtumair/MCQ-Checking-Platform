using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataget
{
    public class PaperData
    {
        private khwabEntities dab = new khwabEntities();

        public List<String> read(string id)
        {
            return dab.mcqs.Where(x => x.paperId == id).Select(m => m.mcqOption).ToList();
            // .Where(x => x.paperId == id).ToList();
        }



    }
}
