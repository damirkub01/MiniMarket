using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class MobileInput : MonoBehaviour
{
    [SerializeField] private FixedTouchField _touchField;
    void Update()
    {
        var fps = GetComponent<CharacterControl>();
        fps.SetLookAxis(_touchField.GetTouchDist());

    }
}
