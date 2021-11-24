using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad_CodeFirst.Models
{
    class Medal
    {
        public int Id { get; set; }

        public int Place { get; set; }

        public ICollection<Award> Awards { get; set; }

        public Medal()
        {
            Awards = new List<Award>();
        }
    }
}
