using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHorizontal : MonoBehaviour
{
    [SerializeField] GameObject teleportTo;
    [SerializeField] GameObject mainCamera;

    private Player player;

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.playerInstance.transform.position = teleportTo.transform.position;
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + 24f, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
    }
}
