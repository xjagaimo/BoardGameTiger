using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letters : MonoBehaviour
{
    private int spawnIndex = 0;
    private int prefabIndex = 0;
    private int destroyIndex = 0;
    public int i = 0;

    public Transform[] waypoints;
    public GameObject[] prefabList;
    public GameObject[] instaList = new GameObject[5];

    //public GameObject instantiated;

    //public float waitSpawn = 10f;
    public bool destroyAllowed = true;

    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < prefabList.Length; j++)
        {
            spawnIndex = Random.Range(0, 20);
            prefabIndex = Random.Range(0, 5);
            instaList[j] = Instantiate(prefabList[prefabIndex], waypoints[spawnIndex].transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DestroyLetters();
        SpawnLetters();
        
    }

    void SpawnLetters ()
    {
        if (!destroyAllowed && Dice.manyTurns % 5 == 0)
        {
            //spawnAllowed = false;
            spawnIndex = Random.Range(0, 20);
            prefabIndex = Random.Range(0, 5);
            Debug.Log(spawnIndex);

            //transform.position = waypoints[spawnIndex].transform.position;
            instaList[i] = Instantiate(prefabList[prefabIndex], waypoints[spawnIndex].transform.position, Quaternion.identity);

            //instaList[i] = instantiated;
            destroyAllowed = true;
            Dice.manyTurns++;
            i++;
        }
    }

    void DestroyLetters()
    {
        if (destroyAllowed && Dice.manyTurns % 5 == 0)
        {
            Debug.Log("DDDDDDD");
            destroyIndex = Random.Range(0, instaList.Length);
            Debug.Log(destroyIndex);
            //Destroy(instantiated);
            Destroy(instaList[destroyIndex]);
            destroyAllowed = false;
        }
    }



}
