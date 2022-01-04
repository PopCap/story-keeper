using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : AbstractMenu
{

    void Start()
    {
    }

    public void HandleOnStateChange()
    {
    }

    public void StartNewCampaign()
    {
    }

    public void OpenCampaign()
    {
    }

    public void QuitApplication()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
