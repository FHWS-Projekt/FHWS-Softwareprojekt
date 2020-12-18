using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {
    // Class that manages the control of the camera around a target

    #region Attributes
    protected Camera mainCamera;
    [SerializeField] protected GameObject target;

    protected Vector3 position;
    protected static double timer;
    #endregion Attributes

    #region Getter and Setter
    public Camera MainCamera {
        set { mainCamera = value; }
        get { return mainCamera; }
    }
    public GameObject Target {
        set { target = value; }
        get { return target; }
    }

    public Vector3 Position {
        set { position = value; }
        get { return position; }
    }
    public static double Timer {
        set { timer = value; }
        get { return timer; }
    }
    #endregion Getter and Setter

    #region Unity Methods
    // Start is called before the first frame update
    void Start() {
        MainCamera = Camera.main;

        Position = new Vector3();
        Timer = 0;
    }

    // Update is called once per frame
    void Update() {
        NewPosition();
        if (Timer > 0) {
            Timer -= Time.unscaledDeltaTime;
        }
    }
    #endregion Unity Methods

    public void NewPosition() {

        if (Input.GetMouseButtonDown(0)) {
            Position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        } else if (Input.GetMouseButton(0)) {
            Vector3 newPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = Position - newPosition;
            Position = newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            // limits the angle between camera and target
            if (GetHorizonAngle(MainCamera.transform.forward) <= 45 && rotationAroundXAxis < 0) {
                rotationAroundXAxis = 0;
            } else if (GetHorizonAngle(MainCamera.transform.forward) >= 135 && rotationAroundXAxis > 0) {
                rotationAroundXAxis = 0;
            }

            MainCamera.transform.Rotate(Vector3.right, rotationAroundXAxis);
            MainCamera.transform.Rotate(Vector3.up, rotationAroundYAxis, Space.World); // vertical movement
            
            MainCamera.transform.position = Target.transform.position;  // teleports the camera to the origin of the target
            MainCamera.transform.Translate(new Vector3(0, 0, -6));      // moves the camera x units back
            ResetTimer();
        }

        // Camera Zoom into Earth
        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * -16;
            if (fov < 40) {
                fov = 40;
            } else if (fov > 80) {
                fov = 80;
            } else {
                MainCamera.fieldOfView = fov;
            }
            ResetTimer();
        }
    }

    // returns the Angle between a Vector and the HorizonPlane
    public double GetHorizonAngle(Vector3 vector) {
        return Math.Abs(Vector3.SignedAngle(Vector3.up, vector, Vector3.forward));
    }

    // resets the Timer of the Camera to x seconds
    public void ResetTimer() {
        Timer = 4;
    }
}
