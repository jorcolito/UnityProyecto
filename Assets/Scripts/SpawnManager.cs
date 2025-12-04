using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;

    public float minTime = 1f;
    public float maxTime = 2f;
    public float minY = -1f;
    public float maxY = 1f;

    void Start()
    {
        StartCoroutine(SpawnCoRoutine(0));
    }

    IEnumerator SpawnCoRoutine(float waitTime){
        yield return new WaitForSeconds(waitTime);

        Vector3 randomPos = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);
        
        Instantiate(itemPrefab[Random.Range(0,itemPrefab.Length)],
        randomPos,Quaternion.identity);
        
        StartCoroutine(SpawnCoRoutine(Random.Range(minTime, maxTime)));
    }
}