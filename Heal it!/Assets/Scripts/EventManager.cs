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
    public void RandomDistribution()
    {
        Continent transmitterContinent = null;
        Country transmitterCountry= null;
        Continent receiverContinent = null;
        Country receiverCountry = null;

        for (int i = 0; i < continents.Length; i++)
        {
            for (int a = 0; a < continents[i].countries.Length; i++)
            {
                if(continents[i] != transmitterContinent)
                {
                    if (continents[i].countries[a].infected != 0 && continents[i].countries[a] != transmitterCountry)
                    {
                        transmitterContinent = continents[i];
                        transmitterCountry = continents[i].countries[a];
                    }
                }
            }
        }
        for (int i = 0; i < continents.Length; i++)
        {
            for (int a = 0; a < continents[i].countries.Length; i++)
            {
                if (continents[i] != receiverContinent)
                {
                    if (continents[i].countries[a].infected == 0 && continents[i].countries[a] != receiverCountry)
                    {
                        receiverContinent = continents[i];
                        receiverCountry = continents[i].countries[a];
                    }
                }
            }
        }
        if (transmitterCountry != null && receiverCountry != null)
        {
            transmitterCountry.infected -= 1;
            receiverCountry.infected += 1;
            Debug.Log(transmitterCountry.name + " --- > " + receiverCountry.name);
        }
    }
}

