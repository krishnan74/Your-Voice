using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
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
