using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartNewCampaign()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
