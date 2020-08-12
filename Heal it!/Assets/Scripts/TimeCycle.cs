using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    [SerializeField, Range(0, 24)] public float TimeOfDay;

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 24;
        }
    }
}
