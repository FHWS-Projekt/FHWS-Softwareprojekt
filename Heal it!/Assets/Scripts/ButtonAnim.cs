using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{

    public Sprite pause;
    public Sprite play;
    public bool mode;
    public Image buttonImage;

    private void Start()
    {
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
}
