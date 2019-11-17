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
    [SerializeField] private LayerMask groundMask = 9;
    [SerializeField] private Camera playerCamera;

    private Material defaultMaterial;
    private Transform currentSelection;
    private bool handFull = false;

    PlayerUIManager playerUIManager;

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
            Debug.Log("Raycast hit");
            var selection = hit.transform;

            if(selection.GetComponent<PickupableObject>() && !handFull){
                selection.GetComponent<PickupableObject>().ObjectInteraction(handTransform);
                handFull = true;
            } else if(handFull){                
                PickupableObject item = handTransform.GetComponentInChildren<PickupableObject>();
                item.PlaceObject(selection.position); 
                Debug.Log("Here");               
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
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickupDistance, pickupMask)){
                item.PlaceObject(new Vector3(hit.point.x, hit.point.y, hit.point.z));       
                handFull = false;     
                Debug.Log("Here");
            }            
        } else{
            item.UseObject();
            if(item.tag == "Healing Potion")
            {   
                playerUIManager.TakeHealing(item.potionHealing);
                Debug.Log("Healing");
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
