using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryKeeper : MonoBehaviour
{

    private DatabaseHandler databaseHandler;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");
        databaseHandler = new DatabaseHandler();
    }

}
