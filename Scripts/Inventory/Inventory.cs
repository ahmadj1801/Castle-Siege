using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	
	#region Singleton
	
	public static Inventory instance;
	
	void Awake(){
		if(instance != null){
			Debug.Log("MOre than one inventory");
			return;
		}
		instance = this;
	}
	#endregion
	
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;
	
	public int space = 4;
	public List<Item> items = new List<Item>();
	
	public bool Add(Item item){
		if(items.Count >= space){
			Debug.Log("Full inventory");
			return false;
		}
		
		items.Add(item);
		if(onItemChangedCallback != null){
			onItemChangedCallback.Invoke();
		}
		
		return true;
	}
	
	public void Remove(Item item){
		bool canRemove = true;
		string[] keynames = {"Gold Key", "Silver Key", "Bronze Key"};
		foreach(string key in keynames){
			if(item.name == key){
				canRemove = false;
				break;
			}
		}
		
		if(canRemove){
			items.Remove(item);
			if(onItemChangedCallback != null){
				onItemChangedCallback.Invoke();
			}
		}else{
			Debug.Log("Cannot Remove Keys");
		}
	}
	
}
