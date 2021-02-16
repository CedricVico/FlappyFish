using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private float thrust = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        Vector3 posStart = Camera.main.WorldToScreenPoint(transform.position);
        posStart.x = Screen.width * 0.15f;
        posStart.y = Screen.height * 0.5f;
        transform.position = Camera.main.ScreenToWorldPoint(posStart);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = new Vector2(0.0f, 5.0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.ChangeState(GameManager.GameState.Death);
    }
}
