using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
	Inventory inventory;
	
	public string[] keyNames = {"Gold Key", "Silver Key", "Bronze Key"};
	public string sentence = "Collect More Keys To Open The Castle Door.";
	public TextMeshProUGUI textDisplay;
	public GameObject panel;
	
	void Start(){
		inventory = Inventory.instance;
	}
	
    public override void Interact(){
		
		base.Interact();
		
		//Need to check if we have all 3 keys in our inventory
		int countKeys = 0;
		
		foreach(Item item in inventory.items){
			foreach(string sName in keyNames){
				if(item.name == sName){
					countKeys++;
				}
			}
		}
		
		//load next scene
		panel.SetActive(true);
		if( countKeys == 3 ){
			StartCoroutine(NextLevel());	
		}else{
			StartCoroutine(Message());	
		}
	}
	
	IEnumerator Message(){
		textDisplay.text = sentence;
		yield return new WaitForSeconds(4);
		textDisplay.text = "";
		panel.SetActive(false);
	}
	
	IEnumerator NextLevel(){
		textDisplay.text = "Loading Next Level...";
		yield return new WaitForSeconds(4);
		textDisplay.text = "";
		panel.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
}
