using UnityEngine;

public class PickupController : MonoBehaviour {

    protected GameController gameController;
    protected PlayerController player;
    protected SpawnerController parentSpawner;

    public Vector3 angularVelocity = new Vector3(15, 30, 45);

    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerController>();
        }
        if (player == null)
        {
            Debug.Log("Cannot find 'Player' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(angularVelocity * Time.deltaTime);// rotates object by 15 x, 30 y, and 45 z, where each value is multiplied by the amount of deltatime 
                                                                   // (The time in seconds it took to complete the last frame ) that have passed, to make it frame independent.
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this);
            gameController.AddScore(1);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this);
        }
    }

    public void setParentSpawner(SpawnerController spawner)
    {
        this.parentSpawner = spawner;
    }

    public SpawnerController getParentSpawner()
    {
        return this.parentSpawner;
    }
}
