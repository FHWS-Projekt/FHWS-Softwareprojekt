using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingControler : MonoBehaviour
{
    public TextMeshProUGUI win;
    public TextMeshProUGUI lose;
    public PlayerSettings playerSettings;

    void Start()
    {
        //If the player won the game 
        if (playerSettings.gameEnding)
        {
            win.gameObject.SetActive(true);
        }
        //If the player lost the game 
        else
        {
            lose.gameObject.SetActive(true);
        }
    }
}
