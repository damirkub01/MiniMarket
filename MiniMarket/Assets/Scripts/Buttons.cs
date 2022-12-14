using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button _pickBtn;
    [SerializeField] private Button _loadBtn;
    [SerializeField] private Camera _camera;
    [SerializeField] private PickUpItem _Hand;

    private float _distance = 10f;

    private void Update()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 2.5f, Color.red);

        RaycastHit _hit;
        if (Physics.Raycast(ray, out _hit, 2.5f))
        {
            if (_hit.transform.CompareTag("Pickable") && !_Hand.onHand)
            {
                _pickBtn.gameObject.SetActive(true);
            }
            else
            {
                _pickBtn.gameObject.SetActive(false);
            }

            if (_hit.transform.CompareTag("Zone") && _Hand.onHand)
            {
                _loadBtn.gameObject.SetActive(true);
            }
            else
            {
                _loadBtn.gameObject.SetActive(false);
            }
        }
    }

}
