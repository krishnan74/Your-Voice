using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject leverObject;
    [SerializeField] GameObject leverInteractable;
    [SerializeField] Vector3 goToPositon;

    public bool canInteract;

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
            {
                leverInteractable.transform.position += new Vector3(-0.8f,0,0);
                leverInteractable.transform.eulerAngles = new Vector3(0,0,90);
            }
        }
    }

}
