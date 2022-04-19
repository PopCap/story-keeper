using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : AbstractMenu
{
    void Start()
    {
        // Open Campaign button not interactable if no campaigns in database
        List<AbstractTable> existingCampaigns = SK.databaseHandler.ExecuteQuery(
            new Campaign(),
            "SELECT * FROM CAMPAIGN"
        );
        if (existingCampaigns.Count == 0)
        {
            gameObject.transform.Find("Open Campaign Button")
            .GetComponent<Button>().interactable = false;
            Debug.Log("No existing campaigns");
        }
    }

    public void OpenCampaign()
    {

    }

    public void NewCampaign()
    {

    }

    public void QuitApplication()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
