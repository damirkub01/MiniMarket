using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlaceZone : MonoBehaviour
{
    public BoundsInt dropBounds;
    public Transform orig;
    public float dist = 1;

    private PickUpItem Hand;
    public int maxCount => maxCount;
    public float distance => dist;
    public Transform origin => orig;
    public BoundsInt bounds => dropBounds;


    public void Place()
    {
 
    }
}
