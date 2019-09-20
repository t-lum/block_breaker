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
        Vector2 normal = collisor.contacts[0].normal;
        Direction = Vector2.Reflect(Direction, normal);
        Direction.Normalize();
    }
}
