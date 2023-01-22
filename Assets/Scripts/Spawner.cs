using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPoints;
    [SerializeField] private GameObject SpawnedObject;
    [SerializeField] private float MinTime;
    [SerializeField] private float MaxTime;
    [SerializeField] private int MaxAmount;
    private GameObject SpawnerPoint;
    private int Index;
    private int ObjectCounter;
    private float spawnDelay;
    private bool[] isTaken;
    private bool currentlySpawning;
    ResourceGiver Rg;

    void Start()
    {
        isTaken = new bool[SpawnPoints.Length];
    }

    void Update()
    { 
        StartCoroutine(Spawny());

        Rg = FindObjectOfType<ResourceGiver>();
            if(Rg == null)
            {
                if (ObjectCounter == MaxAmount)
                {
                    ObjectCounter = 0;

                    for (int i = 0; i < isTaken.Length; i++) 
                    {
                        isTaken[i] = false;
                    }
                }
            }
    }

    IEnumerator Spawny()
    {
        if (currentlySpawning == false)
        {
            Index = Random.Range(0, SpawnPoints.Length);
        }

        if (isTaken[Index] == false && currentlySpawning == false) 
        {
            currentlySpawning = true;
            SpawnerPoint = SpawnPoints[Index];
            spawnDelay = Random.Range(MinTime, MaxTime);

            yield return new WaitForSeconds(spawnDelay);
            if (ObjectCounter != MaxAmount)
            {
                Instantiate(SpawnedObject, SpawnerPoint.transform.position, Quaternion.identity);
                ObjectCounter++;
                isTaken[Index] = true;
                currentlySpawning = false;
            }
        }
    }
}
