using UnityEngine;


public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speedX = 2;
    float speedY;
    private Animator anim;
    public Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        speedY = speedX / 2;
    }
    bool AnimatorIsPlaying(){
     return anim.GetCurrentAnimatorStateInfo(0).length >
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    private bool AnimatorIsPlaying(string stateName){
        return AnimatorIsPlaying() && anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
    private void doPlayerMovement()
    {
        bool upKeyDown = Input.GetKey(KeyCode.W);
        bool rightKeyDown = Input.GetKey(KeyCode.D);
        bool downKeyDown = Input.GetKey(KeyCode.S);
        bool leftKeyDown = Input.GetKey(KeyCode.A);

        if (Input.GetMouseButton(0))
        {
            anim.Play("Attack");
        }

        if (upKeyDown)
        {
            //Walking up and Right
            if (rightKeyDown)
            {
                rb.velocity = new Vector3(speedX, speedY, 0);
                anim.Play("Walk_Up_Right");
            }
            //Walking up and Left
            else if (leftKeyDown)
            {
                rb.velocity = new Vector3(-speedX, speedY, 0);
                anim.Play("Walk_Up_Left");
            }
            //Walking Up
            else
            {
                rb.velocity = new Vector3(0, speedY, 0);
                anim.Play("Walk_Up");
            }
        }
        else if (downKeyDown)
        {
            //walking down and right
            if (rightKeyDown)
            {
                rb.velocity = new Vector3(speedX, -speedY, 0);
                anim.Play("Walk_Down_Right");
            }
            //walk down and left
            else if (leftKeyDown)
            {
                rb.velocity = new Vector3(-speedX, -speedY, 0);
                anim.Play("Walk_Down_Left");
            }
            //walking Down
            else
            {
                rb.velocity = new Vector3(0, -speedY, 0);
                anim.Play("Walk_Down");
            }
        }

        else if (leftKeyDown)
        {
            rb.velocity = new Vector3(-speedX, 0, 0);
            anim.Play("Walk_Left");
        }
        else if (rightKeyDown)
        {
            rb.velocity = new Vector3(speedX, 0, 0);
            anim.Play("Walk_Right");
        }
        else if(!AnimatorIsPlaying("Attack"))
        {
            anim.Play("idle_0_degrees");
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

   // Update is called once per frame
    void Update()
    {
        doPlayerMovement();
    }
}
