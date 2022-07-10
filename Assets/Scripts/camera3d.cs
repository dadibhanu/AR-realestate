using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera3d : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    public float RotationSensitivity = 8f;
    public float distance = 40f;
    public float TouchZoomSpeed = 0.1f;
    public float MouseZoomSpeed = 15f;

    public static float CurrentLerpTime = 0f;
    public float lerpTime = 2f;

    public Transform Target;

    public Vector3 StartCamPosition, EndCamPosition;
    public GameObject arcam;


    private Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        Yaxis = -180f;
        Xaxis = 16f;
        // StartCamPosition = arcam.transform.position;
        transform.position = StartCamPosition;

        Debug.Log("Awake");

    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        }

        // Yaxis += Input.GetAxis("Mouse X") * RotationSensitivity;
        // Xaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;

        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Yaxis += touch.deltaPosition.x * RotationSensitivity;
                Xaxis -= touch.deltaPosition.y * RotationSensitivity;
            }
        }

        Xaxis = Mathf.Clamp(Xaxis, -90f, 90f);

        Vector3 targetRotation = new Vector3(Xaxis, Yaxis);
        transform.eulerAngles = targetRotation;


        //transform.position = Target.position - transform.forward * distance;

        EndCamPosition = Target.position - transform.forward * distance;



        CurrentLerpTime += Time.deltaTime;
        if (CurrentLerpTime >= lerpTime)
        {
            CurrentLerpTime = lerpTime;
        }



        float perc = CurrentLerpTime / lerpTime;
        transform.position = Vector3.Lerp(transform.position, EndCamPosition, perc);







        //pinch to zoom
        if (Input.touchSupported)
        {
            // Pinch to zoom
            if (Input.touchCount == 2)
            {

                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom(deltaDistance, TouchZoomSpeed);
            }
        }
        else
        {

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Zoom(scroll, MouseZoomSpeed);
        }

    }
    void Zoom(float deltaMagnitudeDiff, float speed)
    {

        distance += deltaMagnitudeDiff * speed;

        distance = Mathf.Clamp(distance, 5f, 20f);
    }

    void Touchcontrol()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Yaxis += touch.deltaPosition.x * RotationSensitivity;
                Xaxis -= touch.deltaPosition.y * RotationSensitivity;
            }
        }
    }
}
