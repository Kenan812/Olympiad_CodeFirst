using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad_CodeFirst.Models
{
    class Award
    {
        public int Id { get; set; }

        public int SportId { get; set; }
        public Sport Sport { get; set; }

        public int SportsmanId { get; set; }
        public Sportsman Sportsman { get; set; }

        public int MedalId { get; set; }
        public Medal Medal { get; set; }
    }
}
