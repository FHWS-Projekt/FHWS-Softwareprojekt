using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    [SerializeField, Range(0, 5)] public float TimeOfDay;

    public TextMeshProUGUI timeValue;
    public TextMeshProUGUI dateValue;
    public int day;
    public bool oneTimeEvent;

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 5;

            timeValue.text = TimeOfDay.ToString();
            if(TimeOfDay < 4)
            {
                oneTimeEvent = true;
            }
            if(TimeOfDay > 4 && TimeOfDay < 5 && oneTimeEvent)
            {
                day++;
                oneTimeEvent = false;
            }
            dateValue.text = day.ToString();
        }
    }
}
