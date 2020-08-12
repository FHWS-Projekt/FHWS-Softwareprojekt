using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Country : ScriptableObject
{
    public string countryName;
    public double startResidents;
    public double residents;
    public double deathCount;
    public double gameOver;
}
