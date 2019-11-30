using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private LayerMask pickupMask = 0;
    [SerializeField] private float pickupDistance = 5f;
    [SerializeField] private Material highlightMaterial = null;
    [SerializeField] private Transform handTransform = null;
    [SerializeField] private LayerMask groundMask = 9;
    [SerializeField] private Camera playerCamera = null;

    private Material defaultMaterial = null;
    private Transform currentSelection = null;
    private bool handFull = false;

    PlayerUIManager playerUIManager = null;

    void Start()
    {
        playerUIManager = GetComponent<PlayerUIManager>();
    }

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

        RaycastHit hit;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickupDistance, pickupMask)){
            var selection = hit.transform;

            if(selection.GetComponent<PickupableObject>() && !handFull){
                selection.GetComponent<PickupableObject>().ObjectInteraction(handTransform);
                handFull = true;
            } else if(handFull && selection.GetComponent<PickupableObject>()){                
                PickupableObject item = handTransform.GetComponentInChildren<PickupableObject>();
                item.PlaceObject(selection.position);                
                selection.GetComponent<PickupableObject>().ObjectInteraction(handTransform);
                handFull = true;
            }else {
                selection.GetComponent<InteractableObject>().ObjectInteraction();
            }
        }
    }

    void HighlightObject(){

        RaycastHit hit;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickupDistance, pickupMask)){
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if(selectionRenderer != null){
                ChangeMaterial(selection.GetComponent<Renderer>(), highlightMaterial);
            }
            currentSelection = selection;    
        }
    }

    void UseObject(){
        PickupableObject item = handTransform.GetComponentInChildren<PickupableObject>();

        if(item.isPlaceable){

            RaycastHit hit;
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickupDistance, groundMask)){
                item.PlaceObject(new Vector3(hit.point.x, hit.point.y, hit.point.z));       
                handFull = false;     
            }            
        } else{
            item.UseObject();
            if(item.tag == "Healing Potion")
            {   
                playerUIManager.TakeHealing(item.potionHealing);
            }
            if(item.tag == "Stamina Potion")
            {   
                playerUIManager.ReceiveStamina(item.potionStamina);
            }
            handFull = false;
        }
    }

    void ChangeMaterial(Renderer renderer, Material material){
        defaultMaterial = renderer.material;
        renderer.material = material;
    }
}
