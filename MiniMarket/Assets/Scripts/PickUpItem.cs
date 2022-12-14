using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private Button _pickUpBtn;
    [SerializeField] private GameObject _camera;

    [HideInInspector]
    public bool onHand = false;

    private GameObject _currentItem;
    private PlaceZone zone;

    private RaycastHit _hit;
    private float _distance = 5f;

    public void PickUp()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, _distance))
        {
            onHand = true;
            _currentItem = _hit.transform.gameObject;
            _currentItem.GetComponent<Rigidbody>().isKinematic = true;
            _currentItem.GetComponent<Collider>().isTrigger = true;
            _currentItem.transform.parent = transform;
            _currentItem.transform.rotation = transform.rotation;
            _currentItem.transform.localPosition = new Vector3(0, -0.4f, 0);
        }
    }

    public void Fill()
    {
        onHand = false;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, _distance))
        {
            if (_hit.transform.CompareTag("Zone"))
            {
                for (int i = 0; i < _hit.transform.childCount; i++)
                {
                    if (_hit.transform.gameObject.transform.GetChild(i).GetComponent<Place>().IsEmpty())
                    {
                        _hit.transform.GetChild(i).GetComponent<Place>().SetEmpty(false);
                        _currentItem.transform.position = _hit.transform.GetChild(i).position;
                        _currentItem.transform.rotation = _hit.transform.GetChild(i).rotation;
                        _currentItem.transform.SetParent(_hit.transform.GetChild(i).transform);
                        break;
                    }
                }
            }
        }
    }
}