using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawningItems : MonoBehaviour
{
    public GameObject[] items;
    public float[] probability;
    private float[] cumulative;

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
    
    void MakeCumulative()
    {
        float current = 0;
        int itemCount = probability.Length;

        for (int i = 0; i <= itemCount; i++)
        {
            current += probability[i];
            cumulative[i] = current;
        }

        if (current > 1.0f)
        {
            Debug.Log("probability exceeds 100%");
        }
    }

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
                timer = timerPointer;
                MakeCumulative();
                Instantiate(GetRandomItem(), RandomSpawnLocation(), 
                    Quaternion.identity);
            }
        }
    }

    Vector3 RandomSpawnLocation()
    {
        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);
        float z = Random.Range(MinZ, MaxZ);
        
        Vector3 randLoc = new Vector3(x, y, z);

        return randLoc;
    }

    GameObject GetRandomItem()
    {
        float rnd = Random.Range(0, 1.0f);
        int itemCount = cumulative.Length;

        for (int i = 0; i <= itemCount; i++)
        {
            if (rnd <= cumulative[i])
            {
                return items[i];
            }
        }

        return null;
    }
}
