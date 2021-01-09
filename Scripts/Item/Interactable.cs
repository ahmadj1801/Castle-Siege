using UnityEngine;

public class Interactable : MonoBehaviour
{
	public float radius = 3f;
	
	public virtual void Interact(){}
	
	bool isFocus = false;
	bool hasInteracted = false;
	Transform player;
	
	void Update(){
		if(isFocus && !hasInteracted){
			float distance = Vector3.Distance(player.position, transform.position);
			if(distance <= radius){
				Debug.Log("INTERACT");
				Interact();
				hasInteracted = true;
			}
		}
	}
	
	public void OnFocused(Transform playerTransform){
		isFocus = true;
		player = playerTransform;
		hasInteracted =false;
	}
	
	public void OnDefocused(){
		isFocus = false;
		player = null;
		hasInteracted =false;
	}
	
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
