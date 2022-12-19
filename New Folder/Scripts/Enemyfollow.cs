using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemyfollow : MonoBehaviour
{
    GameObject Player;
    NavMeshAgent nav;
    PlayerHealth Nav;
    public Vector3 Rotate;
    // Start is called before the first frame update
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        Player=GameObject.Find("/Full working Droid/body_low004");
        Nav=Player.GetComponent<PlayerHealth>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Nav.currentHealth > 0)
        {
            nav.destination = Player.transform.position;
        }
        
    }
}
