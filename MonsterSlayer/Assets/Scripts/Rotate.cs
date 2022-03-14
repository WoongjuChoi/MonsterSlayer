using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform _barrelTransform;
    private float _rotationSpeed = 4;

    private void Update()
    {
        transform.Rotate(new Vector3(0, -_rotationSpeed, 0));
    }
}
