using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
	Inventory inventory;
	public Transform itemsParent;
	InventorySlot[] slots;
	public GameObject inventoryUI;
	
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
    }
	
	void UpdateUI(){
		Debug.Log("Updating UI");
		for(int i=0; i< slots.Length; i++){
			if(i<inventory.items.Count){
				slots[i].AddItem(inventory.items[i]);
			}else{
				slots[i].ClearSlot();
			}
		}
	}
}
