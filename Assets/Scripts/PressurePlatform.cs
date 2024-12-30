using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlatform : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject platformToDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere")
        {
            Destroy(platformToDestroy);
        }
    }
}
