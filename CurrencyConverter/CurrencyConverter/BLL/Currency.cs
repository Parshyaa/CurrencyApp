using CurrencyConverter.BLL.Interfaces;
using CurrencyConverter.Utilities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace CurrencyConverter.BLL
{
    public class Currency : ICurrency
    {
        private readonly IUserSettings UserSettings;

        public Currency(IUserSettings userSettings)
        {
            UserSettings = userSettings;
        }

        public decimal GetRate(string frmCurrency, string toCurrency)
        {
            return GetRateApi(frmCurrency, toCurrency);
        }

        private decimal GetRateApi(string frmCurrency, string toCurrency)
        {
            var key = $"{ frmCurrency}_{toCurrency}";
            var json = new WebClient().DownloadString(string.Format("https://free.currconv.com/api/v7/convert?apiKey={0}&q={1}&compact=ultra", UserSettings.ApiKey, key));
            var rateObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var keyValue = Convert.ToDecimal(rateObject[key]);

            return keyValue;

        }
    }
}
