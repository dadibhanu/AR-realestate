using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTimer : MonoBehaviour
{
    public GameObject[] objs;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DisableObj", 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableObj()
    {
        foreach(GameObject obj in objs)
        {
            obj.SetActive(false);
        }
    }
}
