using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.Windows.Speech;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera;
    public RiddleData riddleData;
    public TextMeshProUGUI riddleText;
    public GameObject[] AlphabetPrefabs;
    public CameraScript cameraScriptObject;

    public GameObject gameMenuUI;

    public CoordinatesData coordinatesData; 

    

    public List<Word> wordList = new List<Word>();

    private KeywordRecognizer crossWordKeyWordRecognizer;

    private KeywordRecognizer gameMenuKeyWordRecognizer;

    private Dictionary<string, Action> menuActions = new Dictionary<string, Action>();

    private bool isRiddleFound = false;

    private bool isGameStart = false;
    private int currentRiddleIndex = 0;

    public float CamMoveSpeed = 5f;

    public Word currentWord;

    public int currentIndex;
    public GameObject StrikeDownCube;


    void Start()
    {
        // Ensure riddle data is assigned
        if (riddleData == null || riddleData.riddles.Count == 0)
        {
            Debug.LogError("Riddle data is missing or empty!");
            return;
        }

        menuActions.Add("pause", PauseGame);
        menuActions.Add("start game", StartGame);
        menuActions.Add("open settings", OpenSettings);

        // Initialize Keyword Recognizer with answers from the riddle data
        List<string> answers = new List<string>();
        foreach (var riddle in riddleData.riddles)
        {
            answers.Add(riddle.answer.ToUpper()); // Ensure answers are in uppercase for consistency
        }

        Debug.Log("Answers: " + string.Join(", ", answers.ToArray()));
        gameMenuKeyWordRecognizer = new KeywordRecognizer(menuActions.Keys.ToArray());
        gameMenuKeyWordRecognizer.OnPhraseRecognized += RecognizedMenuSpeech;

        gameMenuKeyWordRecognizer.Start();

        Debug.Log("Game Menu KeyRecognizer Started");

        crossWordKeyWordRecognizer = new KeywordRecognizer(answers.ToArray());
        crossWordKeyWordRecognizer.OnPhraseRecognized += RecognizedSpeech;

        // Display the first riddle
        DisplayRiddle();

        // Spawn letters for the first word
        SpawnLetters();
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
        //GameStartUI.SetActive(false);
        isGameStart = true;
        cameraScriptObject.GameStartTransition();
    }

    public void PauseGame(){
        Debug.Log("Game Paused");
        gameMenuUI.SetActive(true);
        Time.timeScale = 0;

    }

    public void OpenSettings(){
        Debug.Log("Settings opened");
    }

    void Update()
    {

        if( Input.GetKeyDown(KeyCode.Z)){
            Word zoomingWord = wordList.Find(word => word.getWordString().ToUpper() == "CAT");
            currentWord = zoomingWord;
            currentIndex = 0;
            ZoomIn( zoomingWord);
            Debug.Log("Current Word Zoomed In: " + zoomingWord.getWordString() + "Current Letter" + zoomingWord.getLetters()[currentIndex].getCharacter());
            
        }

        if( Input.GetKeyDown(KeyCode.S)){
            StartGame();
        }

        if( Input.GetKeyDown(KeyCode.N)){
            //PauseGame();
            NextLetter();
        }

        if( Input.GetKeyDown(KeyCode.P)){
            PanOut();
        }

        if (!isRiddleFound )
        {
            if (!crossWordKeyWordRecognizer.IsRunning && isGameStart)
            {
                crossWordKeyWordRecognizer.Start();
                Debug.Log("Cross Keyword Recognizer Started");
            }
        }
        else
        {
            if(crossWordKeyWordRecognizer.IsRunning){
                crossWordKeyWordRecognizer.Stop();
                Debug.Log("Keyword Recognizer Stopped");
            }
          
        }
    }

    private void DisplayRiddle()
    {
        riddleText.text = riddleData.riddles[currentRiddleIndex].question;
        Debug.Log("Riddle Displayed: " + riddleData.riddles[currentRiddleIndex].question);
    }

    private void RecognizedMenuSpeech(PhraseRecognizedEventArgs speech ){
        Debug.Log($"Recognized Text: {speech.text}, Confidence: {speech.confidence}");
        menuActions[speech.text].Invoke();

    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log($"Recognized Text: {speech.text}, Confidence: {speech.confidence}");

        // Check if the recognized word matches the current riddle's answer
        string correctAnswer = riddleData.riddles[currentRiddleIndex].answer.ToUpper();
        if (speech.text == correctAnswer)
        {
            Debug.Log($"Correct Answer Recognized: {speech.text}");
            isRiddleFound = true;

            // Find the matching word in the word list
            Word recognizedWord = wordList.Find(word => word.getWordString().ToUpper() == correctAnswer);

            if (recognizedWord != null)
            {
                currentWord = recognizedWord;
                currentIndex = 0;
                ZoomIn(recognizedWord);
                VoiceMovement.enablePlatformRecognition();
            }
            else
            {
                Debug.LogError($"Word '{correctAnswer}' not found in the word list!");
            }
        }

        else{
            cameraScriptObject.ShakeCamera();
        }
    }

    public void SpawnLetters()
    {
    Debug.Log("Spawning Letters");
    wordList.Add(new Word("CAT", Word.Direction.Horizontal, 0, 0));
    wordList.Add(new Word("FIGHT", Word.Direction.Horizontal, 3, 0)); 

    wordList.Add(new Word("FUN", Word.Direction.Horizontal, 1, 2)); 

    //wordList.Add(new Word("TCCT", Word.Direction.Vertical, 3,0));
    // wordList.Add(new Word("FUN", Word.Direction.Vertical, 1, 2));
    // wordList.Add(new Word("FUN", Word.Direction.Vertical, 1, 2)); 
    // wordList.Add(new Word("AGN", Word.Direction.Horizontal, 0, 1));
    // wordList.Add(new Word("FTI", Word.Direction.Vertical, 0, 2));
    // wordList.Add(new Word("CUN", Word.Direction.Vertical, 2, 2));
    // wordList.Add(new Word("UGNTF", Word.Direction.Vertical, 4, 0));



        // for (int i = 0; i < wordList.Count; i++)
        // {
        //     for (int j = 0; j < wordList[i].getLetters().Count; j++)
        //     {
        //         char letter = wordList[i].getLetters()[j].getCharacter();
        //         Vector3 coordinates = wordList[i].getLetters()[j].getCoordinates();

        //         GameObject currentAlphabet = System.Array.Find(AlphabetPrefabs, prefab => prefab.name == letter.ToString());

        //         if (currentAlphabet != null)
        //         {
        //             Instantiate(currentAlphabet, coordinates, Quaternion.identity);
        //         }
        //         else
        //         {
        //             Debug.LogError($"Prefab for letter '{letter}' not found!");
        //         }
        //     }
        // }
    }

    public void ZoomIn(Word word)
    {
        Debug.Log("Zooming In on the Word");
        cameraScriptObject.ZoomInToLetter(word);
    }

    public void PanOut()
    {
        Debug.Log("Panning Out to Original Position");
        cameraScriptObject.PanOutToOriginalPosition();

        // Move to the next riddle after panning out
        isRiddleFound = false;
        currentRiddleIndex++;
        StrikeDownCube.SetActive(true);

        if (currentRiddleIndex < riddleData.riddles.Count)
        {
            DisplayRiddle();
        }
        else
        {
            Debug.Log("All riddles completed!");
        }
    }

    public void NextLetter()
    {
    // Check if all letters in the current word are processed
    currentIndex++;


    Debug.Log("Transitioned");
    //Debug.Log("Current Letter" + currentWord.getLetters()[currentIndex].getCharacter());


    // if (currentIndex + 1 > currentWord.getLetters().Count)
    // {
    //     Debug.Log("All letters found");
    //     PanOut();
    //     return;
    // }

    //Debug.Log("Next Letter");

    // Get row and column numbers of the next letter
    int rowNumberOfcurrentLetter = currentWord.getLetters()[currentIndex].getRowNumber();

   // Debug.Log("Row Number of current letter: " + rowNumberOfcurrentLetter);
    int colNumberOfcurrentLetter = currentWord.getLetters()[currentIndex].getColNumber();

    //Debug.Log("Column Number of current letter: " + colNumberOfcurrentLetter);

    // Find the matching coordinate in coordinatesData
    Coordinates nextCoordinates = coordinatesData.coordinates.Find(coordinate => 
        coordinate.matrixCoordinates[0] == rowNumberOfcurrentLetter && 
        coordinate.matrixCoordinates[1] == colNumberOfcurrentLetter);


    if (nextCoordinates != null)
    {
        // Pass the world coordinates to the camera script
    //Debug.Log("Next Coordinates: " + nextCoordinates.worldCoordinates);

        Vector3 nextPosition = nextCoordinates.worldCoordinates;
        cameraScriptObject.NextLetterTransition(nextPosition);
    }
    else
    {
        Debug.LogError("No matching coordinates found for the current letter!");
    }
}

}
