using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_controller : MonoBehaviour
{
    public GameObject resetButton;
    public GameObject HomeButton;
    public GameObject Button3D;
    public GameObject Info;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Save.realobjectspawned==true)
        {
            resetButton.SetActive(true);
            HomeButton.SetActive(false);
        }
        else
        {
            resetButton.SetActive(false);
            HomeButton.SetActive(true);
        }

    }

    public void Home()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Single);
    }

    public void Enable3DView()
    {
        Debug.Log("3d");
        SceneManager.LoadScene("3DViewer", LoadSceneMode.Single);
    }
    public void info()
    {
            Info.SetActive(true);
    }
    public void back()
    {
        Info.SetActive(false);
    }
}
