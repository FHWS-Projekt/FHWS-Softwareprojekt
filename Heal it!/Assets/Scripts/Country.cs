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

    public bool handWash;
    public double handWashV;
    public bool mouthguard;
    public double mouthguardV;
    public bool socialDistancing;
    public double socialDistancingV;

    public bool quarantine;
    public double quarantineV;
    public bool closeShops;
    public double closeShopsV;
    public bool closeRoutes;
    public double closeRoutesV;
    public bool closeSchools;
    public double closeSchoolsV;
    public bool closeBorders;
    public double closeBordersV;
    public bool closeKitas;
    public double closeKitasV;
    public bool homeOffice;
    public double homeOfficeV;

}
