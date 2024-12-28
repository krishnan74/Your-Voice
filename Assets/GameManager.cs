using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainCamera;

    public GameObject GameStartUI;
    public Transform firstPosition;
    public Transform secondPosition;

    public CameraScript cameraScriptObject; 

    public float CamMoveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
        //GameStartUI.SetActive(false);
        cameraScriptObject.GameStartTransition();
    }

    public void LoadGame()
    {
        Debug.Log("Game Loaded");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings Opened");
    } 

    public void QuitGame()
    {
        Debug.Log("Game Quit");
    }
}
