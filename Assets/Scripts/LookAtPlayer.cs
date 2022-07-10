using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{ public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform offset = player.transform;
        
        transform.LookAt(offset);
      
    }
}
