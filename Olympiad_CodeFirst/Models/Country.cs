using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad_CodeFirst.Models
{
    class Country
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public Country()
        {
            Sportsmen = new List<Sportsman>();
        }

        public ICollection<Sportsman> Sportsmen { get; set; }
    }
}
