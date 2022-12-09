using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] private Button _pickUpBtn;
    [SerializeField] private Button _dropBtn;
    [SerializeField] private GameObject _camera;

    [HideInInspector]
    public bool onHand;

    private RaycastHit _hit;
    private float _distance = 2f;
    private GameObject _currentItem;
    private bool _canPickUp = false;

    void Update()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, _distance))
        {
            if (_hit.transform.tag == "Pickable" && !onHand)
            {
                _pickUpBtn.gameObject.SetActive(true);
            } else
            {
                _pickUpBtn.gameObject.SetActive(false);
            }
        }

        if (onHand)
        {
            _dropBtn.gameObject.SetActive(true);
        } else
        {
            _dropBtn.gameObject.SetActive(false);
        }
    }

    public void PickUp()
    {
        if (_canPickUp) Drop();

        onHand = true;
        _currentItem = _hit.transform.gameObject;
        _currentItem.GetComponent<Rigidbody>().isKinematic = true;
        _currentItem.GetComponent<Collider>().isTrigger = true;
        _currentItem.transform.parent = transform;
        _currentItem.transform.rotation = transform.rotation;
        _currentItem.transform.localPosition = new Vector3(0, -0.4f, 0);
        _canPickUp = true;
    }

    public void Drop()
    {
        onHand = false;
        _currentItem.transform.parent = null;
        _currentItem.transform.rotation = new Quaternion(0, 0, 0, 0);
        _currentItem.GetComponent<Rigidbody>().isKinematic = false;
        _currentItem.GetComponent<Collider>().isTrigger = false;
        _canPickUp = false;
        _currentItem = null;
    }
}
