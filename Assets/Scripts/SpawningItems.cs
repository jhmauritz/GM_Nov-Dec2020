using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawningItems : MonoBehaviour
{
    [Header("these arrays ARE PARALLEL!!")]
    
    [Tooltip("item you want to spawn")]
    public ItemScript[] items;
    [Tooltip("places to spawn")]
    public Transform[] spawnPoints;

    private bool startTimer = true;
    public float timerPointer;
    private float timer;
    
    //random spawn location
    public float MinX = 0;
    public float MaxX = 10;
    public float MinY = 0;
    public float MaxY = 10;
    public float MinZ = 0;
    public float MaxZ = 10;

    private void Start()
    {
        timer = timerPointer;
    }

    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Instantiate(RandomItem(), RandomSpawnLocation(), 
                    Quaternion.identity);
                timer = timerPointer;
            }
        }
    }

    Vector3 RandomSpawnLocation()
    {
        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index].position;
    }

    GameObject RandomItem()
    {
        float sum = 0f;
        float randomWeight = 0;

        foreach (var item in items)
        {
            sum += item.spawnChance;
        }

        do
        {
            if (sum == 0)
            {
                return null;
            }

            randomWeight = Random.Range(0, sum);
        } while (randomWeight == sum);

        foreach (var item in items)
        {
            if (randomWeight < item.spawnChance)
                return item.gameObject;
            randomWeight -= item.spawnChance;
        }

        return null;
    }
    
}
