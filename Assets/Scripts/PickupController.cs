using UnityEngine;

public class PickupController : MonoBehaviour {

    protected GameController gameController;
    protected PlayerController player;
    //protected SpawnerController parentSpawner;

    

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
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameController.AddScore(1);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log(parentSpawner);
            //parentSpawner.totalSpawned--;
            //parentSpawner.SpawnPickup();
            Destroy(this.gameObject);
        }
    }

    /*public void setParentSpawner(SpawnerController spawner)
    {
        this.parentSpawner = spawner;
    }

    public SpawnerController getParentSpawner()
    {
        return this.parentSpawner;
    }*/
}
