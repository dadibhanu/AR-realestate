using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectSelectionScript : MonoBehaviour
{
    public static int ObjectNo;

    public Button[] ObjectButton;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Button button in ObjectButton)
        {
            button.onClick.AddListener(delegate { objectbuttonpressed(button); });
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void objectbuttonpressed(Button button)
    {
        ObjectNo = int.Parse(button.gameObject.name);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

    }
}
