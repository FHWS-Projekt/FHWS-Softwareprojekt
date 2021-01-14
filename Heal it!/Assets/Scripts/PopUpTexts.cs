using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTexts : MonoBehaviour
{
    #region Attributes
    public GameObject PausePanel;
    public  Main mainScript;
    private Text popUpText;
    private string midgameText = "Hey! Bis jetzt schlägst du dich gut im Kampf gegen den Virus. Wir arbeiten weiterhin mit Nachdruck an der Entwicklung eines Impfstoffs! Halte die Infektionszahlen noch eine Weile gering, bis wir die Entwicklung abschließen konnten und der Impfstoff eingesetzt werden kann.";
    private string startGameText = "Es geht los! Im Newsfeed wird dir angezeigt welches Land bereits einen Infizierten aufweist. Du kannst die Erdkugel drehen und auf einen Kontinent klicken, um in das jeweilige Menü zu gelangen. Versuche deine Maßnahmen möglichst in den Ländern mit Infizierten zu verteilen. Viel Erfolg!";
    private string highMoneyText = "Hey, du hast ganz schön viel Gold angespart. Vielleicht solltest du etwas davon in weitere Maßnahmen investieren!";
    private int day;
    private bool notAgain = false;
    public GameObject TutorialPanel;
    #endregion Attributes
    #region Unity Methods

    #endregion Unity Methods
    void Awake()
    {
        popUpText = GameObject.Find("PopUpText").GetComponent<Text>();
        Main.Instance.MyDateTime.DayTasks.Add(() => gamePopUps());
        //PausePanel.SetActive(false); /auskommentiert für neues Start Pop-Up -Andrej 23.09.2020
    }
    // Start is called before the first frame update
    void Start()
    {
        mainScript.SetTimeButtonPlayPauseOnClickTask();
        PausePanel.SetActive(false);
        TutorialPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Methods
    public void popUp(string text) {
        mainScript.SetTimeButtonPlayPauseOnClickTask();
        PausePanel.SetActive(true);
        popUpText.text = text;
    }
    public void closePopUp() {
        PausePanel.SetActive(false);
        mainScript.SetTimeButtonPlayPauseOnClickTask();
    }
    public void gamePopUps() {
        if (Main.Instance.Money >= 17 && !notAgain) {
            popUp(highMoneyText);
            notAgain = true;
        }
        if (Main.Instance.MyDateTime.Day >= 25 && Main.Instance.MyDateTime.Day < 26) {
            popUp(midgameText);
        }
    }
    public void startPopUp() {
        mainScript.SetTimeButtonPlayPauseOnClickTask();
        PausePanel.SetActive(true);
        popUpText.text = startGameText;
    }
    public void endTutorial() {
        mainScript.SetTimeButtonPlayPauseOnClickTask();
        TutorialPanel.SetActive(false);
        popUp(startGameText);
    }
    #endregion Methods

}
