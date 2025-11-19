using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            GroundTile tile = temp.GetComponent<GroundTile>();
            tile.SpawnObstacle();
            tile.SpawnCoins();
        }
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile(i >= 3);
        }
    }
}
