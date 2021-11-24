using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * Singleton application manager script for Story Keeper.
 */
public class StoryKeeper : MonoBehaviour
{

    public static StoryKeeper Instance;

    private DatabaseHandler databaseHandler { get; set; }

    protected StoryKeeper()
    {
    }

    public void OnApplicationQuit()
    {
        Instance = null;
    }

    void Awake()
    {
        // databaseHandler instantiation handled in awake because persistent data path not useable in constructor
        InstanceStoryKeeper();
        databaseHandler.DoTheThings();
    }

    private void InstanceStoryKeeper()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            databaseHandler = DatabaseHandler.Instance;
            Debug.Log("Story Keeper Instance Created");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Incorrect Story Keeper Instance Destroyed");
        }
    }
}
