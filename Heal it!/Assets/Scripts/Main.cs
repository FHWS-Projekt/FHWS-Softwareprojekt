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
            MyDateTime.Day = 0;
            MyDateTime.Hour = 0;
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
        RotateEarth();
        MoneyDisplay.text = money.ToString() + " $";
        ControlCamera();
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
    }
    #endregion Time

    public void ControlCamera() {
        // Camera Rotate around Earth
        if (Input.GetMouseButton(0)) {
            Camera.main.transform.RotateAround(Earth.transform.position, transform.up, Input.GetAxis("Mouse X") * 2);
            Camera.main.transform.RotateAround(Earth.transform.position, transform.right, Input.GetAxis("Mouse Y") * -2);
        }

        // Camera Zoom into Earth
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -16;
        if (fov < 40) {
            fov = 40;
        }else if (fov > 80) {
            fov = 80;
        } else {
            Camera.main.fieldOfView = fov;
        }
    }

    public void RotateEarth() {
        //Earth.transform.Rotate(Vector3.up, 10 * Time.deltaTime, Space.World);
        Earth.transform.rotation = Quaternion.AngleAxis((float)(MyDateTime.Hour * 15), Vector3.up);
    }

    public void AddMoney() {
        Money += 1000;
    }
}
