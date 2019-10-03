using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float MovimentVelocity;
    public float AxisXLimit;

    // Start is called before the first frame update
    void Start()
    {
        MovimentVelocity = 13.5f;
        AxisXLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x
            - GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().position 
                += Vector3.left * MovimentVelocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().position 
                += Vector3.right * MovimentVelocity * Time.deltaTime;
        }

        float xAxis = transform.position.x;
        xAxis = Mathf.Clamp(xAxis, -AxisXLimit, AxisXLimit);
        transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
    }
}
