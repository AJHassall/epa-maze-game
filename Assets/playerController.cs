using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed = 2;
    private Animator anim;
    public Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-speed, 0, 0);
            anim.Play("Walk_Left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
              rb.velocity = new Vector3(speed, 0, 0);
            anim.Play("Walk_Right");
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
              rb.velocity = new Vector3(0, speed, 0);
            anim.Play("Walk_Up");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, -speed, 0);
            anim.Play("Walk_Down");
        }
        
        else{
            anim.Play("idle_0_degrees");
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
