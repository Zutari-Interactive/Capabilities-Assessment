using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5.0f;
    private Rigidbody rb;
    new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        renderer = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move UP
        if (Input.GetKey(KeyCode.W)) 
        {
            rb.MovePosition(transform.position + Vector3.up * speed * Time.deltaTime);
            renderer.material.SetColor("_Color", Color.red);
        }

        //Move Left
        else if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + Vector3.left * speed * Time.deltaTime);
            renderer.material.SetColor("_Color", Color.blue);
        }

        //Move Right
        else if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
            renderer.material.SetColor("_Color", Color.black);
        }

        //Move Down
        else if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position + Vector3.down * speed * Time.deltaTime);
            renderer.material.SetColor("_Color", Color.yellow);
        }
    }
}
