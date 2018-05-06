using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwavePowerup : MonoBehaviour {

    public float secondsActive;
    public float pushForce;

	// Use this for initialization
	void OnEnable ()
    {
        StartCoroutine("UseShockwavePowerup");
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    IEnumerator UseShockwavePowerup()
    {
        yield return new WaitForSeconds(secondsActive);
        gameObject.SetActive(false);
        yield return null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Villain") || other.gameObject.CompareTag("Pick Up") || other.gameObject.CompareTag("Power Up"))
        {
            Vector3 pushDirection = other.transform.position - transform.position;
            other.GetComponent<Rigidbody>().AddForce(pushForce * pushDirection.normalized);
        }
        
    }
}
