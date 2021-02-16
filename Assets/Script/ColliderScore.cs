using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIManager.instance.UpdateScore();
    }
}
