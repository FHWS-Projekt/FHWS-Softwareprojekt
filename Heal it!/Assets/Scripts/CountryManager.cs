using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryManager : MonoBehaviour
{
    #region Attributes
    [SerializeField] protected Country[] countries = new Country[25];
    #endregion Attributes

    #region Getter and Setter
    public Country[] Countries {
        get { return countries; }
        set { countries = value; }
    }
    #endregion Getter and Setter


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
