using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    // Start is called before the first frame update

    private bool m_Clicked = false;

    [SerializeField]
    float range;
    void Start()
    {
        
    }

    bool CheckWithinRange(){

        var player = GameObject.FindGameObjectsWithTag("Player")[0];
        var enemy  = GameObject.FindGameObjectsWithTag("Enemy")[0];
        float distance = Vector3.Distance (player.transform.position, enemy.transform.position);

        return distance < range;

    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
        if(hit.collider != null && Input.GetMouseButton(0) && !m_Clicked)
        {
            Debug.Log ("Target Position: " + hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "Enemy" && CheckWithinRange())
            {
                hit.transform.gameObject.BroadcastMessage("TakeDamage");

            }
            m_Clicked = true;
        }
        else if (!Input.GetMouseButton(0)){
            m_Clicked = false;
        }
    }
}
