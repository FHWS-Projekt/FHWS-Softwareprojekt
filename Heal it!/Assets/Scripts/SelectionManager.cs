using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Material highlightMaterial;
    public Material defaultMaterial;

    public Transform _selection;

    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            Renderer selectionRender = _selection.GetComponent<Renderer>();
            selectionRender.material = defaultMaterial;
            defaultMaterial = null;
            _selection = null;

        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {

            Transform selection = hit.transform;
            Renderer selecetionRender = selection.GetComponent<Renderer>();
            if(selecetionRender != null)
            {
                defaultMaterial = selecetionRender.material;
                selecetionRender.material = highlightMaterial;
            }
            _selection = selection;
        }
    }
}
