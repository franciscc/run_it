using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBreakeableTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // i search for all childrens in my object
        BoxCollider[] allChildrens = this.GetComponentsInChildren<BoxCollider>();

        foreach (var item in allChildrens)
        {
            if ((int)Random.Range(0, 5) <= 1)
            {
                item.enabled = false;
            }
        }
    }
}
