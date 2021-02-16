using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuyaux : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float timer = 6.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x - 3.0f * Time.deltaTime;
        transform.position = position;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
