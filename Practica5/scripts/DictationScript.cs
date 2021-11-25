using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

using UnityEngine.Windows.Speech;

public class DictationScript : MonoBehaviour
{
    public delegate void DisplayDictation(string text);
    public static event DisplayDictation DictationDone;

    private DictationRecognizer dictationRecognizer;

    void Start()
    {
        dictationRecognizer = new DictationRecognizer();

        dictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            DictationDone(text);
        };

        dictationRecognizer.DictationComplete += (completionCause) =>
        {   
            if (completionCause != DictationCompletionCause.Complete)
            {
                Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
            } else 
            {
                Debug.Log("Dictation completed successfully");
            }
            dictationRecognizer.Start();
        };

        dictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
            dictationRecognizer.Start();
        };

        dictationRecognizer.Start();
    }
    
    void OnDestroy() 
    {
        dictationRecognizer.Stop();
        dictationRecognizer.Dispose();
    }
}