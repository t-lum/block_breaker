using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 Direction;
    public float Velocity;

    // Start is called before the first frame update
    void Start()
    {
        Direction = new Vector3(1, 1, 0);
        Direction.Normalize();
        Velocity = 12.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * Velocity * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collisor)
    {
        bool invalidCollision = false;
        Vector2 normal = collisor.contacts[0].normal;
        Platform platform = collisor.transform.GetComponent<Platform>();
        EdgeManager edgeManager = collisor.transform.GetComponent<EdgeManager>();
        if (platform != null)
        {
            if (normal != Vector2.up)
            {
                invalidCollision = true;
            }
        }
        else if (edgeManager != null)
        {
            if (normal == Vector2.up)
            {
                invalidCollision = true;
            }
        }
        if (!invalidCollision)
        {
            Direction = Vector2.Reflect(Direction, normal);
            Direction.Normalize();
        }
        else
        {
            GameManager.EndGame();
        }
    }
}
