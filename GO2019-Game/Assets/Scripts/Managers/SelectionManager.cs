using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private LayerMask pickupMask = 0;
    [SerializeField] private float pickupDistance = 5f;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Transform handTransform;

    private Material defaultMaterial;
    private Transform currentSelection;
    private bool handFull = false;

    // Update is called once per frame
    void Update()
    {
        if(currentSelection != null){
            ChangeMaterial(currentSelection.GetComponent<Renderer>(), defaultMaterial);
            currentSelection = null;
        }

        HighlightObject();

        if(Input.GetKeyDown(interactKey)){
            Interact();
        }

        if(Input.GetMouseButtonDown(0) && handFull){
            UseObject();
        }
    }

    void Interact(){
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, pickupDistance, pickupMask)){
            var selection = hit.transform;

            if(selection.GetComponent<PickupableObject>() && !handFull){
                selection.GetComponent<PickupableObject>().ObjectInteraction(handTransform);
                handFull = true;
            } else if(handFull){
                Debug.Log("Already holding object");
            }else {
                selection.GetComponent<InteractableObject>().ObjectInteraction();
            }
        }
    }

    void HighlightObject(){
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

    void UseObject(){
        if(handTransform.GetComponentInChildren<PickupableObject>()){
            handTransform.GetComponentInChildren<PickupableObject>().UseObject();
            handFull = false;
        }
    }

    void ChangeMaterial(Renderer renderer, Material material){
        defaultMaterial = renderer.material;
        renderer.material = material;
    }
}
