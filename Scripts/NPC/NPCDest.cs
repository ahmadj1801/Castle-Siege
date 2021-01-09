using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDest : MonoBehaviour
{
	public int pivotPoint; //default 0
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "NPC"){
			
			if(pivotPoint == 5){
				pivotPoint = 0;
			}
			
			if(pivotPoint == 4){
				this.gameObject.transform.position = new Vector3(-10, 0, -18);
				pivotPoint = 5;
			}
			
			if(pivotPoint == 3){
				this.gameObject.transform.position = new Vector3(-6, 0, -20);
				pivotPoint = 4;
			}
			
			if(pivotPoint == 2){
				this.gameObject.transform.position = new Vector3(-8, 0, -23);
				pivotPoint = 3;
			}
			
			if(pivotPoint == 1){
				this.gameObject.transform.position = new Vector3(-3, 0, -22);
				pivotPoint = 2;
			}
			
			if(pivotPoint == 0){
				this.gameObject.transform.position = new Vector3(-3, 0, -19);
				pivotPoint = 1;
			}
		}
	}
}
