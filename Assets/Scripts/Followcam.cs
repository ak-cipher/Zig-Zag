using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcam : MonoBehaviour
{

    public Transform Target;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        transform.position = Target.position + offset;
    }
}
