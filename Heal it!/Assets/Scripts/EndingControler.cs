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
        if (playerSettings.gameEnding)
        {
            win.gameObject.SetActive(true);
        }
        else
        {
            lose.gameObject.SetActive(true);
        }
    }


}
