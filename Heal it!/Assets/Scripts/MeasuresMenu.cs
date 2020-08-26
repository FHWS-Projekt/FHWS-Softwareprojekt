using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeasuresMenu : MonoBehaviour
{
    #region Attributes

    public GameObject measuresMenuActiv;

    public TextMeshProUGUI continentName;
    public TextMeshProUGUI residents;
    public TextMeshProUGUI infected;
    public TextMeshProUGUI influenceE;
    public TextMeshProUGUI influenceP;

    public Main mainScript;
    public Button pauseButton;
    public Button startButton;

    public Button[] countryButtons;

    #endregion Attributes

    #region Unity Methods

    private void Start()
    {
        measuresMenuActiv.SetActive(false);
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
    public void ShowCountry()
    {

    }
    #endregion Methods
}
