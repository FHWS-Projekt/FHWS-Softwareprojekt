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
    public TextMeshProUGUI measuresText;
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
        if(measuresMenuActiv.activeSelf)
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
            }
        }
    }
    public void ShowCountry(CountryDisplay countryDisplay)
    {
        Country country = countryDisplay.country;
        countryName.text = country.countryName;


    }
    #endregion Methods
}
