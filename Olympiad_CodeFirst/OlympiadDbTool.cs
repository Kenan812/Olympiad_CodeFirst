using Microsoft.EntityFrameworkCore;
using Olympiad_CodeFirst.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;

namespace Olympiad_CodeFirst
{
    class OlympiadDbTool
    {
        private OlympiadContext _db = new OlympiadContext();


        public void InsertAll()
        {
            InsertAllCountries();
            InsertAllSportmen();
            InsertAllSports();
            InsertAllSportsSportmen();
            InsertAllMedals();
            InsertAllAwards();
        }

        #region DB Inserts

        public void InsertCountry(string countryName)
        {
            try
            {
                _db.Countries.Add(new Country { CountryName = countryName });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void InsertSportman(string firstName, string lastName, int countryId)
        {
            try
            {
                _db.Sportsmen.Add(new Sportsman { FirstName = firstName, LastName = lastName, CountryId = countryId });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void InsertSport(string sportName)
        {
            try
            {
                _db.Sports.Add(new Sport { SportName = sportName });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void InsertSportsSportsman(int sportId, int sportsmanId)
        {
            try
            {
                _db.SportsSportsmen.Add(new SportsSportsmen { SportId = sportId, SportsmanId = sportsmanId });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void InsertMedal(int place)
        {
            try
            {
                _db.Medals.Add(new Medal { Place = place });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nStack Trace:" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void InsertAward(int sportId, int sportsmanId, int medalId)
        {
            try
            {
                _db.Awards.Add(new Award { SportId = sportId, SportsmanId = sportsmanId, MedalId = medalId });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion


        #region Values Insert

        private void InsertAllCountries()
        {
            InsertCountry("Russia");
            InsertCountry("USA");
            InsertCountry("China");
            InsertCountry("Australia");
        }


        private void InsertAllSportmen()
        {
            InsertSportman("Valeriy", "Vachovskiy", 1);
            InsertSportman("Oleg", "Radinskiy", 1);
            InsertSportman("Alxanrd", "Levovskiy", 1);

            InsertSportman("John", "Creamer", 2);
            InsertSportman("Perish", "Ains", 2);
            InsertSportman("Harry", "Peterson", 2);

            InsertSportman("San-Xuan", "Chu", 3);
            InsertSportman("Dzin", "Vin", 3);
            InsertSportman("Cis", "Tri", 3);

            InsertSportman("Daimong", "Bratt", 4);
            InsertSportman("Chris", "Jason", 4);
            InsertSportman("Henry", "Brown", 4);
        }


        private void InsertAllSports()
        {
            InsertSport("Weightlifting");
            InsertSport("Athletics");
            InsertSport("Bowling");
            InsertSport("Tennis");
        }


        private void InsertAllSportsSportmen()
        {
            InsertSportsSportsman(1, 1);
            InsertSportsSportsman(3, 1);
            InsertSportsSportsman(4, 2);
            InsertSportsSportsman(2, 3);
            InsertSportsSportsman(2, 4);
            InsertSportsSportsman(3, 4);
            InsertSportsSportsman(3, 5);
            InsertSportsSportsman(4, 6);
            InsertSportsSportsman(2, 7);
            InsertSportsSportsman(1, 8);
            InsertSportsSportsman(4, 9);
            InsertSportsSportsman(3, 10);
            InsertSportsSportsman(2, 10);
            InsertSportsSportsman(2, 11);
            InsertSportsSportsman(1, 12);
        }


        private void InsertAllMedals()
        {
            InsertMedal(1);
            InsertMedal(2);
            InsertMedal(3);
        }


        private void InsertAllAwards()
        {
            InsertAward(1, 1, 1);
            InsertAward(3, 1, 3);
            InsertAward(2, 3, 2);
            InsertAward(3, 4, 1);
            InsertAward(4, 6, 1);
            InsertAward(2, 7, 1);
            InsertAward(4, 9, 3);
            InsertAward(2, 10, 3);
            InsertAward(1, 12, 3);
            InsertAward(4, 2, 2);
            InsertAward(3, 5, 2);
            InsertAward(1, 8, 2);

        }


        #endregion


        #region Queries

        public IEnumerable GetAllSportmen()
        {
            
            try
            {
                _db.Sportsmen.Select(x => x).Load();

                ObservableCollection<object> sportsmen = new ObservableCollection<object>();

                var query = _db.Sportsmen.Select(x => new { x.Id, x.FirstName, x.LastName, x.Country.CountryName });

                foreach (var sportsman in query)
                {
                    sportsmen.Add(sportsman);
                }

                return sportsmen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }


        public IEnumerable GetAllSports()
        {

            try
            {
                _db.Sports.Select(x => x).Load();

                ObservableCollection<object> sports = new ObservableCollection<object>();

                var query = _db.Sports.Select(x => new { x.Id, x.SportName});

                foreach (var sport in query)
                {
                    sports.Add(sport);
                }

                return sports;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }


        public IEnumerable GetAllCountries()
        {

            try
            {
                _db.Countries.Select(x => x).Load();

                ObservableCollection<object> countries = new ObservableCollection<object>();

                var query = _db.Countries.Select(x => new { x.Id, x.CountryName });

                foreach (var country in query)
                {
                    countries.Add(country);
                }

                return countries;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }


        public IEnumerable GetSportmanById(int id)
        {
            try
            {
                _db.Sportsmen.Select(x => x).Load();
                _db.Sports.Select(x => x).Load();
                _db.SportsSportsmen.Select(x => x).Load();
                _db.Medals.Select(x => x).Load();
                _db.Awards.Select(x => x).Load();
                _db.Countries.Select(x => x).Load();

                ObservableCollection<object> sportmanInfo = new ObservableCollection<object>();



                var query = (from s in _db.Sportsmen
                             where s.Id == id
                             join ss in _db.SportsSportsmen on s.Id equals ss.SportsmanId
                             join sport in _db.Sports on ss.SportId equals sport.Id
                             join a in _db.Awards on s.Id equals a.SportsmanId
                             where a.SportId == sport.Id
                             join m in _db.Medals on a.MedalId equals m.Id
                             select new {s.Id, s.FirstName, s.LastName, s.Country.CountryName, sport.SportName, m.Place});

        

                foreach (var sportman in query)
                {
                    sportmanInfo.Add(sportman);
                }

                return sportmanInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }


        public IEnumerable GetSportById(int id)
        {
            try
            {
                _db.Sportsmen.Select(x => x).Load();
                _db.Sports.Select(x => x).Load();
                _db.SportsSportsmen.Select(x => x).Load();
                _db.Medals.Select(x => x).Load();
                _db.Awards.Select(x => x).Load();
                _db.Countries.Select(x => x).Load();

                List<Tuple<string, int, int, int>> sports = new List<Tuple<string, int, int, int>>();

                string sportName = _db.Sports.Where(s => s.Id == id).FirstOrDefault().SportName;
                int medalCount = _db.Awards.Where(a => a.SportId == id).Select(a => a.MedalId).Count();
                int sportmanCount = _db.Awards.Where(a => a.SportId == id).Select(a => a.SportsmanId).Count();
                int countryCount = _db.Awards.Where(a => a.SportId == id).Select(a => a.Sportsman).Select(s => s.CountryId).Count();

                List<Tuple<string, int, int, int>> ls = new List<Tuple<string, int, int, int>>();
                ls.Add(new Tuple<string, int, int, int>(sportName.ToString(), medalCount, sportmanCount, countryCount));
                
                return ls;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }


        public IEnumerable GetCountryById(int id)
        {
            try
            {
                _db.Sportsmen.Select(x => x).Load();
                _db.Sports.Select(x => x).Load();
                _db.SportsSportsmen.Select(x => x).Load();
                _db.Medals.Select(x => x).Load();
                _db.Awards.Select(x => x).Load();
                _db.Countries.Select(x => x).Load();

                List<Tuple<string, int, int, int>> countries = new List<Tuple<string, int, int, int>>();

                string countyName = _db.Countries.Where(c => c.Id == id).FirstOrDefault().CountryName;


                List<int> ids = new List<int>();
                foreach (int i in _db.Sportsmen.Where(s => s.CountryId == id).Select(s => s.Id))
                {
                    ids.Add(i);
                }

                int medalCount = _db.Awards.Where(a => ids.Contains(a.SportsmanId)).Select(aa => aa.MedalId).Count();
                int sportmanCount = _db.Sportsmen.Where(s => s.CountryId == id).Count();
                int sportCount = _db.Sportsmen.Where(s => s.CountryId == id).SelectMany(a => a.SportsSportsmen).Select(ss => ss.SportId).Count();

                List<Tuple<string, int, int, int>> ls = new List<Tuple<string, int, int, int>>();
                ls.Add(new Tuple<string, int, int, int>(countyName.ToString(), medalCount, sportmanCount, sportCount));

                return ls;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }


        public IEnumerable GetTopCountriesByMedals()
        {
            _db.Sportsmen.Select(x => x).Load();
            _db.Sports.Select(x => x).Load();
            _db.SportsSportsmen.Select(x => x).Load();
            _db.Medals.Select(x => x).Load();
            _db.Awards.Select(x => x).Load();
            _db.Countries.Select(x => x).Load();


            var query = _db.Countries.OrderBy(c => c.Sportsmen.Select(s => s.Awards).SelectMany(a => a).OrderBy(a => a.Medal.Place)).Select(c => c.CountryName);


            return null;
        }

        #endregion

    }
}
