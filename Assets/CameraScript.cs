using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform secondTransformPosition;
    public float camMoveSpeed = 5f; 

    private bool isMoving = false; 

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, secondTransformPosition.position, camMoveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, secondTransformPosition.rotation, camMoveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, secondTransformPosition.position) < 0.1f)
            {
                transform.position = secondTransformPosition.position;
                transform.rotation = secondTransformPosition.rotation;
                isMoving = false; 
            }
        }
    }

    public void GameStartTransition()
    {
        Debug.Log("Game start transition");
        isMoving = true; 
    }
}
