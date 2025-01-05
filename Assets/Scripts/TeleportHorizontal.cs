using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHorizontal : MonoBehaviour
{
    [SerializeField] GameObject teleportTo;
    [SerializeField] GameObject mainCamera;

    public GameManager gameManager;


    private Player player;

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            // if(
            //     gameManager.currentIndex + 1 > gameManager.currentWord.getLetters().Count)
            // {
            //     gameManager.PanOut();
            //     return;
            // }

            player.playerInstance.transform.position = teleportTo.transform.position;
            //mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + 24f, mainCamera.transform.position.y, mainCamera.transform.position.z);
            //gameManager.NextLetter();
        }
    }
}
