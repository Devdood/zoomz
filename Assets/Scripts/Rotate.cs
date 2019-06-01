using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationAngle;

    void Update()
    {
        transform.localEulerAngles += rotationAngle * Time.deltaTime;
    }
}
