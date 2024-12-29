using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject interactableObject;

    private bool canInteract;
    public bool isCarrying = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (!isCarrying) // Carry Object
            {   
                interactableObject.transform.SetParent(playerObject.transform); 
                interactableObject.transform.localPosition = new Vector3(0, 0, -1); 
                isCarrying = true;
                Debug.Log("Object grabbed!");
            }
            else // Not Carrying
            {
                interactableObject.transform.SetParent(null); 
                isCarrying = false;
                Debug.Log("Object dropped!");
            }
        }

        if (isCarrying) // Object POsition
        {
            Vector3 offset = -playerObject.transform.forward;
            interactableObject.transform.position = playerObject.transform.position + offset;
        }
    }
}
