using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{

    public Sprite pause;
    public Sprite play;
    public bool mode;
    public Image buttonImage;
    public PlayerSettings playerSettings;

    public TextMeshProUGUI playerTextMeshPro;
    public Toggle musicToggle;
    public TMP_Dropdown dropdownMenu;

    public TextMeshProUGUI musicText;

    private void Start()
    {
        if(gameObject.GetComponent<Image>() != null)
        buttonImage = gameObject.GetComponent<Image>();
        mode = true;       
    }
    public void ChangeSprite()
    {
        if (mode)
        {
            mode = false;
            buttonImage.sprite = play;
        }
        else if (!mode)
        {
            mode = true;
            buttonImage.sprite = pause;
        }
    }
    public void SaveSettings()
    {
        if(playerTextMeshPro != null)
        {    
            playerSettings.playerName = playerTextMeshPro.text;
        }
        if(musicToggle != null)
        {
            if (musicToggle.isOn == true)
            {
                playerSettings.sound = true;
            }
            else if (musicToggle.isOn == false)
            {
                playerSettings.sound = false;
            }
        }
        if(dropdownMenu != null)
        {
            playerSettings.difficulty = dropdownMenu.value;
        }
    }
    public void ChangeText()
    {
        if(musicToggle.isOn == true)
        {
            musicText.text = "An";
        }
        else if(musicToggle.isOn == false)
        {
            musicText.text = "Aus";
        }
    }
}
