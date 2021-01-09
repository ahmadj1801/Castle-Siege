using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Talk : Interactable
{
	public TextMeshProUGUI textDisplay;
	public GameObject panel;
	public string sentences;
	public float typingSpeed;
	
	
	public override void Interact(){
		base.Interact();
		panel.SetActive(true);
		StartCoroutine(Speak());
		
	}
	
	IEnumerator Speak(){
		foreach(char letter in 	sentences.ToCharArray()){
			textDisplay.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
		yield return new WaitForSeconds(2);
		textDisplay.text = "";
		panel.SetActive(false);
	}
	
}
