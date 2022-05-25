using UnityEngine;
using Interfaces;

public class IndicatorLights : MonoBehaviour
{
    public GameObject[] triggers;

    public GameObject[] indicatorLights;


    void Update()
    {
        int numTriggered = 0;

        for (int i = 0; i < triggers.Length; i++)
        {
            TriggerInterface triggerScript = triggers[i].GetComponent(typeof(TriggerInterface)) as TriggerInterface;
            if (triggerScript.getIsTriggered())
            {
                numTriggered++;
            }
        }

        for (int i = 0; i < indicatorLights.Length; i++)
        {
            indicatorLights[i].GetComponent<Light>().color = Color.red;
        }


        if (numTriggered <= triggers.Length)
        {
            for (int i = 0; i < numTriggered; i++)
            {
                indicatorLights[i].GetComponent<Light>().color = Color.green;
            }
        }
    }
}