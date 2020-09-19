using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Continent : ScriptableObject
{
    public string continentName;
    public Country[] countries;

    public Vector3 airport;
}
