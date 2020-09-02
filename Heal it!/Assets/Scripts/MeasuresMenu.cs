using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeasuresMenu : MonoBehaviour
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

    public Main mainScript;
    public Button pauseButton;
    public Button startButton;

    public Button[] countryButtons;
    public Button[] measursButtons;

    #endregion Attributes

    #region Unity Methods

    private void Start()
    {
        measuresMenuActiv.SetActive(false);

        measures2MenuActiv.SetActive(false);
    }

    #endregion Unity Methods

    #region Methods

    public void OnClickMenuActiv()
    {
        if (measures2MenuActiv.activeSelf)
        {
            measures2MenuActiv.SetActive(false);
        }
        else if(measuresMenuActiv.activeSelf)
        {
            measuresMenuActiv.SetActive(false);
            mainScript.SetTimeButtonsOnClickTask(startButton);
        }
        else
        {
            measuresMenuActiv.SetActive(true);
            mainScript.SetTimeButtonsOnClickTask(pauseButton);
        }  
    }
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
    public CountryDisplay OnClickCountryButton(Button button)
    {

        CountryDisplay countryDisplay = null;

        return countryDisplay;

    }
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
            if(continent.countries[i] != null)
            {
                countryButtons[i].gameObject.SetActive(true);
                TextMeshProUGUI buttonText = countryButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = continent.countries[i].countryName;
                Buttons buttonsCountry = countryButtons[i].GetComponentInChildren<Buttons>();
                buttonsCountry.country = continent.countries[i];
            }
        }
    }
    public void ShowCountry(Buttons button)
    {
        Country country = button.GetComponent<Buttons>().country;
        OnClickMenu2Activ();

        countryName.text = country.countryName;
        residents.text = "Residents: " + country.residents;
        infected.text = "Infected: " + country.infected;
        influenceE.text = "Influence: " + country.influenceE;
        influenceP.text = "Influence: " + country.influenceP;

        for (int i = 0; i < measursButtons.Length; i++)
        {
            Buttons buttonsCountry = measursButtons[i].GetComponentInChildren<Buttons>();
            buttonsCountry.country = country;
            //wip
            switch (i)
            {
                case 0:
                    if (!buttonsCountry.country.handWash)
                    {
                        measursButtons[0].image.color = Color.red;
                        break;
                    }
                    else
                    {
                        measursButtons[0].image.color = Color.green;
                        break;
                    }
                case 1:
                    if (!buttonsCountry.country.mouthguard)
                    {
                        measursButtons[1].image.color = Color.red;
                        break;
                    }
                    else
                    {
                        measursButtons[1].image.color = Color.green;
                        break;
                    }
                case 2:
                    if (!buttonsCountry.country.socialDistancing)
                    {
                        measursButtons[2].image.color = Color.red;
                        break;
                    }
                    else
                    {
                        measursButtons[2].image.color = Color.green;
                        break;
                    }
                case 3:
                    if (!buttonsCountry.country.quarantine)
                    {
                        measursButtons[3].image.color = Color.red;
                        break;
                    }
                    else
                    {
                        measursButtons[3].image.color = Color.green;
                        break;
                    }
                case 4:
                    if (!buttonsCountry.country.closeShops)
                    {
                        measursButtons[4].image.color = Color.red;
                        break;
                    }
                    else
                    {
                        measursButtons[4].image.color = Color.green;
                        break;
                    }
                case 5:
                    if (!buttonsCountry.country.closeRoutes)
                    {
                        measursButtons[5].image.color = Color.red;
                        break;
                    }
                    else
                    {
                        measursButtons[5].image.color = Color.green;
                        break;
                    }
                case 6:
                    if (!buttonsCountry.country.closeSchools)
                    {
                        measursButtons[6].image.color = Color.red;
                        break;
                    }
                    else
                    {
                        measursButtons[6].image.color = Color.green;
                        break;
                    }
                case 7:
                    if (!buttonsCountry.country.closeBorders)
                    {
                        measursButtons[7].image.color = Color.red;
                        break;
                    }
                    else
                    {
                        measursButtons[7].image.color = Color.green;
                        break;
                    }
                case 8:
                    if (!buttonsCountry.country.closeKitas)
                    {
                        measursButtons[8].image.color = Color.red;
                        break;
                    }
                    else
                    {
                        measursButtons[8].image.color = Color.green;
                        break;
                    }
                case 9:
                    if (!buttonsCountry.country.closeKitas)
                    {
                        measursButtons[9].image.color = Color.red;
                        break;
                    }
                    else
                    {
                        measursButtons[9].image.color = Color.green;
                        break;
                    }
            }

        }
    }
    public void MeasuresCheck(Buttons button)
    {
        Country country = button.GetComponent<Buttons>().country;
        int measureID = button.buttonName;
        
        //wip
        switch (measureID)
        {
            case 0:
                if (country.handWash)
                {
                    measursButtons[0].image.color = Color.red;
                    country.handWash = false;
                    break;
                }
                else
                {
                    measursButtons[0].image.color = Color.green;
                    country.handWash = true;
                    break;
                }
            case 1:
                if (country.mouthguard)
                {
                    measursButtons[1].image.color = Color.red;
                    country.mouthguard = false;
                    break;
                }
                else
                {
                    measursButtons[1].image.color = Color.green;
                    country.mouthguard = true;
                    break;
                }
            case 2:
                if (country.socialDistancing)
                {
                    measursButtons[2].image.color = Color.green;
                    country.socialDistancing = false;
                    break;
                }
                else
                {
                    measursButtons[2].image.color = Color.green;
                    country.socialDistancing = true;
                    break;
                }
            case 3:
                if (country.quarantine)
                {
                    measursButtons[3].image.color = Color.red;
                    country.quarantine = false;
                    break;
                }
                else
                {
                    measursButtons[3].image.color = Color.green;
                    country.quarantine = true;
                    break;
                }
            case 4:
                if (country.closeShops)
                {
                    measursButtons[4].image.color = Color.red;
                    country.closeShops = false;
                    break;
                }
                else
                {
                    measursButtons[4].image.color = Color.green;
                    country.closeShops = true;
                    break;
                }
            case 5:
                if (country.closeRoutes)
                {
                    measursButtons[5].image.color = Color.red;
                    country.closeRoutes = false;
                    break;
                }
                else
                {
                    measursButtons[5].image.color = Color.green;
                    country.closeRoutes = true;
                    break;
                }
            case 6:
                if (country.closeSchools)
                {
                    measursButtons[6].image.color = Color.red;
                    country.closeSchools = false;
                    break;
                }
                else
                {
                    measursButtons[6].image.color = Color.green;
                    country.closeSchools = true;
                    break;
                }
            case 7:
                if (country.closeBorders)
                {
                    measursButtons[7].image.color = Color.red;
                    country.closeBorders = false;
                    break;
                }
                else
                {
                    measursButtons[7].image.color = Color.green;
                    country.closeBorders = true;
                    break;
                }
            case 8:
                if (country.closeKitas)
                {
                    measursButtons[8].image.color = Color.red;
                    country.closeKitas = false;
                    break;
                }
                else
                {
                    measursButtons[8].image.color = Color.green;
                    country.closeKitas = true;
                    break;
                }
            case 9:
                if (country.closeKitas)
                {
                    measursButtons[9].image.color = Color.red;
                    country.homeOffice = false;
                    break;
                }
                else
                {
                    measursButtons[9].image.color = Color.green;
                    country.homeOffice = true;
                    break;
                }
        }

        residents.text = "Residents: " + country.residents;
        infected.text = "Infected: " + country.infected;
        influenceE.text = "Influence: " + country.influenceE;
        influenceP.text = "Influence: " + country.influenceP;
    }


    #endregion Methods
}
