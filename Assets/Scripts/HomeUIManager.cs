using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUIManager : MonoBehaviour
{

    public Button[] canvasSelectionButtons;
    public GameObject[] canvas;
    public GameObject HomeCanvas;
    public Button[] backbutton;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Button button in canvasSelectionButtons)
        {
            button.onClick.AddListener(delegate { CanvasButtonPressed(button); });
        }

        foreach (Button button in backbutton)
        {
            button.onClick.AddListener(BackButton);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CanvasButtonPressed(Button button)
    {
        for (int i = 0; i < canvas.Length; i++)
        {
            if (button.gameObject.name == canvas[i].name)
            {
                canvas[i].SetActive(true);
            }
            else
            {
                canvas[i].SetActive(false);
            }
        }
        HomeCanvas.SetActive(false);
    }

    void BackButton()
    {
        for (int i = 0; i < canvas.Length; i++)
        {
         canvas[i].SetActive(false);
          
        }
        HomeCanvas.SetActive(true);

    }
}
