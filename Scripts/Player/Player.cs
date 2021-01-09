using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
	public Interactable focus;
	public int maxHealth = 100;
	public int hitDamage = 20;
	int currentHealth;
	public Animator animator;
	Camera cam;
	
	public HealthBar healthBar;
	
	public Transform attackPoint;
	public float attackRange =0.5f;
	public LayerMask enemyLayers;
	
	public GameObject DeathUI;
	

	
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
		cam = Camera.main;
		healthBar.SetMaxHealth(maxHealth);
		
    }

    // Update is called once per frame
    void Update()
    {
		
        if(Input.GetKeyDown(KeyCode.H)){
			Attack();
		}
		
		if(Input.GetMouseButtonDown(0)){
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100)){
				Interactable interactable = hit.collider.GetComponent<Interactable>();
				if(interactable != null){
					SetFocus(interactable);
				}
			}
		}
		
		if(Input.GetMouseButtonDown(1)){
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100)){
				RemoveFocus();
			}
		}
		
    }
	
	void SetFocus(Interactable newFocus){
		if(newFocus != focus){
			if(focus != null){
				focus.OnDefocused();
			}
			focus = newFocus;
		}
		newFocus.OnFocused(transform);
	}
	
	void RemoveFocus(){
		if(focus != null){
			focus.OnDefocused();
		}
		focus = null;
	}
	
	void Attack(){
		//animation
		animator.SetTrigger("attack");
		//detect enemy
		Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
		//damage
		foreach(Collider enemy in hitEnemies){
			Debug.Log("We hit "+ enemy.name);
			enemy.GetComponent<EnemyController>().TakeDamage(hitDamage);
		}
	}
	
	public int getHealth(){
		return currentHealth;
	}
	
	public void increaseHealth(int h){
		if( (currentHealth+h) > 200 ){
			currentHealth = maxHealth;
		}else{
			currentHealth +=h;
		}
		
		UpdateHealthBar(currentHealth);	
	}
	
	public void TakeDamage(int damage){
		currentHealth -= damage;
		if(currentHealth <= 0){
			Die();
		}else{
			animator.SetTrigger("hurt");
		}
		UpdateHealthBar(currentHealth);	
	}
	
	void Die(){
		animator.SetBool("isDead", true);
		StartCoroutine(ShowMenu());
	}
	
	IEnumerator ShowMenu(){
		yield return new WaitForSeconds(2);
		DeathUI.SetActive(true);
		Time.timeScale = 0f;
		FindObjectOfType<AudioManager>().Stop("Theme2");
		FindObjectOfType<AudioManager>().Play("Lose");
	}
	
	void UpdateHealthBar(int health){
		healthBar.SetHealth(health);	
	}
	
	void OnDrawGizmosSelected(){
		if(attackPoint == null)
			return;
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
	
	
}
