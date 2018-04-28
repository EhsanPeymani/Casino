using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Domain
{
    public class ReelFaceUp
    {
        public int SymbolIndex { get; set; }
        public string symbolName { get; set; }
        public string SymbolUrl { get; set; }

        public ReelFaceUp(int index, string name)
        {
            this.SymbolIndex = index;
            this.symbolName = name;
            this.SymbolUrl = string.Format(@"\Images\{0}.png", name);
        }
    }
}
