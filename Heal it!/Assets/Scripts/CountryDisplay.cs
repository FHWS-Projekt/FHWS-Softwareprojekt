using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryDisplay : MonoBehaviour
{   
    public Country country;
    public Material myMaterial;
    public TimeCycle time;
    public bool help;
    public double temp;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial.color = Color.green;
        help = true;
        country.residents = country.startResidents;
    }

    // Update is called once per frame
    void Update()
    {
        if(time.TimeOfDay < 23 && time.TimeOfDay >= 24)
        {
            help = true;
        }
        if(time.TimeOfDay >= 23 && help)
        {
            temp = country.residents / 2;
            country.residents = country.residents - temp;
            country.deathCount = country.deathCount + temp;

            help = false; 
        }
        if(country.residents <= country.gameOver)
        {
            myMaterial.color = Color.red;
        }
    }
}
