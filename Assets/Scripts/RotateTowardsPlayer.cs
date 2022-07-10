using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    public Transform target;
    public float y_offset;


    public bool animate_upDown;
    public float animationSpeed;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        transform.LookAt(target);
        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y + y_offset, 0f);

        if (animate_upDown)
        {
            float y = Mathf.PingPong(Time.time * animationSpeed, 0.5f);
            transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        }
    }
}
