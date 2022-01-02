using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * Singleton application manager script for Story Keeper.
 */
public class StoryKeeper : MonoBehaviour
{

    public static StoryKeeper instance;

    private DatabaseHandler databaseHandler { get; set; }

    private StateMachine stateMachine { get; set; }

    protected StoryKeeper()
    {
    }

    public void OnApplicationQuit()
    {
        instance = null;
    }

    void Awake()
    {
        // databaseHandler instantiation handled in awake because persistent data path not useable in constructor
        InstanceStoryKeeper();
        databaseHandler.DoTheThings();
    }

    private void InstanceStoryKeeper()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            databaseHandler = DatabaseHandler.Instance;
            stateMachine = StateMachine.Instance;
            Debug.Log("Story Keeper Instance Created");
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Incorrect Story Keeper Instance Destroyed");
        }
    }
}
