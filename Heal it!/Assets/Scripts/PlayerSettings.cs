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
}
