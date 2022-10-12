using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeatherItem : MonoBehaviour
{
    #region VARIABLES 
    [SerializeField]
    private TextMeshProUGUI _cityName;
    [SerializeField]
    private TextMeshProUGUI _temperature;
    [SerializeField]
    private TextMeshProUGUI _description;
    #endregion

    #region INITIALIZE
    public void Initialize(string cityName, string temperature, string description)
    {
        _cityName.text = cityName;
        _temperature.text = temperature;
        _description.text = description;
    }
    #endregion

}
