using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;


public static class APIHelper 
{
    private const string apiKey = "0467fe1ec6b59857800af072cfc8e987";
    public static WeatherModel GetWeatherData(string cityName)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q="+ cityName + ",za&appid=" + apiKey);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        return JsonConvert.DeserializeObject<WeatherModel>(json);
    }
}
