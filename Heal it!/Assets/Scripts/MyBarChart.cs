using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyBarChart : MonoBehaviour {

    private static MyBarChart instance;

    // Graph Objects
    [SerializeField] private RectTransform graphContainer;
    [SerializeField] private RectTransform labelTemplateX;
    [SerializeField] private RectTransform labelTemplateY;
    [SerializeField] private RectTransform dashContainer;
    [SerializeField] private RectTransform dashTemplateX;
    [SerializeField] private RectTransform dashTemplateY;

    // Country Object
    [SerializeField] private EventManager eventManager;

    private List<GameObject> gameObjectList;
    private List<BarChartVisual.BarChartVisualObject> graphVisualObjectList;

    // Attributes
    private List<int> valueList = new List<int>() { 0 };
    private BarChartVisual graphVisual;
    private int maxVisibleValueAmount;
    private Func<int, string> getAxisLabelX;
    private Func<float, string> getAxisLabelY;

    private void Awake() {
        instance = this;
        // Grab base objects references
        gameObjectList = new List<GameObject>();
        graphVisualObjectList = new List<BarChartVisual.BarChartVisualObject>();

        BarChartVisual barChartVisual = new BarChartVisual(graphContainer, Color.white, .8f);

        // Set up start values
        List<int> valueList = new List<int>() { 0 };
        //ShowGraph(valueList, barChartVisual, -1, (int _i) => "Day " + (_i + 1), (float _f) => "" + Mathf.RoundToInt(_f));
    }

    // Start is called before the first frame update
    void Start() {
        Main.Instance.MyDateTime.DayTasks.Add(() => UpdateGraph());
    }

    private void UpdateGraph() {
        int infected = 0;
        foreach (Country country in eventManager.countries) {
            if(infected < country.startResidents * 0.5) {
                infected = infected + (int)country.infected;
            }
        }

        int day = (int)Main.Instance.MyDateTime.Day;
        if(valueList.Count <= day) {
            valueList.Add(infected);
        }else {
            valueList[day] = infected;
        }
    }

    public void ShowGraph() {
        if (!graphContainer.gameObject.activeSelf) {
            graphContainer.gameObject.SetActive(true);
            BarChartVisual barChartVisual = new BarChartVisual(graphContainer, Color.white, .8f);
            ShowGraph(valueList, barChartVisual, -1, (int _i) => "Day " + (_i + 1), (float _f) => "" + Mathf.RoundToInt(_f));
        } else {
            graphContainer.gameObject.SetActive(false);

        }
    }
    
    private void ShowGraph(List<int> valueList, BarChartVisual graphVisual, int maxVisibleValueAmount = -1, Func<int, string> getAxisLabelX = null, Func<float, string> getAxisLabelY = null) {
        this.valueList = valueList;
        this.graphVisual = graphVisual;
        this.getAxisLabelX = getAxisLabelX;
        this.getAxisLabelY = getAxisLabelY;

        if (maxVisibleValueAmount <= 0) {
            // Show all if no amount specified
            maxVisibleValueAmount = valueList.Count;
        }
        if (maxVisibleValueAmount > valueList.Count) {
            // Validate the amount to show the maximum
            maxVisibleValueAmount = valueList.Count;
        }

        this.maxVisibleValueAmount = maxVisibleValueAmount;

        // Test for label defaults
        if (getAxisLabelX == null) {
            getAxisLabelX = delegate (int _i) { return _i.ToString(); };
        }
        if (getAxisLabelY == null) {
            getAxisLabelY = delegate (float _f) { return Mathf.RoundToInt(_f).ToString(); };
        }

        // Clean up previous graph
        foreach (GameObject gameObject in gameObjectList) {
            Destroy(gameObject);
        }
        gameObjectList.Clear();

        foreach (BarChartVisual.BarChartVisualObject graphVisualObject in graphVisualObjectList) {
            graphVisualObject.CleanUp();
        }
        graphVisualObjectList.Clear();
        
        // Grab the width and height from the container
        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        // Identify y Min and Max values
        float yMaximum = valueList[0];
        float yMinimum = valueList[0];
        
        for (int i = Mathf.Max(valueList.Count - maxVisibleValueAmount, 0); i < valueList.Count; i++) {
            int value = valueList[i];
            if (value > yMaximum) {
                yMaximum = value;
            }
            if (value < yMinimum) {
                yMinimum = value;
            }
        }

        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0) {
            yDifference = 5f;
        }
        yMaximum = yMaximum + (yDifference * 0.2f);
        yMinimum = yMinimum - (yDifference * 0.2f);

        yMinimum = 0f; // Start the graph at zero

        // Set the distance between each point on the graph 
        float xSize = graphWidth / (maxVisibleValueAmount + 1);

        // Cycle through all visible data points
        int xIndex = 0;
        for (int i = Mathf.Max(valueList.Count - maxVisibleValueAmount, 0); i < valueList.Count; i++) {
            float xPosition = xSize + xIndex * xSize;
            float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;

            // Add data point visual
            string tooltipText = getAxisLabelY(valueList[i]);
            graphVisualObjectList.Add(graphVisual.CreateGraphVisualObject(new Vector2(xPosition, yPosition), xSize, tooltipText));

            // Duplicate the x label template
            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -7f);
            labelX.GetComponent<Text>().text = getAxisLabelX(i);
            gameObjectList.Add(labelX.gameObject);
            
            // Duplicate the x dash template
            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(dashContainer, false);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(xPosition, -3f);
            gameObjectList.Add(dashX.gameObject);

            xIndex++;
        }

        // Set up separators on the y axis
        int separatorCount = 10;
        for (int i = 0; i <= separatorCount; i++) {
            // Duplicate the label template
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = getAxisLabelY(yMinimum + (normalizedValue * (yMaximum - yMinimum)));
            gameObjectList.Add(labelY.gameObject);

            // Duplicate the dash template
            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(dashContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(-4f, normalizedValue * graphHeight);
            gameObjectList.Add(dashY.gameObject);
        }
    }

    /*
     * Displays data points as a Bar Chart
     * */
    private class BarChartVisual {

        private RectTransform graphContainer;
        private Color barColor;
        private float barWidthMultiplier;

        public BarChartVisual(RectTransform graphContainer, Color barColor, float barWidthMultiplier) {
            this.graphContainer = graphContainer;
            this.barColor = barColor;
            this.barWidthMultiplier = barWidthMultiplier;
        }

        public BarChartVisualObject CreateGraphVisualObject(Vector2 graphPosition, float graphPositionWidth, string tooltipText) {
            GameObject barGameObject = CreateBar(graphPosition, graphPositionWidth);

            BarChartVisualObject barChartVisualObject = new BarChartVisualObject(barGameObject, barWidthMultiplier);
            barChartVisualObject.SetGraphVisualObjectInfo(graphPosition, graphPositionWidth, tooltipText);

            return barChartVisualObject;
        }

        private GameObject CreateBar(Vector2 graphPosition, float barWidth) {
            GameObject gameObject = new GameObject("bar", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().color = barColor;
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(graphPosition.x, 0f);
            rectTransform.sizeDelta = new Vector2(barWidth * barWidthMultiplier, graphPosition.y);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(.5f, 0f);

            return gameObject;
        }

        public class BarChartVisualObject {

            private GameObject barGameObject;
            private float barWidthMultiplier;

            public BarChartVisualObject(GameObject barGameObject, float barWidthMultiplier) {
                this.barGameObject = barGameObject;
                this.barWidthMultiplier = barWidthMultiplier;
            }

            public void SetGraphVisualObjectInfo(Vector2 graphPosition, float graphPositionWidth, string tooltipText) {
                RectTransform rectTransform = barGameObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(graphPosition.x, 0f);
                rectTransform.sizeDelta = new Vector2(graphPositionWidth * barWidthMultiplier, graphPosition.y);
            }

            public void CleanUp() {
                Destroy(barGameObject);
            }
        }
    }
}
