using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Country[] countries;

    public void RandomStart()
    {
        int rdm = (int)Random.Range(0.0f, 24.0f);
        countries[rdm].infected = 1;
        Debug.Log("Start country: " + countries[rdm].countryName);
    }
}
