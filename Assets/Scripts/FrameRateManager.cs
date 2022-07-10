using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateManager : MonoBehaviour
{
    public int targetWidth;
    public int targetHeight;
    public int targetFps = 30;
    public bool fullscreen = false;
    private void Awake()
    {
        Application.targetFrameRate = targetFps;
        Screen.SetResolution(targetWidth, targetHeight, fullscreen);

    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFps;
        Screen.SetResolution(targetWidth, targetHeight, fullscreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
