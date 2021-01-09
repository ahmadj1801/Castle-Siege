using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armour", menuName = "Inventory/Armour")]
public class Armour : Item
{
	
	public int shield = 40;
	
	public override bool Use(){
		base.Use();
		Player player = PlayerManager.instance.player.GetComponent<Player>();
		int currentHealth = player.getHealth();
		if(currentHealth < player.maxHealth){
			player.increaseHealth(shield);
			return true;
		}
		return false;
		
	}
}
