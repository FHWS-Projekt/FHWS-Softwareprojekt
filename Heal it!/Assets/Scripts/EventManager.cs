using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region Attributes

    public Earth earth;
    public Continent[] continents;
    public Country[] countries;

    public List<Continent> infectedContinent;
    public List<Continent> healthyContinent;

    public List<Country> infectedCountries;
    public List<Country> healtyCountries;

    public Continent transmitterContinent;
    public Country transmitterCountry;

    public Continent receiverContinent;
    public Country receiverCountry;

    int counter = 1;
    #endregion Attributes

    #region Unity Methods
    private void Start()
    {
        for(int i = 0; i < countries.Length; i++)
        {
            countries[i].infected = 0;
            healtyCountries.Add(countries[i]);
        }
        for(int i = 0; i < continents.Length; i++)
        {
            healthyContinent.Add(continents[i]);
        }
        RandomStart();
        Main.Instance.MyDateTime.DayTasks.Add(() => RandomDistribution());
 
    }

    #endregion Unity Methods

    #region Methods
    //Patient zero
    public void RandomStart()
    {
        int rdm = Random.Range(0, continents.Length - 1);
        int rdm2 = Random.Range(0, continents[rdm].countries.Length - 1);

        Debug.Log("Start continent: " + continents[rdm].name + " Start country: " + continents[rdm].countries[rdm2].countryName);

        continents[rdm].countries[rdm2].infected += 2;

        infectedContinent.Add(continents[rdm]);
        healthyContinent.Remove(continents[rdm]);

        infectedCountries.Add(continents[rdm].countries[rdm2]);
        healtyCountries.Remove(continents[rdm].countries[rdm2]);

        transmitterContinent = continents[rdm];
        transmitterCountry = continents[rdm].countries[rdm2];

    }
    public void RandomDistribution()
    {
 
        if(counter < 6)
        {
            int rdm = Random.Range(0, healthyContinent.Count);
            int rdm2 = Random.Range(0, healthyContinent[rdm].countries.Length - 1);

            Debug.Log("Transmitter Continent: " + transmitterContinent.name + " Transmitter Country: " + transmitterCountry.name + " ---> " + "Receiver Continent: " + healthyContinent[rdm] + " Receiver Country: " + healthyContinent[rdm].countries[rdm2]);

            transmitterCountry.infected -= 1;
            healthyContinent[rdm].countries[rdm2].infected += 1;

            infectedContinent.Add(healthyContinent[rdm]);
            infectedCountries.Add(healthyContinent[rdm].countries[rdm2]);

            transmitterContinent = healthyContinent[rdm];
            transmitterCountry = healthyContinent[rdm].countries[rdm2];

            healtyCountries.Remove(healthyContinent[rdm].countries[rdm2]);
            healthyContinent.Remove(healthyContinent[rdm]);

            counter++;
        }
        else if(counter < 25)
        {
            int rdm = Random.Range(0, infectedCountries.Count);
            int rdm2 = Random.Range(0, healtyCountries.Count);

            Debug.Log("Transmitter Country: " + infectedCountries[rdm].name + " ---> " + "Receiver Country: " + healtyCountries[rdm2]);

            infectedCountries[rdm].infected -= 1;
            healtyCountries[rdm2].infected += 1;

            infectedCountries.Add(healtyCountries[rdm2]);
            healtyCountries.Remove(healtyCountries[rdm2]);

            counter++;
        }
        else
        {
            int rdm = Random.Range(0, infectedCountries.Count);
            int rdm2 = Random.Range(0, infectedContinent.Count);

            Debug.Log("Transmitter Country: " + infectedCountries[rdm].name + " ---> " + "Receiver Country: " + infectedCountries[rdm].name);

            infectedCountries[rdm].infected -= 1;
            infectedCountries[rdm2].infected += 1;
        }
   
    }
    #endregion Methods
}

