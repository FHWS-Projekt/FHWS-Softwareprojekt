using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryDisplay : MonoBehaviour
{
    public Country country;
    public Material myMaterial;
    public TimeCycle time;
    public bool oneTimeEvent;
    public double temp;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial.color = Color.green;
        oneTimeEvent = true;
        country.residents = country.startResidents;
        country.deathCount = 0;
        country.influenceE = 10;
        country.influenceP = 0.2;
        country.infected = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (time.CycleEvent())
        {
            Debug.Log("lol");
        }
        CheckMeasures();
        CalculateResidents();
    }
    //Method to calculate the infected for the next cycle;
    public void CalculateResidents()
    {
        if (time.TimeOfDay < 4)
        {
            oneTimeEvent = true;
        }
        if (time.TimeOfDay > 4 && time.TimeOfDay < 5 && oneTimeEvent)
        {
            temp = (1 + country.influenceE * country.influenceP) * (country.infected * country.recoveryRateG);
            country.deathCount = country.deathCount + temp;
            country.residents = country.residents - temp;
            country.infected = temp;

            oneTimeEvent = false;
        }
        if (country.residents <= (country.startResidents / 2))
        {
            myMaterial.color = Color.red;
        }
    }
    //Method to check the activ measures;
    public void CheckMeasures()
    {
        if (country.handWash)
        {
            country.handWashV = 0.01;
        }
        else
        {
            country.handWashV = 0;
        }
        if (country.mouthguard)
        {
            country.mouthguardV = 0.02;
        }
        else
        {
            country.mouthguardV = 0;
        }
        if (country.socialDistancing)
        {
            country.socialDistancingV = 0.02;
        }
        else
        {
            country.socialDistancingV = 0;
        }
        if (country.quarantine)
        {
            country.quarantineV = 2.25;
        }
        else
        {
            country.quarantineV = 0;
        }
        if (country.closeShops)
        {
            country.closeShopsV = 2.25;
        }
        else
        {
            country.closeShopsV = 0;
        }
        if (country.closeRoutes)
        {
            country.closeRoutesV = 1.5;
        }
        else
        {
            country.closeRoutesV = 0;
        }
        if (country.closeSchools)
        {
            country.closeSchoolsV = 1;
        }
        else
        {
            country.closeSchoolsV = 0;
        }
        if (country.closeBorders)
        {
            country.closeBordersV = 0.75;
        }
        else
        {
            country.closeBordersV = 0;
        }
        if (country.closeKitas)
        {
            country.closeKitasV = 0.5;
        }
        else
        {
            country.closeKitasV = 0;
        }
        if (country.homeOffice)
        {
            country.homeOfficeV = 0.5;
        }
        else
        {
            country.homeOfficeV = 0;
        }
        country.influenceP = 0.2 - country.handWashV - country.mouthguardV - country.socialDistancingV;
        country.influenceE = 10 - country.quarantineV - country.closeShopsV - country.closeRoutesV - country.closeSchoolsV - country.closeBordersV - country.closeKitasV - country.homeOfficeV;

    }

}
