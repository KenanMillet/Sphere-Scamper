using UnityEngine;

public class Rotator : MonoBehaviour {

    public Vector3 angularVelocity = new Vector3(15, 30, 45);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(angularVelocity * Time.deltaTime);// rotates object by 15 x, 30 y, and 45 z, where each value is multiplied by the amount of deltatime 
                                                                   // (The time in seconds it took to complete the last frame ) that have passed, to make it frame independent.
    }
}
