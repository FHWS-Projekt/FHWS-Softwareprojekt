using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndingControler : MonoBehaviour
{
    public TextMeshProUGUI win;
    public TextMeshProUGUI lose;
    public PlayerSettings playerSettings;

    public TextMeshProUGUI playerName;
    public TextMeshProUGUI countryName;
    public TextMeshProUGUI infected;
    public TextMeshProUGUI days;
    public Image flag;

    void Start()
    {
        if (playerSettings.gameEnding)
        {
            win.gameObject.SetActive(true);
        }
        else
        {
            lose.gameObject.SetActive(true);
        }
        playerName.text = "Spieler:\n" + playerSettings.playerName;
        countryName.text = "Land:\n" + playerSettings.endingCountry;
        infected.text = "Infizierte:\n" + playerSettings.endingCount.ToString();
        days.text = "Tag:\n" + playerSettings.endingDay.ToString();
        flag.sprite = playerSettings.endingFlag;
    }
    public void restart()
    {
        Application.LoadLevel(0);
    }


}
