using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private LayerMask pickupMask;
    [SerializeField] private float pickupDistance = 5f;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private string selectableTag;

    private Material defaultMaterial;
    private Transform currentSelection;

    // Update is called once per frame
    void Update()
    {
        if(currentSelection != null){
            ChangeMaterial(currentSelection.GetComponent<Renderer>(), defaultMaterial);
            currentSelection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, pickupDistance, pickupMask)){
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if(selectionRenderer != null){
                ChangeMaterial(selection.GetComponent<Renderer>(), highlightMaterial);
            }
            currentSelection = selection;    
        }
    }

    void ChangeMaterial(Renderer renderer, Material material){
        defaultMaterial = renderer.material;
        renderer.material = material;
    }
}
