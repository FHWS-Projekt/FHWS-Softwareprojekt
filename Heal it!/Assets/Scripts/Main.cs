using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    #region Attributes
    [SerializeField] protected GameObject earth;

    // Time
    protected MyDateTime myDateTime;
    //protected float timestamp;
    [SerializeField] protected TextMeshProUGUI timeDisplay;
    [SerializeField] protected Button[] timeButtons = new Button[3];
    #endregion Attributes

    #region Getter and Setter
    public GameObject Earth
    {
        get { return earth; }
        set { earth = value; }
    }

    // Time
    public MyDateTime MyDateTime {
        get { return myDateTime; }
        set { myDateTime = value; }
    }
    /*public float Timestamp
    {
        get { return timestamp; }
        set { timestamp = value; }
    }*/
    public TextMeshProUGUI TimeDisplay
    {
        get { return timeDisplay; }
        set { timeDisplay = value; }
    }
    public Button[] TimeButtons
    {
        get { return timeButtons; }
        set { timeButtons = value; }
    }
    #endregion Getter and Setter




    // Start is called before the first frame update
    void Start()
    {
        // Adds OnClick Listener to Buttons
        SetTimeButtonsOnClick();

        // Get Unix Timestamp in Seconds if it is not already set
        if(MyDateTime == null) {
            MyDateTime = new MyDateTime();
            MyDateTime.Year = System.DateTime.Now.Year;
            MyDateTime.Month = System.DateTime.Now.Month;
            MyDateTime.Day = System.DateTime.Now.Day;
            MyDateTime.Hour = System.DateTime.Now.Hour;
        }


        /*if (Timestamp == 0)
        {
            Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimestamp();
        RotateEarth();
    }

    #region Time
    // Methods for managing Time
    public void UpdateTimestamp()
    {
        //Timestamp += Time.deltaTime;
        //TimeDisplay.text = Time.deltaTime.ToString();
        MyDateTime.Hour += Time.deltaTime;
        TimeDisplay.text = MyDateTime.toString();
    }
    public void SetTimeButtonsOnClick()
    {
        foreach (Button button in TimeButtons)
        {
            button.onClick.AddListener(() => SetTimeButtonsOnClickTask(button));
        }
    }
    public void SetTimeButtonsOnClickTask(Button button)
    {
        int indexOfButton = System.Array.IndexOf(TimeButtons, button);
        Time.timeScale = (float)Math.Pow(indexOfButton, 6);
    }
    #endregion Time


    public void RotateEarth()
    {
        //Earth.transform.Rotate(Vector3.up, 10 * Time.deltaTime, Space.World);
        Earth.transform.rotation = Quaternion.AngleAxis((float)(MyDateTime.Hour * 15), Vector3.up);
    }
}
