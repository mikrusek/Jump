using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float damping;

    public Vector3 velocity = Vector3.zero;

    void FixedUpdate() {
        Vector3 movePosition = target.position + offset;
        Vector3 SmoothVector = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);

        transform.position = new Vector3(SmoothVector.x, SmoothVector.y, -10);
    }
}
