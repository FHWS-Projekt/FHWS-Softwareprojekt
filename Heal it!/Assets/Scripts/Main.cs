using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    #region Singleton
    public static Main Instance { get; private set; }
    #endregion

    #region Attributes
    // Earth
    [SerializeField] protected GameObject earth;

    // DateTime
    protected MyDateTime myDateTime;
    [SerializeField] protected TextMeshProUGUI timeDisplay;
    [SerializeField] protected Button[] timeButtons = new Button[2];
    public bool pause;

    // Money
    protected double money;
    [SerializeField] protected TextMeshProUGUI moneyDisplay;

    // Difficulty 
    [SerializeField] protected PlayerSettings playerSettings;
    #endregion Attributes

    #region Getter and Setter
    // Earth
    public GameObject Earth
    {
        get { return earth; }
        set { earth = value; }
    }

    // Time
    public MyDateTime MyDateTime
    {
        get { return myDateTime; }
        set { myDateTime = value; }
    }
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
    // Money
    public double Money
    {
        get { return money; }
        set { money = value; }
    }
    public TextMeshProUGUI MoneyDisplay
    {
        get { return moneyDisplay; }
        set { moneyDisplay = value; }
    }
    // Difficulty
    public PlayerSettings PlayerSettings
    {
        get { return playerSettings; }
        set { playerSettings = value; }
    }
    #endregion Getter and Setter

    #region Unity Methods
    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

            // Initilize MyDateTime
            MyDateTime = new MyDateTime();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        // Adds OnClick Listener to Buttons
        SetTimeButtonsOnClick();
        MyDateTime.DayTasks.Add(() => AddMoney());
        AddMoney();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimestamp();
        MoneyDisplay.text = money.ToString() + " Mio.";

        if(MyCamera.Timer <= 0)
        {
            RotateEarth();
        }
    }
    #endregion Unity Methods

    #region Time
    // Methods for managing Time
    public void UpdateTimestamp()
    {
        MyDateTime.Hour += Time.deltaTime;
        TimeDisplay.text = MyDateTime.toString();
    }
    public void SetTimeButtonsOnClick()
    {
        TimeButtons[0].onClick.AddListener(() => SetTimeButtonPlayPauseOnClickTask());
        TimeButtons[1].onClick.AddListener(() => SetTimeButtonSkipOnClickTask());
    }
    public void SetTimeButtonPlayPauseOnClickTask()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pause = false;
        } else
        {
            Time.timeScale = 0;
            pause = true;
        }
        MyCamera.Timer = 0;
    }
    public void SetTimeButtonSkipOnClickTask()
    {
        MyDateTime.Hour = 24;
        MyCamera.Timer = 0;
    }
    #endregion Time

    public void RotateEarth()
    {
        Earth.transform.Rotate(Vector3.up, Time.deltaTime * 15, Space.World);
        //Earth.transform.rotation = Quaternion.AngleAxis((float)(MyDateTime.Hour * 15), Vector3.up);
    }

    public void AddMoney()
    {

        if(PlayerSettings.difficulty == 0)
        {
            if(MyDateTime.Day < 4)
            {
                Money += 1;
            } else if(MyDateTime.Day < 7)
            {
                Money += 3;
            } else if(MyDateTime.Day < 10)
            {
                Money += 5;
            } else if(MyDateTime.Day < 12)
            {
                Money += 8;
            } else if(MyDateTime.Day < 14)
            {
                Money += 9;
            } else if(MyDateTime.Day < 16)
            {
                Money += 15;
            } else if(MyDateTime.Day < 19)
            {
                Money += 21;
            } else if(MyDateTime.Day < 22)
            {
                Money += 22;
            } else if(MyDateTime.Day < 25)
            {
                Money += 24;
            } else if(MyDateTime.Day < 27)
            {
                Money += 28;
            } else if(MyDateTime.Day < 30)
            {
                Money += 27;
            } else if(MyDateTime.Day < 33)
            {
                Money += 25;
            } else if(MyDateTime.Day < 36)
            {
                Money += 23;
            } else if(MyDateTime.Day < 38)
            {
                Money += 20;
            } else if(MyDateTime.Day < 40)
            {
                Money += 19;
            } else if(MyDateTime.Day < 42)
            {
                Money += 13;
            } else if(MyDateTime.Day < 45)
            {
                Money += 7;
            } else if(MyDateTime.Day < 48)
            {
                Money += 6;
            } else
            {
                Money += 4;
            }
        } else if(PlayerSettings.difficulty == 1)
        {
            if(MyDateTime.Day < 4)
            {
                Money += 1;
            } else if(MyDateTime.Day < 7)
            {
                Money += 3;
            } else if(MyDateTime.Day < 10)
            {
                Money += 5;
            } else if(MyDateTime.Day < 12)
            {
                Money += 8;
            } else if(MyDateTime.Day < 14)
            {
                Money += 9;
            } else if(MyDateTime.Day < 16)
            {
                Money += 15;
            } else if(MyDateTime.Day < 19)
            {
                Money += 21;
            } else if(MyDateTime.Day < 22)
            {
                Money += 22;
            } else if(MyDateTime.Day < 25)
            {
                Money += 24;
            } else if(MyDateTime.Day < 27)
            {
                Money += 28;
            } else if(MyDateTime.Day < 30)
            {
                Money += 27;
            } else if(MyDateTime.Day < 33)
            {
                Money += 25;
            } else if(MyDateTime.Day < 36)
            {
                Money += 23;
            } else if(MyDateTime.Day < 38)
            {
                Money += 20;
            } else if(MyDateTime.Day < 40)
            {
                Money += 19;
            } else if(MyDateTime.Day < 42)
            {
                Money += 13;
            } else if(MyDateTime.Day < 45)
            {
                Money += 7;
            } else if(MyDateTime.Day < 48)
            {
                Money += 6;
            } else
            {
                Money += 4;
            }
        } else if(PlayerSettings.difficulty == 2)
        {
            if(MyDateTime.Day < 4)
            {
                Money += 1;
            } else if(MyDateTime.Day < 7)
            {
                Money += 3;
            } else if(MyDateTime.Day < 10)
            {
                Money += 5;
            } else if(MyDateTime.Day < 12)
            {
                Money += 8;
            } else if(MyDateTime.Day < 14)
            {
                Money += 9;
            } else if(MyDateTime.Day < 16)
            {
                Money += 15;
            } else if(MyDateTime.Day < 19)
            {
                Money += 21;
            } else if(MyDateTime.Day < 22)
            {
                Money += 22;
            } else if(MyDateTime.Day < 25)
            {
                Money += 24;
            } else if(MyDateTime.Day < 27)
            {
                Money += 28;
            } else if(MyDateTime.Day < 30)
            {
                Money += 27;
            } else if(MyDateTime.Day < 33)
            {
                Money += 25;
            } else if(MyDateTime.Day < 36)
            {
                Money += 23;
            } else if(MyDateTime.Day < 38)
            {
                Money += 20;
            } else if(MyDateTime.Day < 40)
            {
                Money += 19;
            } else if(MyDateTime.Day < 42)
            {
                Money += 13;
            } else if(MyDateTime.Day < 45)
            {
                Money += 7;
            } else if(MyDateTime.Day < 48)
            {
                Money += 6;
            } else
            {
                Money += 4;
            }
        }
    }
}
