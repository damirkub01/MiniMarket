using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    [SerializeField]
    private BoundsInt dropBounds;
    [SerializeField]
    private float dist = 1;
    [SerializeField]
    private Transform orig;

    public void DropByTime(Item[] items, float time)
    {
        StartCoroutine(Drop(items, time));
    }

    public IEnumerator Drop(Item[] items, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        int k = 0;
        while (k < items.Length)
        {
            for (int i = dropBounds.min.x; i < dropBounds.max.x && k < items.Length; i++)
            {
                for (int j = dropBounds.min.z; j < dropBounds.max.z && k < items.Length; j++)
                {
                    Instantiate(items[k].Prefab, orig.position + Vector3.forward * i * dist + Vector3.right * j * dist, Quaternion.identity);
                    k++;
                }
            }
        }
    }

    public void Drop(Item[] items)
    {
        int k = 0;
        while (k < items.Length)
        {
            for (int i = dropBounds.min.x; i < dropBounds.max.x; i++)
            {
                for (int j = dropBounds.min.z; j < dropBounds.max.z; j++)
                {
                    Instantiate(items[k].Prefab, orig.position + Vector3.forward * i * dist + Vector3.right * j * dist, Quaternion.identity);
                    k++;
                    if (k >= items.Length)
                    {
                        return;
                    }
                }
            }
        }
        Debug.Break();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        for(int i = dropBounds.min.x; i < dropBounds.max.x; i++)
        {
            for(int j = dropBounds.min.z; j < dropBounds.max.z; j++)
            {
                Gizmos.DrawCube(orig.position + Vector3.forward * i * dist + Vector3.right * j * dist, Vector3.one / 4);
            }
        }
    }
}
