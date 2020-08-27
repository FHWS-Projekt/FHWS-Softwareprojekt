using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    #region Singleton
    public static Main Instance { get; private set; }
    #endregion

    #region Attributes
    // Earth
    [SerializeField] protected GameObject earth;

    // DateTime
    protected MyDateTime myDateTime;
    [SerializeField] protected TextMeshProUGUI timeDisplay;
    [SerializeField] protected Button[] timeButtons = new Button[3];

    // Money
    protected double money;
    [SerializeField] protected TextMeshProUGUI moneyDisplay;
    #endregion Attributes

    #region Getter and Setter
    // Earth
    public GameObject Earth {
        get { return earth; }
        set { earth = value; }
    }

    // Time
    public MyDateTime MyDateTime {
        get { return myDateTime; }
        set { myDateTime = value; }
    }
    public TextMeshProUGUI TimeDisplay {
        get { return timeDisplay; }
        set { timeDisplay = value; }
    }
    public Button[] TimeButtons {
        get { return timeButtons; }
        set { timeButtons = value; }
    }
    // Money
    public double Money {
        get { return money; }
        set { money = value; }
    }
    public TextMeshProUGUI MoneyDisplay {
        get { return moneyDisplay; }
        set { moneyDisplay = value; }
    }
    #endregion Getter and Setter

    #region Unity Methods
    // Awake is called when the script instance is being loaded
    private void Awake() {
        if (Instance == null) {
            Instance = this;

            // Initilize MyDateTime
            MyDateTime = new MyDateTime();
        }
    }

    // Start is called before the first frame update
    void Start() {
        // Adds OnClick Listener to Buttons
        SetTimeButtonsOnClick();
        MyDateTime.DayTasks.Add(() => AddMoney());
    }

    // Update is called once per frame
    void Update() {
        UpdateTimestamp();
        MoneyDisplay.text = money.ToString() + " $";

        if (MyCamera.Timer <= 0) {
            RotateEarth();
        }
    }
    #endregion Unity Methods

    #region Time
    // Methods for managing Time
    public void UpdateTimestamp() {
        MyDateTime.Hour += Time.deltaTime;
        TimeDisplay.text = MyDateTime.toString();
    }
    public void SetTimeButtonsOnClick() {
        foreach (Button button in TimeButtons) {
            button.onClick.AddListener(() => SetTimeButtonsOnClickTask(button));
        }
    }
    public void SetTimeButtonsOnClickTask(Button button) {
        int indexOfButton = System.Array.IndexOf(TimeButtons, button);
        Time.timeScale = (float)Math.Pow(indexOfButton, 6);
        MyCamera.Timer = 0;
    }
    #endregion Time

    public void RotateEarth() {
        Earth.transform.Rotate(Vector3.up, Time.deltaTime * 15, Space.World);
        //Earth.transform.rotation = Quaternion.AngleAxis((float)(MyDateTime.Hour * 15), Vector3.up);
    }

    public void AddMoney() {
        Money += 1000;
    }
}
