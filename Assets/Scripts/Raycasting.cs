using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Raycasting : MonoBehaviour
{

    public GameObject placementMarkerGameobject;
    public Vector3 markerRotationOffSet;
    public GameObject[] realGameObject;
    public Vector3 realobjRotationOffSet;

    public Text title;
    public Text info;
    public Text price;
    public GameObject LandingPage;

    private GameObject marker;
    private GameObject spawnedObject;
   
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public int assetno=0;

 
    private void Awake()
    {
        aRRaycastManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
        aRPlaneManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();

        assetno = ObjectSelectionScript.ObjectNo;
    }

    private void Start()
    {
        FindObjectOfType<Save>().RealObjectStatus(false);
        
    }


    void Update()
    {
        if (Save.realobjectspawned == false)
        {
            SetAllPlanes(true);

            foreach (Touch touch in Input.touches)
            {
                int id = touch.fingerId;
                if (EventSystem.current.IsPointerOverGameObject(id))
                {
                    // ui touched
                    return;
                }
            }


            if (aRRaycastManager.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;

                if (marker == null)
                {
                    marker = Instantiate(placementMarkerGameobject, hitPose.position, hitPose.rotation);
                    LandingPage.SetActive(false);
                    marker.transform.eulerAngles = new Vector3(marker.transform.rotation.x + markerRotationOffSet.x, marker.transform.rotation.y + markerRotationOffSet.y, marker.transform.rotation.z + markerRotationOffSet.z);
                }
                else
                {
                    marker.transform.position = hitPose.position;

                    //Enable Real Game Object on touch and Disable Marker
                    if (Input.GetMouseButtonDown(0))
                    {
                        marker.SetActive(false);

                        if (spawnedObject == null)
                        {
                            spawnedObject = Instantiate(realGameObject[assetno], hitPose.position, hitPose.rotation);
                            spawnedObject.transform.eulerAngles = new Vector3(spawnedObject.transform.rotation.x + realobjRotationOffSet.x, spawnedObject.transform.rotation.y + realobjRotationOffSet.y, spawnedObject.transform.rotation.z + realobjRotationOffSet.z);
                            FindObjectOfType<Save>().RealObjectStatus(true);
                            SetAllPlanes(false);
                            aRPlaneManager.enabled = false;
                        }

                    }
                }
            }
        }
    }

    //Enable Disable Planes
    void SetAllPlanes(bool value)
    {
        foreach (var plane in aRPlaneManager.trackables)
            plane.gameObject.SetActive(value);
    }

    public void ResetButtonPressed()
    {
        Debug.Log("Reset");
        FindObjectOfType<Save>().RealObjectStatus(false);
        aRPlaneManager.enabled = true;
        Destroy(spawnedObject);
        Destroy(marker);
    }

}
