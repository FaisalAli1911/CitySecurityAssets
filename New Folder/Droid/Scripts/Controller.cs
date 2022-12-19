using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float Vertical;
    private float Horizontal;
    private float speed = 1f;
    private Rigidbody rb;
    public bool movement;
    public float camspeed = 400f;
    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if (Horizontal != 0 || Vertical != 0)
        {
            Vector3 moveDirection = new Vector3(Horizontal, 0.0f, Vertical);
            rb.AddForce(moveDirection * speed, ForceMode.Impulse);
            movement = true;
        }
        else
        {
            movement = false;
        }
        if (!movement)
        {
            rb.velocity = new Vector3(0.1f, 0, 0.1f);


        }

    }
}
