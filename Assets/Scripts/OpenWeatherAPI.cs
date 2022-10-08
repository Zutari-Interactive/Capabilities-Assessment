using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using TMPro;

public class OpenWeatherAPI : MonoBehaviour
{
    public string apiKey;
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
        public float temp;
    }

    [Serializable]
    public class WeatherData
    {
        public string name;
        public Main main;
        public List<Weather> weather;
    }

    private List<WeatherData> weatherDatas = new List<WeatherData>();

    public GameObject[] gridElements;

    // Start is called before the first frame update
    void Start()
    {
        foreach (string city in provincialCapitalCities)
        {
            StartCoroutine(WeatherQuery(city));
        }
    }

    /// <summary>
    /// Display the weather data on a UI
    /// </summary>
    public void ShowWeatherData()
    {
        for(int i = 0; i < weatherDatas.Count; i++)
        {
            gridElements[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "City: " + weatherDatas[i].name;
            gridElements[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Temperature: " + weatherDatas[i].main.temp.ToString("0.00") + " DC";
            gridElements[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Description: " + weatherDatas[i].weather[0].description;
        }
    }

    /// <summary>
    /// Co-routine to make web requests to openweathermap
    /// </summary>
    /// <param name="provancialCapitalCity">Name of a South African city</param>
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

            if (weatherDatas.Count == provincialCapitalCities.Count)
            {
                ShowWeatherData();
            }
        }
    }
}
