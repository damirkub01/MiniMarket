using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button _dropBtn;
    [SerializeField] private Button _loadBtn;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _bin;
    [SerializeField] private GameObject _places;
    [SerializeField] private PickUpItem _Hand;

    private float _distance = 10f;
    private RaycastHit hit;

    private void Update()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit _hit, _distance))
        {
            if (_hit.transform.tag == "Zone" && _Hand.onHand && _bin.transform.childCount > 0)
            {
                _loadBtn.gameObject.SetActive(true);
            } else
            {
                _loadBtn.gameObject.SetActive(false);
            }
        } else
        {
            _loadBtn.gameObject.SetActive(false);
        }
    }

    public void Fill()
    {
        for (int i = 0; i < _places.transform.childCount; i++)
        {
            _bin.transform.GetChild(i).gameObject.transform.position = _places.transform.GetChild(i).gameObject.transform.position;
        }

        _bin.transform.DetachChildren();
    }

}
