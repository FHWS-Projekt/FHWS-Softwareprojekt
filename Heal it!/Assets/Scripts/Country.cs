using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Country : ScriptableObject
{
    public string countryName;
    public double startResidents;
    public double residents;
    public double infected;
    public double deathCount;

    public double recoveryRateG;
    public double influenceE;
    public double influenceP;

    public string info;

    public bool[] measures;
    public double[] measuresV;
    public double[] moneyV;

    public Sprite flag;
}
