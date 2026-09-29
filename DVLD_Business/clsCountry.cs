using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsCountry
    {
        public string CountryName { get; set; }
        public int CountryID { get; set; }
        private clsCountry(int Id, string CountryName)
        {
            this.CountryID = Id;
            this.CountryName = CountryName;
        }
        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountriesFromDataBase();
        }
        public static clsCountry FindCountyrByName(string CountryName)
        {
            int CountryId = 0;
            if(clsCountryData.FindCountryByName(ref CountryId, CountryName))
            {
                return new clsCountry(CountryId, CountryName);

            }
            return null;
        }
        public static clsCountry FindCountyrByCountryID(int CountryID)
        {

            string CountryName = "";
            if (clsCountryData.FindCountryByID(CountryID, ref CountryName))
            {
                return new clsCountry(CountryID, CountryName);

            }
            return null;
        }
    }
}
