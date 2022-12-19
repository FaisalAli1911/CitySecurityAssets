using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class forcepush : MonoBehaviour
{
    public Transform firepoint;
    public GameObject cube;
    GameObject bullet;
    public float Force = 20f;
    Rigidbody rb;
    public bool fire=false;
    AudioSource gunAudio;
    ParticleSystem gunParticles;
  
    private void Start()
    {
        gunParticles = GetComponent<ParticleSystem>();
       // health=enemy.GetComponent<EnemyHealth>();
        gunAudio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire = true;
            shoot();
         
        }
        else
        {
            fire = false;
        }

      

    }
    void shoot()
    {
        if (fire)
        {
            Debug.Log("This is happening here");
            gunAudio.Play();
           gunParticles.Stop();
            gunParticles.Play();
            bullet = Instantiate(cube, firepoint.position, firepoint.rotation);
            rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firepoint.forward * Force, ForceMode.Impulse);
           
        }   

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
       
        Debug.Log("asdasd");
    }

  
}
   
