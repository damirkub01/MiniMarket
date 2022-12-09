using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private Button _pickUpBtn;
    [SerializeField] private Button _dropBtn;
    [SerializeField] private GameObject _camera;

    [HideInInspector]
    public bool onHand;

    private RaycastHit _hit;
    private float _distance = 5f;
    private GameObject _currentItem;
    private bool _canPickUp = false;

    void Update()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit _hit, _distance))
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward, Color.red);
            if (_hit.transform.tag == "Pickable" && !onHand)
            {
                _pickUpBtn.gameObject.SetActive(true);
            }
            else
            {
                _pickUpBtn.gameObject.SetActive(false);
            }
        } else
        {
            _pickUpBtn.gameObject.SetActive(false);
        }

        if (onHand)
        {
            _dropBtn.gameObject.SetActive(true);
        }
        else
        {
            _dropBtn.gameObject.SetActive(false);
        }
    }

    public void PickUp()
    {
        if (_canPickUp) Drop();

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