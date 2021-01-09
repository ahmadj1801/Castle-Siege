using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
	new public string name = "New Item";
	public Sprite icon = null;
	
	public virtual bool Use(){
		//do something
		Debug.Log("Using " + name);
		return false;
	}
}
