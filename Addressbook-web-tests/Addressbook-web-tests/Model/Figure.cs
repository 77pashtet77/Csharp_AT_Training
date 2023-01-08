using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    internal class Figure
    {
        private bool isColored = false;

        public bool IsColored
        {
            get
            {
                return isColored;
            }
            set
            {
                isColored = value;
            }
        }
    }
}
