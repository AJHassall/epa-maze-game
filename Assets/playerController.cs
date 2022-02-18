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
        bool upKeyDown    = Input.GetKey(KeyCode.W);
        bool rightKeyDown = Input.GetKey(KeyCode.D);
        bool downKeyDown  = Input.GetKey(KeyCode.S);
        bool leftKeyDown  = Input.GetKey(KeyCode.A);

        if (upKeyDown)
        {
            //Walking up and Right
            if(rightKeyDown){
                rb.velocity = new Vector3(speed, speed, 0);
                anim.Play("Walk_Up_Right");
            }
            //Walking up and Left
            else if(leftKeyDown){
                rb.velocity = new Vector3(-speed, speed, 0);
                anim.Play("Walk_Up_Right");
            }
            //Walking Up
            else{
                rb.velocity = new Vector3(0, speed, 0);
                anim.Play("Walk_Up");
            }
        }
        else if (downKeyDown)
        {
            //walking down and right
            if(rightKeyDown){
                rb.velocity = new Vector3(speed, -speed, 0);
                anim.Play("Walk_Down_Right");
            }
            //walk down and left
            else if(leftKeyDown){
                rb.velocity = new Vector3(-speed, -speed, 0);
                anim.Play("Walk_Down_Left");
            }
            //walking Down
            else{
                rb.velocity = new Vector3(0, -speed, 0);
                anim.Play("Walk_Down");
            }
        }

        else if(leftKeyDown){
                rb.velocity = new Vector3(-speed, 0, 0);
                anim.Play("Walk_Left");
        }
        else if(rightKeyDown){
                rb.velocity = new Vector3(speed, 0, 0);
                anim.Play("Walk_Up_Right");
        }
        else{
            anim.Play("idle_0_degrees");
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
