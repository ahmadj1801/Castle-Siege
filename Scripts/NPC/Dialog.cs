using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
public TextMeshProUGUI textDisplay;
public string[] sentences;
int index;
public float typingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText(){
		foreach(char letter in sentences[index].ToCharArray()){
			textDisplay.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
	}
}
