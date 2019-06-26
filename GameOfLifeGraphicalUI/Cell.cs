using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLifeGraphicalUI
{
    class Cell : PictureBox
    {
        public bool Lives { get; set; }
        public bool? livesnextround { get; set; }

        public Cell(bool lives)
        {
            Lives = lives;
            livesnextround = null;
        }
    }
}
