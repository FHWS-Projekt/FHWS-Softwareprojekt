using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MyDateTime {

    #region Attributes
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
        Day = 0;
    }
    public MyDateTime(double hour, double day) {
        Hour = hour;
        Day = day;
    }
    #endregion Constructors

    #region DateTime
    public void CalculateDateTime() {
        if (Hour >= 24) {
            Hour = Hour % 24;
            Day += (int)(Day / 24 + 1);
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
        return day + " Tag\n" + (int)Hour + " Uhr";
    }
}
