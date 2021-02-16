using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The SpawnManager is null");
            }
            return _instance;
        }
    }
    public GameObject tuyaux;
    float timer = 2.0f;
    
    private void Awake()
    {
        _instance = this;
    }
    public void StartSpawning()
    {
        float posSpawn = Random.Range(0.0f,-6.0f);
        Vector2 position = transform.position;
        position.y = posSpawn;
        transform.position = position;
        Instantiate(tuyaux,this.transform.position , Quaternion.identity);
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            StartSpawning();
            timer = 2.0f;
        }
    }
}
