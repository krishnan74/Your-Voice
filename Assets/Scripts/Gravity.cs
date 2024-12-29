using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] GameObject gravityObject;
    [SerializeField] float velocityUpward;

    [SerializeField] bool canFly;

    private Player player;

    private void Start()
        {
            player = FindObjectOfType<Player>();
        }
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
            player.playerInstance.GetComponent<Rigidbody>().useGravity = true;
            player.playerInstance.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    private void Update()
    {
        if (canFly)
        {
            player.playerInstance.GetComponent<Rigidbody>().useGravity = false;
            player.playerInstance.GetComponent<Rigidbody>().velocity = new Vector3(0, velocityUpward, 0);
        }
    }
}
