using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;

    public float wallsZ;//note, the way this is written, the camera expectsd the stage to be a PERFECT SQUARE. see clamping in lateupdate. also note that camera direction and wall height may obscure playfield
    public float wallsX;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.position; // define the starting offset between the ball and the camera
	}
	
	// Update is called once per frame, but LateUpdate is always called LAST.
	void LateUpdate () {

        transform.position = player.position + offset; // every frame, right before the camera updates, the camera's postion is set to the player's position + the offset.
        transform.position = new Vector3(Mathf.Clamp( transform.position.x, -wallsX, wallsX), transform.position.y, Mathf.Clamp(transform.position.z, -wallsZ, wallsZ));

    }
}
