using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class killme : MonoBehaviour
{
    public GameObject body;
    PlayerHealth health;
   
    // Start is called before the first frame update
    void Start()
    {
        health=body.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = body.transform.position;

        if (health.currentHealth <= 0 || body.transform.position.y<0)
            {  
           
            Destroy(gameObject);
        }
    }


}
