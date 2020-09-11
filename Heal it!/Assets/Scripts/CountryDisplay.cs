using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryDisplay : MonoBehaviour
{
    #region Attributes

    public Country country;
    public Material myMaterial;
    public double temp;
    public EventManager eventManager;
    

    public float fadeColor = 0f;
    Color color;

    #endregion Attributes

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        Main.Instance.MyDateTime.DayTasks.Add(() => CalculateResidents());
        myMaterial.color = Color.green;
        country.residents = country.startResidents;
        country.deathCount = 0;
        country.influenceE = 10;
        country.influenceP = 0.2;

        color = myMaterial.color;

        color.g = 1f;
        color.b = 0f;
        color.r = 0f;

        myMaterial.color = color;

        country.measures = new bool[10];
        country.measuresV = new double[10];
        country.moneyV = new double[10];

        for(int i =  0; i < country.measures.Length; i++)
        {
            country.measures[i] = false;
        }
        for(int i = 0; i < country.measuresV.Length; i++)
        {
            switch (i)
            {
                case 0:
                    country.measuresV[i] = 0;
                    country.moneyV[i] = 1;
                    break;
                case 1:
                    country.measuresV[i] = 0;
                    country.moneyV[i] = 2;
                    break;
                case 2:
                    country.measuresV[i] = 0;
                    country.moneyV[i] = 2;
                    break;
                case 3:
                    country.measuresV[i] = 0;
                    country.moneyV[i] = 6;
                    break;
                case 4:
                    country.measuresV[i] = 0;
                    country.moneyV[i] = 6;
                    break;
                case 5:
                    country.measuresV[i] = 0;
                    country.moneyV[i] = 4;
                    break;
                case 6:
                    country.measuresV[i] = 0;
                    country.moneyV[i] = 3;
                    break;
                case 7:
                    country.measuresV[i] = 0;
                    country.moneyV[i] = 2;
                    break;
                case 8:
                    country.measuresV[i] = 0;
                    country.moneyV[i] = 1;
                    break;
                case 9:
                    country.measuresV[i] = 0;
                    country.moneyV[i] = 1;
                    break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckMeasures();
    }

    #endregion Unity Methods

    #region Methods
    //Method to calculate the infected for the next cycle;
    void CalculateResidents()
    {
        temp = System.Math.Round(1 + country.influenceE * country.influenceP) * (country.infected * country.recoveryRateG);
        country.deathCount = System.Math.Round(country.deathCount + temp);
        //country.residents = System.Math.Round(country.residents - temp);
        country.infected = temp;

        if(country.deathCount > 0)
        {

            color.g =  1 - (System.Convert.ToSingle(country.deathCount / (country.startResidents / 2)));
            color.r = (System.Convert.ToSingle(country.deathCount / (country.startResidents / 2)));

            myMaterial.color = color;
        }


        if (country.residents <= (country.startResidents / 2))
        {
            eventManager.lose = true;
        }
    }
    //Method to check the activ measures;
    public void CheckMeasures()
    {
        for (int i = 0; i < country.measures.Length; i++)
        {
            switch (i)
            {
                case 0:
                    if (country.measures[i])
                    {
                        country.measuresV[i] = 0.01;
                        break;
                    }
                    else
                    {
                        country.measuresV[i] = 0.00;
                        break;
                    }
                case 1:
                    if (country.measures[i])
                    {
                        country.measuresV[i] = 0.02;
                        break;
                    }
                    else
                    {
                        country.measuresV[i] = 0.00;
                        break;
                    }
                case 2:
                    if (country.measures[i])
                    {
                        country.measuresV[i] = 0.02;
                        break;
                    }
                    else
                    {
                        country.measuresV[i] = 0.00;
                        break;
                    }
                case 3:
                    if (country.measures[i])
                    {
                        country.measuresV[i] = 2.25;
                        break;
                    }
                    else
                    {
                        country.measuresV[i] = 0.00;
                        break;
                    }
                case 4:
                    if (country.measures[i])
                    {
                        country.measuresV[i] = 2.25;
                        break;
                    }
                    else
                    {
                        country.measuresV[i] = 0.00;
                        break;
                    }
                case 5:
                    if (country.measures[i])
                    {
                        country.measuresV[i] = 1.5;
                        break;
                    }
                    else
                    {
                        country.measuresV[i] = 0.00;
                        break;
                    }
                case 6:
                    if (country.measures[i])
                    {
                        country.measuresV[i] = 1;
                        break;
                    }
                    else
                    {
                        country.measuresV[i] = 0.00;
                        break;
                    }
                case 7:
                    if (country.measures[i])
                    {
                        country.measuresV[i] = 0.75;
                        break;
                    }
                    else
                    {
                        country.measuresV[i] = 0.00;
                        break;
                    }
                case 8:
                    if (country.measures[i])
                    {
                        country.measuresV[i] = 0.5;
                        break;
                    }
                    else
                    {
                        country.measuresV[i] = 0.00;
                        break;
                    }
                case 9:
                    if (country.measures[i])
                    {
                        country.measuresV[i] = 0.5;
                        break;
                    }
                    else
                    {
                        country.measuresV[i] = 0.00;
                        break;
                    }
            }
            country.influenceP = 0.2 - country.measuresV[0] - country.measuresV[1] - country.measuresV[2];
            country.influenceE = 10 - country.measuresV[3] - country.measuresV[4] - country.measuresV[5] - country.measuresV[6] - country.measuresV[7] - country.measuresV[8] - country.measuresV[9]; 
        }
    }

    #endregion Methods
}
