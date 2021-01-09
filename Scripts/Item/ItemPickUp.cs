using UnityEngine;

public class ItemPickUp : Interactable
{
	public Item item;
	
	public override void Interact(){
		base.Interact();
		
		PickUp();
		
	}
	
	void PickUp(){
		Debug.Log("Picking Up " + item.name);
		//add to inventory
		bool isComplete = Inventory.instance.Add(item);
		if(isComplete){
			Destroy(gameObject);
		}
		
	}
	
}
