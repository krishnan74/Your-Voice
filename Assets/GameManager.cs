using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainCamera;

    //public GameObject GameStartUI;


    public CameraScript cameraScriptObject; 

    public float CamMoveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Z))
        {
            ZoomIn();
        }

        if( Input.GetKeyDown(KeyCode.N))
        {
            NextLetter();
        }
    }

    public void NextLetter()
    {
        Debug.Log("Next Letter");
        cameraScriptObject.NextLetterTransition();
    }

    public void ZoomIn()
    {
        Debug.Log("Zoom In");
        Word fightWord = new Word(
    "Fight",
    new Vector3(-37.9f, -8.2f, -30.8f),
    new Vector3(60.7000008f, 59.449192f, -44.228199f)
);

        cameraScriptObject.ZoomInToLetter(fightWord);
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
