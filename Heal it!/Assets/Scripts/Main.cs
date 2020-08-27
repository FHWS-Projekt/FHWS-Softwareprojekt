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
    protected double earthRotationTimer;
    protected Vector3 previousPosition = new Vector3();

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
    public double EarthRotationTimer {
        get { return earthRotationTimer; }
        set { earthRotationTimer = value; }
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
        MoneyDisplay.text = money.ToString() + " $";
        ControlCamera();
        if (EarthRotationTimer > 0) {
            EarthRotationTimer -= Time.unscaledDeltaTime;
        }else {
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
        EarthRotationTimer = 0;
    }
    #endregion Time

    // returns the Angle between a Vector and the HorizonPlane
    public double GetHorizonAngle(Vector3 vector) {
        return Math.Abs(Vector3.SignedAngle(Vector3.up, vector, Vector3.forward));
    }

    public void ControlCamera() {

        Transform cameraTransform = Camera.main.transform;
        
        if (Input.GetMouseButtonDown(0)) {
            previousPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        } else if (Input.GetMouseButton(0)) {
            Vector3 newPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = previousPosition - newPosition;
            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            if (GetHorizonAngle(cameraTransform.forward) <= 45 && rotationAroundXAxis < 0) {
                rotationAroundXAxis = 0;
            }else if (GetHorizonAngle(cameraTransform.forward) >= 135 && rotationAroundXAxis > 0) {
                rotationAroundXAxis = 0;
            }

            Camera.main.transform.Rotate(Vector3.right, rotationAroundXAxis);
            Camera.main.transform.Rotate(Vector3.up, rotationAroundYAxis, Space.World); // vertical movement

            Camera.main.transform.position = Earth.transform.position;
            Camera.main.transform.Translate(new Vector3(0, 0, -6));



            previousPosition = newPosition;

            EarthRotationTimer = 5;
        }
        


        /*
        if (Input.GetMouseButton(0)) {
            Camera.main.transform.RotateAround(Earth.transform.position, Camera.main.transform.up, Input.GetAxis("Mouse X") * 2);
            Camera.main.transform.RotateAround(Earth.transform.position, Camera.main.transform.right, Input.GetAxis("Mouse Y") * -2);

        }
        */

        // Camera Zoom into Earth
        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * -16;
            if (fov < 40) {
                fov = 40;
            } else if (fov > 80) {
                fov = 80;
            } else {
                Camera.main.fieldOfView = fov;
            }
            EarthRotationTimer = 5;
        }
    }

    public void RotateEarth() {
        Earth.transform.Rotate(Vector3.up, Time.deltaTime * 15, Space.World);
        //Earth.transform.rotation = Quaternion.AngleAxis((float)(MyDateTime.Hour * 15), Vector3.up);
    }

    public void AddMoney() {
        Money += 1000;
    }
}
