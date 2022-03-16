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
        if (false == GameManager.instance.IsGameOver && GameManager.instance.IsStun == false)
        {
#if (UNITY_EDITOR || UNITY_STANDALONE_WIN)
            if (Input.GetMouseButtonDown(0) && IsButtonClicked())
            {
                _target.OnButtonDown();
            }
            else if (Input.GetMouseButtonUp(0) && _target != null)
            {
                _target.OnButtonUp();
            }
#endif

#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if ((touch.phase == TouchPhase.Began) && IsButtonClicked())
                {
                    _target.OnButtonDown();
                }
                else if ((touch.phase == TouchPhase.Ended) && _target != null)
                {
                    _target.OnButtonUp();
                }
            }
#endif
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