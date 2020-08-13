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

    }

    // Update is called once per frame
    void Update()
    {
        if(time.TimeOfDay < 23 && time.TimeOfDay > 24)
        {
            oneTimeEvent = true;
        }
        if(time.TimeOfDay > 23 && time.TimeOfDay < 24 && oneTimeEvent)
        {
            temp = (1 + country.influenceE * country.influenceP) * (country.infected * country.recoveryRateG);
            Debug.Log(temp);
            country.deathCount = country.deathCount + temp;
            country.residents = country.residents - temp;
            country.infected = temp;

            oneTimeEvent = false; 
        }
        if(country.residents <= (country.startResidents/2))
        {
            myMaterial.color = Color.red;
        }
    }
}
