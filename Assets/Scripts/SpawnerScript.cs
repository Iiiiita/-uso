using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public SpawnerOne spawnerOne;
    public SpawnerTwo spawnerTwo;
    public SpawnerThree spawnerThree;
    public SpawnerFour spawnerFour;
    public GameObject[] noteArray;
    public float spawnInterval;
    public LevelUI levelManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFromArray());
    }

    IEnumerator SpawnFromArray()
    {
        for (int i = 0; i < noteArray.Length; i++)
        {
            if (noteArray[i].name == "Note1")
            {
                spawnerOne.SpawnFromSpawnerOne();
            }
            if (noteArray[i].name == "Note2")
            {
                spawnerTwo.SpawnFromSpawnerTwo();
            }
            if (noteArray[i].name == "Note3")
            {
                spawnerThree.SpawnFromSpawnerThree();
            }
            if (noteArray[i].name == "Note4")
            {
                spawnerFour.SpawnFromSpawnerFour();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
