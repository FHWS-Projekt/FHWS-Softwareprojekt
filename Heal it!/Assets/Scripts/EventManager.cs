using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Earth earth;
    public Continent[] continents;
    public Country[] countries;
    public TimeCycle timeCycle;
    private void Start()
    {
        RandomStart();
    }
    //Patient zero
    public void RandomStart()
    {
        int rdm = (int)Random.Range(0.0f, 24.0f);
        countries[rdm].infected = 1;
        Debug.Log("Start country: " + countries[rdm].countryName);
    }
}
