using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStopTrigger : MonoBehaviour
{
    public bool isStartTrigger;
    public bool isFinishTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (isFinishTrigger)
        {
            GameObject.Find("Player").SendMessage("Finnish");
        }
        else
        {
            GameObject.Find("Player").SendMessage("StartTimer");
        }
    }
}
