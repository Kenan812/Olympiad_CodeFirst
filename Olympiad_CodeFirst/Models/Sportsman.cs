using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad_CodeFirst.Models
{
    class Sportsman
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<SportsSportsmen> SportsSportsmen { get; set; }
        public ICollection<Award> Awards { get; set; }

        public Sportsman()
        {
            SportsSportsmen = new List<SportsSportsmen>();
            Awards = new List<Award>();
        }
    }
}
