using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;

    //public float wallsZ;
    //public float wallsX;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.position; // define the starting offset between the ball and the camera
	}
	
	// Update is called once per frame, but LateUpdate is always called LAST.
	void LateUpdate () {

        //transform.position.x = Mathf.Clamp(transform.position.x, minPosition, maxPosition);
        transform.position = player.position + offset; // every frame, right before the camera updates, the camera's postion is set to the player's position + the offset.
	}
}
