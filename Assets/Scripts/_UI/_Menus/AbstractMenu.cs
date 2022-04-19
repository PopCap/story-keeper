using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class AbstractMenu : MonoBehaviour
{
    protected StoryKeeper SK;

    void Awake()
    {
        SK = StoryKeeper.instance;
    }

    protected bool ValidateObjectsNotNull(GameObject[] objects)
    {
        bool isValid = false;
        // index is used because gameObject wont have a name for debug if null
        int index = 0;

        foreach (GameObject gameObject in objects)
        {
            if (gameObject == null)
            {
                Debug.Log("GameObject at index " + index + " is null");
                return isValid;
            }
            index++;
        }

        isValid = true;
        return isValid;
    }
    protected bool ValidateInputsNotEmpty(TMP_InputField[] inputs)
    {
        bool isValid = false;
        // index is used because input wont have a name for debug if null
        int index = 0;

        foreach(TMP_InputField input in inputs)
        {
            if (input == null)
            {
                Debug.Log("InputField at index " + index + " is null");
                return isValid;
            }
            index++;
        }

        foreach(TMP_InputField input in inputs)
        {
            if (string.IsNullOrEmpty(input.text))
            {
                Debug.Log("InputField: " + input.name + " is null or empty");
                return isValid;
            }

            if (string.IsNullOrWhiteSpace(input.text))
            {
                Debug.Log("InputField: " + input.name + " is null or whitespace");
                return isValid;
            }
        }

        isValid = true;
        return isValid;
    }

    public void OnClickTransition(GameObject targetTransition)
    {
        targetTransition.SetActive(true);
        gameObject.SetActive(false);
    }

    public virtual void ConditionalOnClickTransition(GameObject targetTransition)
    {
        OnClickTransition(targetTransition);
    }
}
