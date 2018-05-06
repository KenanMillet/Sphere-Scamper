using System.Collections;
using UnityEngine;

public class PickupController : MonoBehaviour {

    public Vector3 center;
    public Vector3 size;

    private IEnumerator spawnRoutine;

    public bool stopSpawn;

    public int initialSpawnWait;

    public float spawnMinWait;
    public float spawnMaxWait;

    public int spawnMaxAmt;
    public int totalSpawned;
    

    public GameObject prefabDimensionalShifter;


	// Use this for initialization
	void Start () {

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
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(prefabDimensionalShifter, pos, Quaternion.identity);
    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(initialSpawnWait);

        while (!stopSpawn && (totalSpawned < spawnMaxAmt))
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(prefabDimensionalShifter, pos, Quaternion.identity);
            totalSpawned++;
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
    }


}
