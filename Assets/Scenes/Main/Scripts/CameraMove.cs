using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    private Vector3 touchStart;
    public Camera cam;
    public float groundY = 0;
    public float scale = 1.0f;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            touchStart = GetWorldPosition(groundY);
        }
        if (Input.GetMouseButton(0)){
            Vector3 direction = touchStart - GetWorldPosition(groundY);
            cam.transform.position += direction;
        }
        Vector3 pos = cam.transform.position;
        pos.y = pos.y + Input.mouseScrollDelta.y * scale * -1;
        cam.transform.position = pos;
    }
    private Vector3 GetWorldPosition(float y){
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, new Vector3(0, y, 0));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
}