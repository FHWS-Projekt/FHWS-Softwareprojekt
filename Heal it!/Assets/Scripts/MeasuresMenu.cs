using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeasuresMenu : MonoBehaviour
{
    #region Attributes

    public GameObject measuresMenuActiv;



    public Main mainScript;
    public Button pauseButton;
    public Button startButton;

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

    #endregion Methods
}
