using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using UnityEngine;

public class MyDateTime {

    #region Attributes
    public static MyDateTimeData myDateTimeData;
    protected static readonly string myDatabase = Path.Combine(Application.streamingAssetsPath, "MyDatabase.json");
    protected double hour;
    protected double day;

    // List of all Tasks that should be called every 24 hours
    protected List<Action> dayTasks = new List<Action>();
    #endregion Attributes

    #region Getter and Setter
    public double Hour {
        get { return hour; }
        set { hour = value; }
    }
    public double Day {
        get { return day; }
        set { day = value; }
    }
    public List<Action> DayTasks {
        get { return dayTasks; }
        set { dayTasks = value; }
    }
    #endregion Getter and Setter

    #region Constructors
    public MyDateTime() {
        Hour = 0;
        Day = 1;
        myDateTimeData = new JsonParser().ReadFromJsonOS<MyDateTimeData>(myDatabase);
    }
    public MyDateTime(double hour, double day) {
        Hour = hour;
        Day = day;
        myDateTimeData = new JsonParser().ReadFromJsonOS<MyDateTimeData>(myDatabase);
    }
    #endregion Constructors

    #region DateTime
    public void CalculateDateTime() {
        if (Hour >= 24) {
            Hour = Hour % 24;
            Day++;
            DayTasksManager();
        }
    }
    public void DayTasksManager() {
        foreach (Action action in dayTasks) {
            action.Invoke();
        }
    }
    #endregion DateTime

    public string toString() {
        CalculateDateTime();
        return day + " " + myDateTimeData.day + "\n" + (int)Hour + " " + myDateTimeData.hour;
    }

    public class MyDateTimeData {
        public string day;
        public string hour ;
    }
}
