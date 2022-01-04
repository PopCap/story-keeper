using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMenu : MonoBehaviour
{
    protected StoryKeeper SK;

    void Awake()
    {
        SK = StoryKeeper.instance;
    }

    public bool ValidateInputNotEmpty(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }
        return true;
    }
}
