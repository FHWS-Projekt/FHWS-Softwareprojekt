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
    private int day;
    #endregion Attributes
    #region Unity Methods

    #endregion Unity Methods
    void Awake()
    {
        popUpText = GameObject.Find("PopUpText").GetComponent<Text>();
        PausePanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        //Main.Instance.MyDateTime.DayTasks.Add(() => gamePopUps());
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
        if (Main.Instance.MyDateTime.Day > 2 && Main.Instance.MyDateTime.Day < 3) {
            popUp(midgameText);
        }
    }
    #endregion Methods

}
