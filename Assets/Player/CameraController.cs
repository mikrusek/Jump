using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public CharacterController target;
    public Vector3 offset;
    public float damping;
    public Vector3 velocity = Vector3.zero;


    public Camera Cam;
    public float zoom;
    public float defaultZoom;

    public float zoomSmoothTime = 0.3f;
    public float zoomVelocity = 0.0f;


	private void Awake() {
		Cam = GetComponent<Camera>();
        defaultZoom = Cam.orthographicSize;
	}



    void FixedUpdate() {
        Vector3 movePosition = target.transform.position + offset;
        Vector3 SmoothVector = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);

        transform.position = new Vector3(SmoothVector.x, SmoothVector.y, -10);


        zoom = defaultZoom + target.rb.velocity.sqrMagnitude/30;

        if (zoom < 20)
            Cam.orthographicSize = Mathf.SmoothDamp(Cam.orthographicSize, zoom, ref zoomVelocity, zoomSmoothTime);
    }
}
