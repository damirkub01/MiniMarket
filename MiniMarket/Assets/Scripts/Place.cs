using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    private bool isEmpty = true;

    public bool IsEmpty() { 
        if (gameObject.transform.childCount > 0) { 
            isEmpty = false; 
        } else
        {
            isEmpty = true;
        }

        return isEmpty;
    }
    public void SetEmpty(bool c) { isEmpty = c; }
}
