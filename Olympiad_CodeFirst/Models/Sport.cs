using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad_CodeFirst.Models
{
    class Sport
    {
        public int Id { get; set; }

        public string SportName { get; set; }

        public ICollection<SportsSportsmen> SportsSportsmen { get; set; }
        public ICollection<Award> Awards { get; set; }

        public Sport()
        {
            SportsSportsmen = new List<SportsSportsmen>();
            Awards = new List<Award>();
        }

    }
}
