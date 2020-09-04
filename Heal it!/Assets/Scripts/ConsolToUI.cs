using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsolToUI : MonoBehaviour
{
    #region Attributes

    public TextMeshProUGUI text;
    public string output = "";
    public string stack = "";

    #endregion Attributes

    #region UnityMethods

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void Update()
    {
        text.text = output;
    }

    #endregion Unity Methods

    #region Methods

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        output = logString;
        stack = stackTrace;
    }

    #endregion Methods
}
