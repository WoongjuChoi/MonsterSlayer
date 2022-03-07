using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;
    void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(PlayerAnimParameter.HORIZONTAL) == -1)
        {
            _playerRigidbody.position = new Vector3(-23, 0, 3.3f);
        }
        else if (Input.GetAxis(PlayerAnimParameter.HORIZONTAL) == 1)
        {
            _playerRigidbody.position = new Vector3(-23, 0, -3.3f);
        }
        else
        {
            _playerRigidbody.position = new Vector3(-23, 0, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _playerAnimator.SetTrigger(PlayerAnimParameter.ATTACK);
        }
    }
}
