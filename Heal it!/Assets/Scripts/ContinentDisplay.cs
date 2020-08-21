using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;

public class ContinentDisplay : MonoBehaviour
{
    public Continent continent;
    public Material Material; 
    public TimeCycle timeCycle;
    public bool help;


    public void Update()
    {
        if(timeCycle.day % 5 != 0)
        {
            help = true;
        }
        if (timeCycle.day % 5 == 0 && help == true)
        {
            help = false;
            RandomDistribution();
        }
    }
    //Distribute der virus inside the Continent 
    public void RandomDistribution()
    {

        Country sender = null;
        Country reciver = null;
        for(int i = 0; i < continent.countries.Length; i++)
        {
            if(continent.countries[i].infected != 0)
            {
                sender = continent.countries[i];
            }
        }
        for(int i = 0; i < continent.countries.Length; i++)
        {
            if(continent.countries[i].infected == 0)
            {
                reciver = continent.countries[i];
            }
        }
        if(reciver != null && sender != null)
        {
            reciver.infected += 1;
            sender.infected -= 1;
            Debug.Log(sender.name + " --- > " + reciver.name);
        }
    }


}
