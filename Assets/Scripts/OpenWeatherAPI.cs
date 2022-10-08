using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.IO;
using System.Threading.Tasks;

public class OpenWeatherAPI : MonoBehaviour
{
    public string apiKey;
    HttpWebRequest request;
    private List<string> provincialCapitalCities = new List<string>() { "Polokwane", "Johannesburg","Pietermaritzburg",
                                                                         "Bhisho", "Nelspruit", "Bloemfontein",
                                                                        "Kimberley", "Mahikeng", "Cape Town" };
    
    [Serializable]
    public class Weather
    {
        public string main;
        public string description;
    }

    [Serializable]
    public class Main
    {
        public string temp;
    }

    [Serializable]
    public class WeatherData
    {
        public string name;
        public Main main;
        public List<Weather> weather;
    }

    private List<WeatherData> weatherDatas = new List<WeatherData>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (string city in provincialCapitalCities)
        {
            Debug.Log(city);
            StartCoroutine(WeatherQuery(city));
        }
    }

    /// <summary>
    /// Co-routine to make web requests to openweathermap
    /// </summary>
    /// <param name="provancialCapitalCity">Name of a South African city</param>
    /// <returns></returns>
    IEnumerator WeatherQuery(string provancialCapitalCity)
    {
        using (UnityWebRequest request = UnityWebRequest.Get($"https://api.openweathermap.org/data/2.5/weather?q={provancialCapitalCity},za&units=metric&appid={apiKey}"))
        {
            yield return request.SendWebRequest();

            while (!request.isDone)
            {
                yield return null;
            }
                
            byte[] result = request.downloadHandler.data;
            string jsonResponse = System.Text.Encoding.Default.GetString(result);
            WeatherData data = JsonUtility.FromJson<WeatherData>(jsonResponse);
            weatherDatas.Add(data);
        }
    }
}
