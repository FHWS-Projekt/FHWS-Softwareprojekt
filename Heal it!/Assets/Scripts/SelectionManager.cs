using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEditorInternal;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

                var SelectionRenderer = selection.GetComponent<Renderer>();
                if (SelectionRenderer != null)
                {
                    SelectionRenderer.material = highlightMaterial;
                }
            

            _selection = selection;

        }
    }
}
