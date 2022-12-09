using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        
        if (Physics.Raycast(transform.position, transform.forward * 10, out RaycastHit hit))
        {
            hit.collider.transform.position = transform.position + new Vector3(0, 0, 2);
            hit.collider.transform.localRotation = transform.rotation;
            hit.collider.gameObject.transform.SetParent(transform);
        }
    }
}
