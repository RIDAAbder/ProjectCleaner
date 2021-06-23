using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCleaner.Model
{

    public class parameter
    {
        public parameter(int Index,string Name)
        {
            this.Index = Index;
            this.Name = Name;
        }
        public int Index { get; set; }
        public string Name { get; set; }
    }
}
