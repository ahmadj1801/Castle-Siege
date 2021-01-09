using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointNPC : MonoBehaviour
{
    public int pivotPoint;

	public int x1,x2,y1,y2,z1,z2;
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "NPC"){
			
			if(pivotPoint == 2){
				pivotPoint = 0;
			}
			
			if(pivotPoint == 1){
				this.gameObject.transform.position = new Vector3( x2, y2, z2);
				pivotPoint = 2;
			}
			
			if(pivotPoint == 0){
				this.gameObject.transform.position = new Vector3(x1, y1, z1);
				pivotPoint = 1;
			}
			
		}
	}
}
