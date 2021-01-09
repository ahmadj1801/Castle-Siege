using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	
	public float lookRadius = 5f;
	Transform target;
	NavMeshAgent agent;
	public Animator animator;
	public int maxHealth = 100;
	int currentHealth;
	
	public int hitDamage = 10;
	public Transform attackPoint;
	public float attackRange =0.5f;
	public LayerMask enemyLayers;
	
	public string enemyName = "Enemy";
	public GameObject panel;
	
    // Start is called before the first frame update
    void Start()
    {
		target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
		currentHealth = maxHealth;
		if(panel == null ){
			return;
		}
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
		if( distance <= lookRadius ){
			
			agent.SetDestination(target.position);
			animator.SetBool("isChasing", true);
			
			if(distance <= agent.stoppingDistance){
				FaceTarget();
				animator.SetBool("isChasing", false);
				StartCoroutine(Attack());
				//Attack();
			}
			
		}else{
			animator.SetBool("isChasing", false);
			//animator.SetBool("isAttacking", false);
		}
		animator.SetBool("isAttacking", false);
    }
	
	void FaceTarget(){
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
	
	public void TakeDamage(int damage){
		animator.SetTrigger("hurt");
		currentHealth -=damage;
		if(currentHealth<=0){
			Die();
		}
		
	}
	
	IEnumerator Attack(){
		yield return new WaitForSeconds(0.4f);
		//animation
		//animator.SetBool("isAttacking", true);
		animator.SetTrigger("attack");
		
		//detect enemy
		Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
		
		
		//damage
		foreach(Collider enemy in hitEnemies){
			Debug.Log("We hit "+ enemy.name);
			enemy.GetComponent<Player>().TakeDamage(hitDamage);
		}
		
		
	}
	
	void Die(){
		animator.SetBool("isDead", true);
		StartCoroutine(RemoveFromScene());
	}
	
	IEnumerator RemoveFromScene(){
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
		if(enemyName =="King"){
			//Show End Game Panel
			FindObjectOfType<AudioManager>().Stop("Theme2");
			FindObjectOfType<AudioManager>().Play("Win");
			panel.SetActive(true);
			Time.timeScale = 0f;
		}
	}
	
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
