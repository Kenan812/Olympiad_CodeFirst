using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad_CodeFirst.Models
{
    class SportsSportsmen
    {
        public int SportId { get; set; }
        public Sport Sport { get; set; }

        public int SportsmanId { get; set; }
        public Sportsman Sportsman { get; set; }
    }
}
