using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject UserPanel;
    private Text playerText;
    public InputField Input;

    void Awake()
    {
        playerText = GameObject.Find("PlayerText").GetComponent<Text>();
    }

    void Start()
    {
       if (playerText.text.Equals(""))
        {
            UserPanel.SetActive(true);
        }
    }

    public void closePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }

    public void openPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void userOkayButton()
    {
        if (Input.text.Length > 0)
        {
            playerText.text = Input.text;
            UserPanel.SetActive(false);
            openPanel();
        }
    }
}
