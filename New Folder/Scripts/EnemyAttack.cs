using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            anim.SetBool("playerINrange", true);
            Debug.Log("InRAgne");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
                {
            anim.SetBool("playerINrange", true);
            playerInRange = true;
           }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
            anim.SetBool("playerINrange", false);
           // anim.ResetTrigger("playerINrange"); 
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.Health > 0)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {

            anim.SetBool("playerINrange", false);

        }

    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
          //  anim.SetTrigger("playerINrangetrg");
          

        }

        if (playerHealth.currentHealth <= 0)
        {

            playerHealth.isDead= true;
            Debug.Log("Player is Dead");
            
        }
    }
}


   
