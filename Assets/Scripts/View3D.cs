using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class View3D : MonoBehaviour
{
    public GameObject[] Models;
    int Number;
    public GameObject Info;

    private void Awake()
    {
        Number = ObjectSelectionScript.ObjectNo;
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Models[Number], new Vector3(0, 0, 0), Quaternion.identity);
    
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void EnableARView()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
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
