using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    StoryKeeper SK;

    void Awake()
    {
        SK = StoryKeeper.Instance;
    }

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
