using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeatherModel
{  
    public List<Weather> weather { get; set; }
    public Main main { get; set; }
    public string name { get; set; }
}

public class Main
{
    public double temp { get; set; }
    public double feels_like { get; set; }
    public double temp_min { get; set; }
    public double temp_max { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}



