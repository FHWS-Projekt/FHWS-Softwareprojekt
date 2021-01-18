using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public MenuManager measuresMenu;

    public MyCamera myCamera;

    public PlayerSettings playerSettings;
    public Image bar;
    public float currentBar;
    public float maxBar = 100f;

    public bool win;
    public bool lose;

    int counter = 1;

    #endregion Attributes

    #region Unity Methods
    private void Start()
    {

        //Generates a list of countries that are not infected
        for(int i = 0; i < countries.Length; i++)
        {
            countries[i].infected = 0;
            healtyCountries.Add(countries[i]);
        }
        //Genreates a list of countinents that are not infected
        for(int i = 0; i < continents.Length; i++)
        {
            healthyContinent.Add(continents[i]);
        }
        //Start of the game with the Patient Zero
        RandomStart();
        //Adds the RandomDistribution into the Daily Task System
        Main.Instance.MyDateTime.DayTasks.Add(() => RandomDistribution());
    }

    private void Update()
    {
        EndingController();
        ObjectClicker();
        HealthBarController();
    }

    #endregion Unity Methods

    #region Methods

    //Randomly distributes the "Patient Zero"
    public void RandomStart()
    {
        //Randomly selcetes a contieneten and then a country for the healty list
        int rdm = Random.Range(0, continents.Length - 1);
        int rdm2 = Random.Range(0, continents[rdm].countries.Length - 1);

        Debug.Log("Neues Virus in " + continents[rdm].name + ", " + continents[rdm].countries[rdm2].countryName + " entdeckt!");

        //Distribuits the Patient Zero
        continents[rdm].countries[rdm2].infected += 1;

        //Removes the contineten and country from the healty list and puts them into the infected list
        infectedContinent.Add(continents[rdm]);
        healthyContinent.Remove(continents[rdm]);
        infectedCountries.Add(continents[rdm].countries[rdm2]);
        healtyCountries.Remove(continents[rdm].countries[rdm2]);
        transmitterContinent = continents[rdm];
        transmitterCountry = continents[rdm].countries[rdm2];

    }
    //Semi-randomly selects the next country that gets a infected 
    public void RandomDistribution()
    {
        //In the first 5 days every contineten has to get one infected  
        if (counter < 6)
        {
            //Randomly selcetes a contieneten and then a country for the healty list
            int rdm = Random.Range(0, healthyContinent.Count);
            int rdm2 = Random.Range(0, healthyContinent[rdm].countries.Length - 1);

            Debug.Log("Neu infiziert: " + healthyContinent[rdm].countries[rdm2].countryName);

            //Distribuits the infected
            healthyContinent[rdm].countries[rdm2].infected += 1;

            //Removes the contineten and country from the healty list and puts them into the infected list
            infectedContinent.Add(healthyContinent[rdm]);
            infectedCountries.Add(healthyContinent[rdm].countries[rdm2]);
            transmitterContinent = healthyContinent[rdm];
            transmitterCountry = healthyContinent[rdm].countries[rdm2];
            healtyCountries.Remove(healthyContinent[rdm].countries[rdm2]);
            healthyContinent.Remove(healthyContinent[rdm]);

            counter++;

        }
        //After the first 5 Days every country will get one infected
        else if (counter < 25)
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
    }
    //Allows that GameObjects in the Scene are clickebale 
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
    
                    //Checks if the hit object is a virus;
                    if(hit.transform.gameObject.name == "Corona Virus")
                    {
                        hit.transform.gameObject.SetActive(false);
                        main.Money = main.Money + 1;
                    }

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
    //Checkes if the condincens are set to end the game 
    public void EndingController()
    {
        if(playerSettings.difficulty == 0)
        {
            if (main.MyDateTime.Day == 50)
            {
                playerSettings.endingDay = (int)main.MyDateTime.Day;
                playerSettings.gameEnding = true;
                Debug.Log("Du hast gewonnen!");
                SceneManager.LoadScene("Outro");
            }
            else if (lose)
            {
                playerSettings.endingDay = (int)main.MyDateTime.Day;
                playerSettings.gameEnding = false;
                Debug.Log("Du hast verloren!");
                SceneManager.LoadScene("Outro");
            }
        }
        else if(playerSettings.difficulty == 1)
        {
            if (main.MyDateTime.Day == 50)
            {
                playerSettings.endingDay = (int)main.MyDateTime.Day;
                playerSettings.gameEnding = true;
                Debug.Log("Du hast gewonnen!");
                SceneManager.LoadScene("Outro");
            }
            else if (lose)
            {
                playerSettings.endingDay = (int)main.MyDateTime.Day;
                playerSettings.gameEnding = false;
                Debug.Log("Du hast verloren!");
                SceneManager.LoadScene("Outro");
            }
        }
        else if(playerSettings.difficulty == 2)
        {
            if (main.MyDateTime.Day == 50)
            {
                playerSettings.endingDay = (int)main.MyDateTime.Day;
                playerSettings.gameEnding = true;
                Debug.Log("Du hast gewonnen!");
                SceneManager.LoadScene("Outro");
            }
            else if (lose)
            {
                playerSettings.endingDay = (int)main.MyDateTime.Day;
                playerSettings.gameEnding = false;
                Debug.Log("Du hast verloren!");
                SceneManager.LoadScene("Outro");
            }
        }
    }
    public void HealthBarController()
    {
        currentBar = (float)main.MyDateTime.Day;
        bar.fillAmount = currentBar / maxBar;
    }

    #endregion Methods
}

