using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettingResert : MonoBehaviour
{

    public PlayerSettings playerSettings;
    void Start()
    {
        playerSettings.playerName = "President";
        playerSettings.sound = true;
        playerSettings.difficulty = 1;
    }


}
