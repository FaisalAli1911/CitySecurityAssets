using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 100;
    public float sinkSpeed = 5.5f;
    public int scoreValue = 10;

    Animator anim;
    AudioSource enemyAudio;
    //ParticleSystem hitParticles;
    BoxCollider BoxCollider;
    bool isDead=false;
    bool isSinking;
  // public int currentHealth=100;

   

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
       // hitParticles = GetComponentInChildren<ParticleSystem>();
        BoxCollider = GetComponent<BoxCollider>();
        enemyAudio= GetComponent<AudioSource>();
    }


    void Update()
    {
        if (isSinking)
        {
            transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            TakeDamage(10);
            Debug.Log("asdasd");
        }


    }
    public void TakeDamage(int amount)
    {
        if (isDead) 
         return;

        // enemyAudio.Play();

        Health -= amount;

       // hitParticles.transform.position = hitPoint;
       // hitParticles.Play();

        if (Health <= 0)
        {
           isDead=true;
            Death();
        }
    }


    void Death()
    {
        

        BoxCollider.isTrigger = true;

        anim.SetTrigger("Dead");
     
        Debug.Log("enemy is dead");
        enemyAudio.Play();
        StartSinking();        
    }


    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        // GetComponent<Rigidbody>().isKinematic = true;

        transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
       // isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 1f);
    }
}