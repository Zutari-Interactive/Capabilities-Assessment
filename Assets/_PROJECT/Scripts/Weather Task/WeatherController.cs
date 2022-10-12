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
    #endregion

    #region UNITY EVENTS
    public void Start()
    {
        GameObject _template = transform.GetChild(0).gameObject;
        GameObject _placeHolder;

        foreach (var city in cities)
        {
            WeatherModel _weatherModel = APIHelper.GetWeatherData(city);

            _placeHolder = Instantiate(_template, transform);  

            _placeHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _weatherModel.name;
            _placeHolder.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _weatherModel.main.temp.ToString();
            _placeHolder.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _weatherModel.weather[0].description;
        }

    }
    #endregion


}
