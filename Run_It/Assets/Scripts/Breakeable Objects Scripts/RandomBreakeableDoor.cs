using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBreakeableDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // i search for all childrens in my object
        BoxCollider[] allChildrens = this.GetComponentsInChildren<BoxCollider>();

        // save the parent's childs count
        int objectToDisabled = (int)Random.Range(0, allChildrens.Length);
        allChildrens[objectToDisabled].enabled = false;
    }
}
