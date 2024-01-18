using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lords_Of_Evil___Necromancer
{
    public class NavigationDestinations
    {
        public NavigationDestinations(int row, int col) 
        {
            this.row = row;
            this.col = col;
        }
        int col { get; set; }
        int row { get; set; }
    }
}
