using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGraph : MonoBehaviour {


    public RectTransform container;
    public Sprite pointSprite;

    private void Awake() {

    }

    /*
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    */

    public void CreatePoint(Vector2 point) {
        GameObject gameObject = new GameObject("point", typeof(Image));
        gameObject.transform.SetParent(container,false);
        gameObject.GetComponent<Image>().sprite = pointSprite;

    }
}
