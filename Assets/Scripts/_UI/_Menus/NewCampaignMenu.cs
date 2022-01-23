using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewCampaignMenu : AbstractMenu
{
    public void StartNewCampaign()
    {
        GameObject campaignNameObject = transform.Find("Campaign Name Input").gameObject;
        GameObject dmNameObject = transform.Find("DM Name Input").gameObject;

        if (!ValidateObjectsNotNull(new GameObject[] { campaignNameObject, dmNameObject }))
        {
            return;
        }

        TMP_InputField campaignNameInput = campaignNameObject.GetComponent<TMP_InputField>();
        TMP_InputField dmNameInput = dmNameObject.GetComponent<TMP_InputField>();


        if (!ValidateInputsNotEmpty(new TMP_InputField[] { campaignNameInput, dmNameInput }))
        {
            return;
        }

        DatabaseHandler databaseHandler = SK.databaseHandler;
        Campaign newCampaign = new Campaign();
        databaseHandler.ExecuteNonQuery(
            newCampaign.InsertRow(new List<string>() {
                campaignNameInput.text,
                dmNameInput.text
            })
        );
    }
}
