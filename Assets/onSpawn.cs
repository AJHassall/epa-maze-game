using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class onSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Transform tf;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        this.target = GameObject.FindWithTag("Player").transform;
    }
}
