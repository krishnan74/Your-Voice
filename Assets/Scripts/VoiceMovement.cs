VoiceMovement.cs//
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private KeywordRecognizer platformKeywordRecognizer;

    private bool platformerStart = false;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    void Start()
    {
        actions.Add("move", Forward);
        actions.Add("come back", Backward);
        actions.Add("run", Forward);
        actions.Add("turn left", Left);
        actions.Add("turn right", Right);

        platformKeywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        platformKeywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        
    }

    void Update(){
        if( platformerStart) { 
            platformKeywordRecognizer.Start();
        }
        else {
            platformKeywordRecognizer.Stop();
        }
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log("Text: " + speech.text +", Confidence: " + speech.confidence);
        actions[speech.text].Invoke();
    }

    
    private void Forward()
    {
        transform.Translate(Vector3.forward);
    }

    private void Backward()
    {
        transform.Translate(Vector3.back);
    }


    private void Left()
    {
        transform.Translate(Vector3.left);
    }

    private void Right()
    {
        transform.Translate(Vector3.right);
    }
    
}
