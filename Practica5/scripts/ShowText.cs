using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    GameObject player;

    void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnEnable()
    {
        DictationScript.DictationDone += DisplayDictation;
    }

    void OnDisable()
    {
        DictationScript.DictationDone -= DisplayDictation;
    }

    void DisplayDictation(string text) {
        if (floatingTextPrefab) {
            var NewText = Instantiate(floatingTextPrefab, transform);
            NewText.GetComponent<TextMesh>().text = text;
        }
    }
}
