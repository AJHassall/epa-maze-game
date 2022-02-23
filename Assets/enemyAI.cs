using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private int health = 3;
    //public GameObject map;
    // Start is called before the first frame update

    void TakeDamage(){
        if(--health < 1)
            Die();
    } 

    private void Die(){
        GameObject o = GameObject.FindGameObjectsWithTag("Map")[0];
        GameObject.FindGameObjectsWithTag("Map")[0].BroadcastMessage("RoomCleared");
        Object.Destroy(this.transform.gameObject);
    }
}
