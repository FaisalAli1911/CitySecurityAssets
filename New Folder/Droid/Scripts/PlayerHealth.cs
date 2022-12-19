using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public bool isDead;
    public GameObject deathfx;
    AudioSource playerAudio;
    BallMovement BallMovement;
    Aimming Aimming;   
    public bool damaged;
    public int currentHealth;

   // public int CurrentHealth { get { return currentHealth; } }

    void Awake()
    {
       
        playerAudio = GetComponent<AudioSource>();
        BallMovement = GetComponent<BallMovement>();
        Aimming = GetComponentInChildren<Aimming>();
        currentHealth = startingHealth;
    }


    void Update()
    {
        
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

         //playerAudio.Play();

          if (currentHealth <= 0)
          {
            Instantiate(deathfx,transform.position,transform.rotation);
            //Death();
          }

      
   }


    void Death()
    {
       // isDead = true;

        // Aimming.DisableEffects();

        // anim.SetTrigger("Die");

        //  playerAudio.clip = deathClip;
     
       // BallMovement.enabled = false;
        //Aimming.enabled = false;
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}