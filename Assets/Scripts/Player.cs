using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject playerInstance;
    public Transform spawnPosition;

    public float speedToMove;
    public float jumpForce;
    public float rayCastDistance;

    public bool readyToMove;
    private Rigidbody playerRigidBody;

    public void Start()
    {
        SpawnPlayerCharacter();

    }

    public void Update()
    {
        playerMovement();

    }

    public void SpawnPlayerCharacter()
    {
        playerInstance = Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);

        if (playerInstance.GetComponent<Rigidbody>() == null)
        {
            playerRigidBody = playerInstance.AddComponent<Rigidbody>();
        }
        else
        {
            playerRigidBody = playerInstance.GetComponent<Rigidbody>();
        }

        playerRigidBody.constraints = RigidbodyConstraints.FreezeRotation;

        readyToMove = true;
    }

    public void playerMovement()
    {
        if (readyToMove == true && playerInstance != null)
        {
            if (Input.GetKey(KeyCode.D) )

            {
                playerInstance.transform.Translate(Vector3.right * speedToMove * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                playerInstance.transform.Translate(Vector3.left * speedToMove * Time.deltaTime);
            }

            // if (Input.GetKey(KeyCode.Space) && isGrounded())
            // {
            //     playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // }
        }
    }

    // private bool isGrounded()
    // {
    //     return Physics.Raycast(playerInstance.transform.position, Vector3.down, rayCastDistance);
    // }

    // private void OnDrawGizmos()
    // {
    //     if (playerInstance != null)
    //     {
    //         Gizmos.color = Color.red;
    //         Gizmos.DrawLine(playerInstance.transform.position, playerInstance.transform.position + Vector3.down * rayCastDistance);
    //     }
    // }


}
