using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResolveResXml.Model;

namespace ResolveResXml.DAL
{
    class CountryManage
    {
        /// <summary>
        /// 获取所有国家
        /// </summary>
        /// <returns></returns>
        public static List<Country> GetCountryList()
        {
            List<Country> CountryList = new List<Country>();
            string[] CountryNameList = AppConfig.GetKeys();
            foreach (string CountryName in CountryNameList)
            {
                Country country = new Country();
                country.CountryName = CountryName;
                country.CountryCode = AppConfig.GetValue(CountryName);
                CountryList.Add(country);
            }
            return CountryList;
        }
    }
}
