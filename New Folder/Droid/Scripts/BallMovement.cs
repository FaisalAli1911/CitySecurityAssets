using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 6f;
   
    Rigidbody rb;
    int floorMask;
    public GameObject Head;
    float H;
    float V;
   // bool movement;
   

    private void Update()
    {
        Move();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        Head.transform.position = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
       
    }

    private void Move()
    {
        H = Input.GetAxisRaw("Horizontal");
        V = Input.GetAxisRaw("Vertical");

        if (H != 0 || V != 0)
        {
            Vector3 moveDirection = new Vector3(H, 0.0f, V);
            moveDirection = moveDirection.normalized;
            rb.AddForce(moveDirection * speed);
           // movement = true;
        }
        else
        {
          //  movement = false;
        }
       
    }


}