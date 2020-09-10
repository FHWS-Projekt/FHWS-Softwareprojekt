using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;

public class ContinentDisplay : MonoBehaviour
{
    #region Attributes

    public Continent continent;

    #endregion Attributes

    #region Unity Methods

    void Start()
    {
        continent.airport = this.gameObject.transform.position;
    }

    #endregion Unity Methods

    #region Methods

    #endregion Methods
}
