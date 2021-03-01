using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyBarChart : MonoBehaviour
{

    // Graph Objects
    [SerializeField] private RectTransform graphContainer;
    [SerializeField] private RectTransform labelTemplateX;
    [SerializeField] private RectTransform labelTemplateY;
    [SerializeField] private RectTransform dashContainer;
    [SerializeField] private RectTransform dashTemplateX;
    [SerializeField] private RectTransform dashTemplateY;

    // Country Object
    [SerializeField] private EventManager eventManager;
    private List<int> infectedList = new List<int>() { 1 };

    private List<GameObject> gameObjectList;
    private List<BarChartVisual.BarChartVisualObject> graphVisualObjectList;

    private void Awake()
    {
        // Grab base objects references
        gameObjectList = new List<GameObject>();
        graphVisualObjectList = new List<BarChartVisual.BarChartVisualObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Main.Instance.MyDateTime.DayTasks.Add(() => UpdateGraph());
        Main.Instance.MyDateTime.DayTasks.Add(() => newDay());
    }

    public void newDay()
    {
        ShowGraph();
        ShowGraph();
    }

    private void UpdateGraph()
    {
        int infected = 0;
        foreach(Country country in eventManager.infectedCountries)
        {
            infected = (int)(infected + country.infected);
        }
        double day = Main.Instance.MyDateTime.Day;
        if(day > 1)
        {
            infectedList.Add(infected);
        }
    }

    public void ShowGraph()
    {
        if(!graphContainer.gameObject.activeSelf)
        {
            graphContainer.gameObject.SetActive(true);
            BarChartVisual barChartVisual = new BarChartVisual(graphContainer, Color.yellow, .8f);
            ShowGraph(barChartVisual, (int _i) => "" + (_i + 1), (float _f) => "" + Mathf.RoundToInt(_f));
        } else
        {
            graphContainer.gameObject.SetActive(false);
        }
    }

    private void ShowGraph(BarChartVisual graphVisual, Func<int, string> getAxisLabelX = null, Func<float, string> getAxisLabelY = null)
    {

        // Clean up previous graph
        foreach(GameObject gameObject in gameObjectList)
        {
            Destroy(gameObject);
        }
        gameObjectList.Clear();

        foreach(BarChartVisual.BarChartVisualObject graphVisualObject in graphVisualObjectList)
        {
            graphVisualObject.CleanUp();
        }
        graphVisualObjectList.Clear();

        // Grab the width and height from the container
        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        // Identify y Min and Max values
        float yMaximum = infectedList[0];
        float yMinimum = 0f; // Start the graph at zero

        for(int i = 0; i < infectedList.Count; i++)
        {
            int value = infectedList[i];
            if(value > yMaximum)
            {
                yMaximum = value;
            }
        }

        float yDifference = yMaximum - yMinimum;
        if(yDifference <= 0)
        {
            yDifference = 5f;
        }
        yMaximum = yMaximum + (yDifference * 0.2f);

        // Set the distance between each point on the graph 
        float xSize = graphWidth / (infectedList.Count + 1);

        // Cycle through all visible data points
        int xIndex = 0;
        for(int i = 0; i < infectedList.Count; i++)
        {
            float xPosition = xIndex * xSize + xSize;
            float yPosition = (infectedList[i] / yMaximum) * graphHeight;

            // Add data point visual
            graphVisualObjectList.Add(graphVisual.CreateGraphVisualObject(new Vector2(xPosition, yPosition), xSize));

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
        for(int i = 0; i <= separatorCount; i++)
        {
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

    // Displays data points as a Bar Chart
    private class BarChartVisual
    {

        private RectTransform graphContainer;
        private Color barColor;
        private float barWidthMultiplier;

        public BarChartVisual(RectTransform graphContainer, Color barColor, float barWidthMultiplier)
        {
            this.graphContainer = graphContainer;
            this.barColor = barColor;
            this.barWidthMultiplier = barWidthMultiplier;
        }

        public BarChartVisualObject CreateGraphVisualObject(Vector2 graphPosition, float graphPositionWidth)
        {
            GameObject barGameObject = CreateBar(graphPosition, graphPositionWidth);

            BarChartVisualObject barChartVisualObject = new BarChartVisualObject(barGameObject, barWidthMultiplier);
            //barChartVisualObject.SetGraphVisualObjectInfo(graphPosition, graphPositionWidth);

            return barChartVisualObject;
        }

        private GameObject CreateBar(Vector2 graphPosition, float barWidth)
        {
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

        public class BarChartVisualObject
        {

            private GameObject barGameObject;
            private float barWidthMultiplier;

            public BarChartVisualObject(GameObject barGameObject, float barWidthMultiplier)
            {
                this.barGameObject = barGameObject;
                this.barWidthMultiplier = barWidthMultiplier;
            }

            public void SetGraphVisualObjectInfo(Vector2 graphPosition, float graphPositionWidth)
            {
                RectTransform rectTransform = barGameObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(graphPosition.x, 0f);
                rectTransform.sizeDelta = new Vector2(graphPositionWidth * barWidthMultiplier, graphPosition.y);
            }

            public void CleanUp()
            {
                Destroy(barGameObject);
            }
        }
    }
}
