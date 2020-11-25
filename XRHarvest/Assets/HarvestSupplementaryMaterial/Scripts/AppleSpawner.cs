using i5.Toolkit.Core.Spawners;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    private Spawner spawner;

    private BoxCollider spawnVolume;

    private float timeToSpawn;

    private void Awake()
    {
        spawner = GetComponent<Spawner>();
        spawnVolume = GetComponent<BoxCollider>();
        timeToSpawn = DetermineSpawnTime();
    }

    private void Start()
    {
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameFinished += OnGameFinished;

        // TODO: Task 2.3(f)
        // The apples should only start falling after a new game has been started
        // Therefore, disable the script immediately after the start
        // so that Update is not called until the game starts
        // ================================================


        // ================================================
    }

    private void OnGameStarted()
    {
        enabled = true;
    }

    private void OnGameFinished()
    {
        enabled = false;
        RemoveSpawnedObjects();
    }

    private void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0)
        {
            SpawnObject();
            timeToSpawn = DetermineSpawnTime();
        }
    }

    private static float DetermineSpawnTime()
    {
        return Random.Range(1f, 5f);
    }

    private void SpawnObject()
    {
        // TODO: Task 2.2 (e)
        // Use the spawner to try and spawn an object using its Spawn function
        // If this succeeds (shown by the bool return value), get the spawner's 
        // most recently spawned object and sets its position 
        // to a random position calculated by GetSpawnPosition()
        // ================================================



        // ================================================
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 spawnPositionInCollider = new Vector3(
                Random.Range(-spawnVolume.size.x / 2, spawnVolume.size.x / 2),
                Random.Range(-spawnVolume.size.y / 2, spawnVolume.size.y / 2),
                Random.Range(-spawnVolume.size.z / 2, spawnVolume.size.z / 2)
                );
        Vector3 globalSpawnPosition = transform.position + transform.localScale.x * (spawnVolume.center + spawnPositionInCollider);
        return globalSpawnPosition;
    }

    private void RemoveSpawnedObjects()
    {
        // TODO: Task 2.3(h)
        // Clean up the apples by looping over all spawned instances of the spawner 
        // and destroy them using Destroy()
        // ================================================


        // ================================================
    }
}
