using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGraphics : MonoBehaviour
{
    public AIPath aiPath;
    private Animator anim;
    void Start(){
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        checkRotation();
       
    }

    void checkRotation(){
        float direction =  Angle360(new Vector2(0,1),new Vector2(aiPath.desiredVelocity.x, aiPath.desiredVelocity.y ).normalized);

        int octanct = Mathf.FloorToInt(direction/45);

        switch (octanct)
        {
            case 0:{
                anim.Play("Walk_Up");
            } break;
            case 1:{
              anim.Play("Walk_Up_Left");
            } break;
            case 2:{
                anim.Play("Walk_Left");
            } break;
            case 3:{
                anim.Play("Walk_Down_Left");
            } break;
            case 4:{
                anim.Play("Walk_Down");
            } break;
            case 5:{
                anim.Play("Walk_Down_Right");
            } break;
            case 6:{
                anim.Play("Walk_Right");
            } break;
            case 7:{
                anim.Play("Walk_Up_Left");
            } break;
            case 8:{
                anim.Play("Walk_Up");
            } break;
            default: break;
        }


    }

     public static float Angle360(Vector2 p1, Vector2 p2, Vector2 o = default(Vector2))
    {
        Vector2 v1, v2;
        if (o == default(Vector2))
        {
            v1 = p1.normalized;
            v2 = p2.normalized;
        }
        else
        {
            v1 = (p1 - o).normalized;
            v2 = (p2 - o).normalized;
        }
        float angle = Vector2.Angle(v1, v2);
        return Mathf.Sign(Vector3.Cross(v1, v2).z) < 0 ? (360 - angle) % 360 : angle;
    }
}
