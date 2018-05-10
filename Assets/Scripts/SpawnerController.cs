using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public Vector3 center;
    public Vector3 size;

    private IEnumerator spawnRoutine;

    public bool stopSpawn;

    public bool hasInitialSpawn;
    private bool shouldSpawnInitial;
    public Vector3 initialSpawnOffset;

    public float initialMinSpawnWait;
    public float initialMaxSpawnWait;

    public float spawnMinWait;
    public float spawnMaxWait;

    public int spawnMaxAmt;
    public int totalSpawned;

    public int powerupChance;

    //public List<GameObject> currentPickups;
    

    public GameObject prefabPickup;
    public GameObject prefabPowerup;


	// Use this for initialization
	void Start ()
    {
        shouldSpawnInitial = hasInitialSpawn;
        //prefabPickup.GetComponent<PickupController>().setParentSpawner(this);
    }

    // Update is called once per frame
    void Update () {

	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

    public void SpawnPickup()
    {
        Vector3 pos;
        if (shouldSpawnInitial == true)
        {
            pos = center + initialSpawnOffset;
            shouldSpawnInitial = false;
        }
        else
        {
            pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        }

        Instantiate(prefabPickup, pos, Quaternion.identity);
    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(Random.Range(initialMinSpawnWait, initialMaxSpawnWait));

        while (!stopSpawn && (totalSpawned < spawnMaxAmt))
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            if(Random.Range(1,100) <= powerupChance)//put this here so first spawning pickup isnt a powerup.
            {
                Instantiate(prefabPowerup, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(prefabPickup, pos, Quaternion.identity);
                totalSpawned++;
            }
            yield return new WaitForSeconds(Random.Range(spawnMinWait, spawnMaxWait));
        }
    }

    public void StartSpawning()
    {
        spawnRoutine = WaitSpawner();
        StartCoroutine(spawnRoutine);
    }

    public void StopSpawning()
    {
        StopCoroutine(spawnRoutine);
        shouldSpawnInitial = hasInitialSpawn;
    }


}
