using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class WeatherController : MonoBehaviour
{

    #region VARIABLES
    [SerializeField]
    private List<string> cities = new List<string>();
    [SerializeField]
    private WeatherItem weatherItem;
    [SerializeField]
    private Transform panel;
    
    #endregion

    #region UNITY EVENTS
    public void Start()
    {
        WeatherItem tempWeatherItem;

        foreach (var city in cities)
        {
            WeatherModel weatherModel = APIHelper.GetWeatherData(city);

            tempWeatherItem = Instantiate(weatherItem);
            tempWeatherItem.transform.SetParent(panel, false);

            tempWeatherItem.Initialize(
                cityName: weatherModel.name,
                temperature: weatherModel.main.temp.ToString(),
                description: weatherModel.weather[0].description
                );
        }

    }
    #endregion


}
