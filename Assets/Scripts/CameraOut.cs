using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraOut : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject cameraFullViewPlaceHolder;
    [SerializeField] GameObject crossCut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.transform.position = cameraFullViewPlaceHolder.transform.position;
            crossCut.SetActive(true);
        }
    }
}
