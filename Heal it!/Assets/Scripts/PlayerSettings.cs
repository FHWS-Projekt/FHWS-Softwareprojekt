using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class PlayerSettings : ScriptableObject
{
    public int difficulty;
    public string playerName;
    public bool sound;

    public bool oneTimeEvent;
    public bool gameEnding;

    public string endingCountry;
    public int endingDay;
    public Sprite endingFlag;
    public int endingCount;
}
