using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGraph : MonoBehaviour {

    #region Attributes
    [SerializeField] protected RectTransform container;
    [SerializeField] protected float containerWidth;
    [SerializeField] protected float containerHeight;
    [SerializeField] protected Sprite pointSprite;

    [SerializeField] protected double[] points = new double[50];

public EventManager eventManager;
    #endregion Attributes

    #region Getter and Setter
    public RectTransform Container {
        get { return container; }
        set { container = value; }
    }
    public float ContainerWidth {
        get { return containerWidth; }
        set { containerWidth = value; }
    }
    public float ContainerHeight {
        get { return containerHeight; }
        set { containerHeight = value; }
    }
    public Sprite PointSprite {
        get { return pointSprite; }
        set { pointSprite = value; }
    }
    #endregion Getter and Setter


    // Start is called before the first frame update
    void Start() {
        Main.Instance.MyDateTime.DayTasks.Add(() => UpdateGraph2());
        Main.Instance.MyDateTime.DayTasks.Add(() => UpdatePoints());
    }

    // Update is called once per frame
    void Update() {

    }
    

    public void CreatePoint(Vector2 point) {
        GameObject gameObject = new GameObject("point", typeof(Image));
        gameObject.transform.SetParent(Container, false);
        gameObject.GetComponent<Image>().sprite = PointSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = point;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }


    public void UpdatePoints() {
        int day = (int)Main.Instance.MyDateTime.Day;
        double infected = 0;
        foreach (Country country in eventManager.countries) {
            infected = infected + (int)country.infected;
        }
        points[day - 1] = infected;
    }

    public void DrawGraph() {
        //GameObject.Destroy(child.gameObject);
    }


    public void UpdateGraph2() {
        ContainerWidth = Container.rect.width * Container.localScale.x;
        ContainerHeight = Container.rect.height * Container.localScale.y;

        double day = (int)Main.Instance.MyDateTime.Day;
        day = day * ContainerWidth / 50;

        double infected = 0;
        double population = 0;
        foreach (Country country in eventManager.countries ) {
            // if()
            // infected = infected + (int)country.infected;
            // population = population + country.startResidents;
        }
        Debug.Log(infected);

        infected = infected * ContainerHeight / population;


        CreatePoint(new Vector2((float)day, (float)infected));
    }
}
