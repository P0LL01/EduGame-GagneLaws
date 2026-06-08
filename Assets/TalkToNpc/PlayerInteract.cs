using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class PlayerInteract : MonoBehaviour
{

    public Camera mainCam;
    public float interactionDistance = 2f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    //public void Update() { 
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        float interactRange = 2f;
    //        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
    //        foreach (Collider collider in colliderArray)
    //        {
    //            //if we get to the collider, we check if it has the NPCInteract component, if it does we call the Interact method
    //            if (collider.TryGetComponent(out NPCInteract nPCInteract))
    //            {
    //                nPCInteract.Interact();
    //            }
    //        }
    //    }
    //}

    void Start()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main; 
        }
    }

    private void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            //    //IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            //    if (interactable != null)
            //    {
            //        hitSomething = true;
            //        interactionUI.SetActive(true);
            //        interactionText.text = interactable.GetInteractionText();
            //        if (Input.GetKeyDown(KeyCode.E))
            //        {
            //            interactable.Interact();
            //        }
            //    }
            //}

            interactionUI.SetActive(hitSomething);
        }
    }
}


