using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserInput : MonoBehaviour
{
    Camera _mainCam = null;

    private Button _target;
    private Vector3 _mousePos;


    void Awake()
    {
        _mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsButtonClicked())
        {
            _target.OnButtonDown();
        }
        else if (Input.GetMouseButtonUp(0) && _target != null)
        {
            _target.OnButtonUp();
        }
    }

    private bool IsButtonClicked()
    {
        if (_mainCam != null)
        {
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;

            if (Physics.Raycast(ray.origin, ray.direction * 10, out _hit))
            {
                _target = _hit.collider.gameObject.GetComponent<Button>();
                if (_target != null)
                {
                    return true;
                }
            }
        }

        return false;
    }
}