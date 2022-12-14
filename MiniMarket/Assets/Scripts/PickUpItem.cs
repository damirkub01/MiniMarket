using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private Button _pickUpBtn;
    [SerializeField] private GameObject _camera;

    [HideInInspector]
    public bool onHand;
    public GameObject Item;

    private RaycastHit _hit;
    private float _distance = 5f;
    private GameObject _currentItem;
    private bool _canPickUp = false;

    public GameObject getItem()
    {
        return _currentItem;
    }

    public void PickUp()
    {
        if (_canPickUp) Drop();

        onHand = true;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, _distance))
        {
            onHand = true;
            _currentItem = _hit.transform.gameObject;
            _currentItem.GetComponent<Rigidbody>().isKinematic = true;
            _currentItem.GetComponent<Collider>().isTrigger = true;
            _currentItem.transform.parent = transform;
            _currentItem.transform.rotation = transform.rotation;
            _currentItem.transform.localPosition = new Vector3(0, -0.4f, 0);
            _canPickUp = true;
        }
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