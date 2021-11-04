using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnBCollision : MonoBehaviour
{
    public Text text;
    void OnEnable()
    {
        GameManager.OnBCollision += AddText;
    }


    void OnDisable()
    {
        GameManager.OnBCollision -= AddText;
    }


    void AddText()
    {
        if (text != null) 
        {
            if (text.text.Split('\n').Length == 6) {
                List<string> new_text = new List<string>(text.text.Split('\n'));
                new_text.RemoveAt(1);
                text.text = string.Join("\n", new_text);
            }
            text.text += $"{name}: Don't touch my friend!\n";
        }
    }    
}
