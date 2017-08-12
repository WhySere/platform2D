using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 cameraPosition;

    // Use this for initialization
    void Start ()
    {
        cameraPosition = new Vector3(0f, 0f, -5f);
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + cameraPosition, 0.2f);
	}
}
