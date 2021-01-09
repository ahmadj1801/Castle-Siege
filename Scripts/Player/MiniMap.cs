using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
	Transform player ;
	
	void LateUpdate(){
		player = PlayerManager.instance.player.transform;
		
		Vector3 newPosition = player.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;
		
		transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
	}
}
