using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    #region Attributes

    public Earth earth;
    public Continent[] continents;
    public Country[] countries;
    public Main main;

    public List<Continent> infectedContinent;
    public List<Continent> healthyContinent;

    public List<Country> infectedCountries;
    public List<Country> healtyCountries;

    public Continent transmitterContinent;
    public Country transmitterCountry;

    public Continent receiverContinent;
    public Country receiverCountry;

    public GameObject measures;
    public GameObject measures2;
    public MeasuresMenu measuresMenu;

    public MyCamera myCamera;

    public bool win;
    public bool lose;

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
        Main.Instance.MyDateTime.DayTasks.Add(() => BRandomDistribution());
        // Main.Instance.MyDateTime.DayTasks.Sort();
    }

    private void Update()
    {
        EndingController();
        ObjectClicker();
    }

    #endregion Unity Methods

    #region Methods

    //Patient zero
    public void RandomStart()
    {
        int rdm = Random.Range(0, continents.Length - 1);
        int rdm2 = Random.Range(0, continents[rdm].countries.Length - 1);

        Debug.Log("Start continent: " + continents[rdm].name + " Start country: " + continents[rdm].countries[rdm2].countryName);

        continents[rdm].countries[rdm2].infected += 1;

        infectedContinent.Add(continents[rdm]);
        healthyContinent.Remove(continents[rdm]);

        infectedCountries.Add(continents[rdm].countries[rdm2]);
        healtyCountries.Remove(continents[rdm].countries[rdm2]);

        transmitterContinent = continents[rdm];
        transmitterCountry = continents[rdm].countries[rdm2];

    }
    public void BRandomDistribution()
    {
 
        if(counter < 6)
        {
            int rdm = Random.Range(0, healthyContinent.Count);
            int rdm2 = Random.Range(0, healthyContinent[rdm].countries.Length - 1);

            Debug.Log("Angesteckt: " + healthyContinent[rdm].countries[rdm2].countryName);

            //transmitterCountry.infected -= 1;
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

            Debug.Log("Angesteckt: " + healtyCountries[rdm2].countryName);

            //infectedCountries[rdm].infected -= 1;
            healtyCountries[rdm2].infected += 1;

            infectedCountries.Add(healtyCountries[rdm2]);
            healtyCountries.Remove(healtyCountries[rdm2]);

            counter++;
        }
        else
        {
            int rdm = Random.Range(0, infectedCountries.Count);
            int rdm2 = Random.Range(0, infectedContinent.Count);

            Debug.Log("Angesteckt: " + infectedCountries[rdm].countryName);

            //infectedCountries[rdm].infected -= 1;
            infectedCountries[rdm2].infected += 1;
        }
   
    }
    public void ObjectClicker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                
                if (hit.transform)
                {
                    GameObject continent = hit.transform.gameObject;
                    Debug.Log(continent.name);
                    ContinentDisplay continentDisplay = (ContinentDisplay)continent.GetComponent(typeof(ContinentDisplay));
                    if (continentDisplay != null){

                        if (measures2.activeSelf)
                        {
                            measures2.SetActive(false);
                            measuresMenu.ShowContinent(continentDisplay);
                        }
                        else if (measures.activeSelf)
                        {
                            measuresMenu.ShowContinent(continentDisplay);
                        }
                        else
                        {
                            measuresMenu.OnClickMenuActiv();
                            measuresMenu.ShowContinent(continentDisplay);
                        }
                    }
                }
            }
        }
    }
    public void EndingController()
    {
        if (main.MyDateTime.Day == 50)
        {
            Debug.Log("Du hast gewonnen!");
        }
        else if (lose)
        {
            Debug.Log("Du hast verloren!");
        }
    }

    #endregion Methods
}

