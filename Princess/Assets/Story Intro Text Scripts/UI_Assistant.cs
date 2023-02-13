using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Assistant : MonoBehaviour
{
[SerializeField] float speed;
[SerializeField] GameObject textObject;
TextMeshProUGUI txt;
string story;
bool playText = true;

void Awake () 
{
    txt = textObject.GetComponent<TextMeshProUGUI>();
    story = txt.text;
    txt.text = "";
}

void Update() 
{
    if (playText) 
    {
        StartCoroutine ("PlayText");
        playText = false;
    }
}

IEnumerator PlayText()
{
    foreach (char c in story) 
    {
        txt.text += c;
        yield return new WaitForSeconds (speed);
    }
}
}
