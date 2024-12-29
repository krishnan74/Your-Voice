using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] GameObject gravityObject;
    [SerializeField] float velocityUpward;

    [SerializeField] bool canFly;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canFly = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canFly = false;
            gravityObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void Update()
    {
        if (canFly)
        {
            gravityObject.GetComponent<Rigidbody>().useGravity = false;
            gravityObject.GetComponent<Rigidbody>().velocity = new Vector3(0, velocityUpward, 0);
        }
    }
}
