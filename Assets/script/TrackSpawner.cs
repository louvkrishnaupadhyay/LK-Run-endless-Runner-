using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    public GameObject roadPrefab;
    public Transform player;

    public float roadLength = 50f;
    public int startRoads = 3;
    public int maxRoads = 5;

    private Queue<GameObject> roads = new Queue<GameObject>();
    private float nextSpawnZ;

    void Start()
    {
        GameObject firstRoad = GameObject.Find("RoadSection");

        roads.Enqueue(firstRoad);

        nextSpawnZ = firstRoad.transform.position.z + roadLength;

        for (int i = 1; i < startRoads; i++)
        {
            SpawnRoad();
        }
    }

    void Update()
    {
        if (player.position.z > nextSpawnZ - (roadLength * 2))
        {
            SpawnRoad();
        }
    }

    void SpawnRoad()
    {
        GameObject road = Instantiate(
            roadPrefab,
            new Vector3(7.19915f, -0.52407f, nextSpawnZ),
            Quaternion.identity
        );

        roads.Enqueue(road);

        nextSpawnZ += roadLength;

        if (roads.Count > maxRoads)
        {
            Destroy(roads.Dequeue());
        }
    }
}