using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    #region Attributes

    public GameObject measuresMenuActiv;
    public GameObject measures2MenuActiv;

    public TextMeshProUGUI continentName;

    public TextMeshProUGUI countryName;
    public TextMeshProUGUI residents;
    public TextMeshProUGUI infected;
    public TextMeshProUGUI influenceE;
    public TextMeshProUGUI influenceP;

    public Country country;
    public Main mainScript;
    public EventManager eventScript;
    public Button pauseButton;
    public Button startButton;
    public ButtonAnim buttonAnim;

    public Button[] continentButtons;
    public Button[] countryButtons;
    public Button[] measursButtons;
    public Button[] rankingButtons;
    public TextMeshProUGUI[] measursCosts;
    public TextMeshProUGUI[] infectedCount;
    public Country[] countriesSort;

    public GameObject myBarChart;

    #endregion Attributes

    #region Unity Methods
    //Deactivat all game menus at the start of the game
    private void Start()
    {
        measuresMenuActiv.SetActive(false);

        measures2MenuActiv.SetActive(false);

        //Generates a placeholder list of sortet countries for the ranking list
        for (int i = 0; i < countriesSort.Length; i++)
        {
            countriesSort[i] = eventScript.countries[i];
        }
    }
    private void Update()
    {
        //Updates the data of a country shown on screen in real time
        if (country != null)
        {
            countryName.text = country.countryName;
            residents.text = country.startResidents + "";
            infected.text = System.Math.Round(country.infected) + "";
            influenceE.text = "Influence: " + country.influenceE;
            influenceP.text = "Influence: " + country.influenceP;
        }
    }

    #endregion Unity Methods

    #region Methods

    //Activates the first menu on click (on the earth): Continent nenu; if the menu is allready this method deactivats it
    //Path: No ingame menu open -> open the continent menu; Continent menu open -> close the continent menu
    public void OnClickMenuActiv()
    {
        if (measures2MenuActiv.activeSelf)
        {
            measures2MenuActiv.SetActive(false);
        }
        else if(measuresMenuActiv.activeSelf)
        {
            measuresMenuActiv.SetActive(false);
            //Pause the game if necessary and change the time icon to paus. 
            if (mainScript.pause)
            {
                mainScript.SetTimeButtonPlayPauseOnClickTask();
                buttonAnim.ChangeSprite();
            }
        }
        else
        {
            measuresMenuActiv.SetActive(true);
            if (!mainScript.pause)
            {
                mainScript.SetTimeButtonPlayPauseOnClickTask();
                buttonAnim.ChangeSprite();
            }
        }  
    }
    //Activates the second menu on click (on the menu): Country menu; if the menu is allready this method deactivats it
    //Patg: Continent menu is open -> open the country menu; country menu is open -> close the country menu
    public void OnClickMenu2Activ()
    {
        if (measures2MenuActiv.activeSelf)
        {
            measures2MenuActiv.SetActive(false);
        }
        else
        {
            measures2MenuActiv.SetActive(true);
        }
    }
    //Activates the thrid menu on click (on the menu or erath): Continent menu; if the menu is allready activated this method deactivats it
    //Path: No ingame menu open -> open the continent menu; Continent menu open -> close the continent menu
    public void OnClickMenu3Activ(ContinentDisplay continentDisplay)
    {
        if (measures2MenuActiv.activeSelf)
        {
            measures2MenuActiv.SetActive(false);
            ShowContinent(continentDisplay);

        }
        else if (measuresMenuActiv.activeSelf)
        {
            ShowContinent(continentDisplay);
        }
        else
        {
            OnClickMenuActiv();
            ShowContinent(continentDisplay);
        }
    }
    //This method gets the data from the scriptableObject of the corresponding class
    //Deactivats all menu objects and starts showing the data by activating it 
    public void ShowContinent(ContinentDisplay continentDisplay)
    {
        Continent continent = continentDisplay.continent;
        continentName.text = continent.continentName;

        for(int i = 0; i < countryButtons.Length; i++)
        {
            countryButtons[i].gameObject.SetActive(false);
        }

        for(int i = 0; i < continent.countries.Length; i++)
        {
            //This method gets the data from the countryButton pressed and activates the measursButton of the country
            if (continent.countries[i] != null)
            {
                countryButtons[i].gameObject.SetActive(true);
                TextMeshProUGUI buttonText = countryButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                Image buttonImage = countryButtons[i].GetComponent<Image>();
                buttonText.text = continent.countries[i].countryName;
                buttonImage.sprite = continent.countries[i].flag;
                Buttons buttonsCountry = countryButtons[i].GetComponentInChildren<Buttons>();
                buttonsCountry.country = continent.countries[i];
            }
        }
    }
    //This method gets the data from the countryButton pressed and activates the measursButton of the country
    public void ShowCountry(Buttons button)
    {
        country = button.GetComponent<Buttons>().country;
        OnClickMenu2Activ();

        for(int i = 0; i < measursButtons.Length; i++)
        {
            if (!country.measures[i])
            {

                measursCosts[i].text = "" + country.moneyV[i];
                measursButtons[i].image.color = new Color(50,50,50);
            }
            else if (country.measures[i])
            {
                measursCosts[i].text = "" + country.moneyV[i];
                measursButtons[i].image.color = Color.green;
            }
        }   
    }
    //This method checks if a measure is allready in charge or not 
    //After checking the measure gets activated or deactivated 
    public void MeasuresCheck()
    {
        GameObject pressed = EventSystem.current.currentSelectedGameObject;
        Button pressedButton = pressed.GetComponentInChildren<Button>();

        for (int i = 0; i < measursButtons.Length; i++)
        {
            if(pressedButton == measursButtons[i])
            {
                if (!country.measures[i] && mainScript.Money >= country.moneyV[i])
                {
                    mainScript.Money -= country.moneyV[i];
                    country.measures[i] = true;
                    measursButtons[i].image.color = Color.green;
                }
                else if (country.measures[i])
                {
                    country.measures[i] = false;
                    mainScript.Money += country.moneyV[i];
                    measursButtons[i].image.color = new Color(50,50,50);
                }
                else
                {
                    Debug.Log("Du hast zu wenig Gold!");
                }
            }
        }
    }
    //This method pens a generic menu (not continentMenu or countryMenu)
    public void OpenMenu(GameObject menu)
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
            if(Time.timeScale == 0)
            {
                mainScript.SetTimeButtonPlayPauseOnClickTask();
                buttonAnim.ChangeSprite();
            }
        }
        else if (!menu.activeSelf)
        {

            menu.SetActive(true);
            if(Time.timeScale == 1)
            {
                mainScript.SetTimeButtonPlayPauseOnClickTask();
                buttonAnim.ChangeSprite();
            }
        }
    }
    //Opens specificly the rankingMenu
    //Sorts the countries by infected count
    public void OpenRankingMenu()
    {
        Country temp = null;

        for(int i = 0; i < countriesSort.Length; i++)
        {
            for (int a = 0; a < countriesSort.Length -1; a++)
            {
                if(countriesSort[a].infected < countriesSort[a + 1].infected)
                {
                    temp = countriesSort[a + 1];
                    countriesSort[a + 1] = countriesSort[a];
                    countriesSort[a] = temp;
                }
            }
        }

        for (int i = 0; i < rankingButtons.Length; i++)
        {
            TextMeshProUGUI rankingButtonText = rankingButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI rankingButtonCount = infectedCount[i];
            Image rankingButtonImage = rankingButtons[i].GetComponent<Image>();
            Buttons button = rankingButtons[i].GetComponent<Buttons>();
            rankingButtonText.text = countriesSort[i].countryName;
            rankingButtonImage.sprite = countriesSort[i].flag;
            rankingButtonCount.text = "" + Math.Round(countriesSort[i].infected);
            button.country = countriesSort[i];
        }
    }
    //This Method checks if the graph container is allready open, while the player opens a another menu 
    public void GraphCheck()
    {
        if (myBarChart.activeSelf)
        {
            myBarChart.SetActive(false);
        }
    }

    #endregion Methods
}
