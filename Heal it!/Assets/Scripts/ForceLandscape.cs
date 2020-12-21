using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ForceLandscape : MonoBehaviour
{

    [SerializeField] protected TextMeshProUGUI introTextTMP;
    public static IntroTextData introTextData;
    protected static readonly string myDatabase = Path.Combine(Application.streamingAssetsPath, "MyDatabase.json");


    public class IntroTextData {
        public string introText;
    }



    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        introTextData = new JsonParser().ReadFromJson<IntroTextData>(myDatabase);
        if(introTextTMP != null)
        {
            introTextTMP.text = introTextData.introText;
        }
    }


}
