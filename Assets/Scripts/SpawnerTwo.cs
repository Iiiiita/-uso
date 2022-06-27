﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTwo : MonoBehaviour
{
    public GameObject noteToSpawn;
    Vector3 spawnerPos;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnFromSpawnerTwo()
    {
        spawnerPos = this.transform.position;
        GameObject go = Instantiate(noteToSpawn, spawnerPos, noteToSpawn.transform.rotation);
        go.transform.SetParent(parent.transform);
    }
}
