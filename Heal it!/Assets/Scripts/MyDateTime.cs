using System;
using System.Collections;
using System.Collections.Generic;

public class MyDateTime {

    #region Attributes
    private double hour;
    private double day;
    private double month;
    private double year;

    public List<Action> dayTasks = new List<Action>();
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
    public double Month {
        get { return month; }
        set { month = value; }
    }
    public double Year {
        get { return year; }
        set { year = value; }
    }
    public List<Action> DayTasks {
        get { return dayTasks; }
        set { dayTasks = value; }
    }
    #endregion Getter and Setter

    #region DateTime
    public void CalculateDateTime() {
        if (Hour >= 24) {
            Hour = Hour % 24;
            Day += (int)(Day / 24 + 1);
            DayTasksManager();
        } else if (Day >= CalculateMonthDays(Month)) {
            int monthDays = CalculateMonthDays(Month);
            Day = Day % monthDays;
            Month += (int)(Day / monthDays);
        } else if (Month >= 12) {
            Month = Month % 12;
            Year += (int)(Month / 12);
        }
    }

    public int CalculateMonthDays(double month) {
        switch (month) {
            case 2: {
                // February
                return 28;
            }
            case 4: {
                // April
                return 30;
            }
            case 6: {
                // Juni
                return 30;
            }
            case 9: {
                // September
                return 30;
            }
            case 11: {
                // November
                return 30;
            }
            default: {
                // All other Month
                return 31;
            }
        }
    }
    #endregion DateTime

    public void DayTasksManager() {
        foreach (Action a in dayTasks) {
            a.Invoke();
        }
    }

    public string toString() {
        CalculateDateTime();
        string year = Year < 10 ? "0" + Year : "" + Year;
        string month = Month < 10 ? "0" + Month : "" + Month;
        string day = Day < 10 ? "0" + Day : "" + Day;
        return year + "-" + month + "-" + day + " " + (int)Hour + " Uhr";
    }
}
