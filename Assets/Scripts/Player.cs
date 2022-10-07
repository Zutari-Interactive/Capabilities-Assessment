using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI veocityText;
    private float velocity = 5.0f;
    private Rigidbody rb;
    new Renderer renderer;

    private float leftBound = 0.0f;
    private float rightBound = 0.0f;
    private float topBound = 0.0f;
    private float bottomBound = 0.0f;

    private float cubeWidth = 0.0f;
    private float cubeHeight = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        renderer = GetComponent<Renderer>();

        leftBound = Camera.main.ScreenToWorldPoint( new Vector3(0.0f, 0.0f, 0 - Camera.main.transform.position.z) ).x;
        rightBound = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width, 0.0f, 0 - Camera.main.transform.position.z) ).x;
        bottomBound = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0 - Camera.main.transform.position.z)).y;
        topBound = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0 - Camera.main.transform.position.z)).y;

        cubeWidth = transform.localScale.x;
        cubeHeight = transform.localScale.y;

        veocityText.text = velocity.ToString("0.00");

    }

    // Update is called once per frame
    void Update()
    {
        MoveAndChangeColor();

        KeepObjectInView();

        VelocityControl();
    }

    public void MoveAndChangeColor()
    {
        //Move UP
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + Vector3.up * velocity * Time.deltaTime);
            renderer.material.SetColor("_Color", Color.red);
        }

        //Move Left
        else if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + Vector3.left * velocity * Time.deltaTime);
            renderer.material.SetColor("_Color", Color.blue);
        }

        //Move Right
        else if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + Vector3.right * velocity * Time.deltaTime);
            renderer.material.SetColor("_Color", Color.black);
        }

        //Move Down
        else if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position + Vector3.down * velocity * Time.deltaTime);
            renderer.material.SetColor("_Color", Color.yellow);
        }
    }

    public void KeepObjectInView()
    {
        //Out of Field of view on the left
        if (transform.position.x < leftBound - cubeWidth/2)
        {
            transform.position = new Vector3(rightBound - cubeWidth / 2, transform.position.y, transform.position.z);  
        }

        //Out of Field of view on the right
        else if (transform.position.x > rightBound + cubeWidth/2)
        {
            transform.position = new Vector3(leftBound + cubeWidth / 2, transform.position.y, transform.position.z);
        }

        //Out of Field of view on the top
        else if (transform.position.y > topBound + cubeHeight/2)
        {
            transform.position = new Vector3(transform.position.x, bottomBound + cubeHeight / 2, transform.position.z);
        }

        //Out of Field of view on the bottom
        else if (transform.position.y < bottomBound - cubeHeight / 2)
        {
            transform.position = new Vector3(transform.position.x, topBound - cubeHeight / 2, transform.position.z);
        }

    }

    public void VelocityControl()
    {
        //Increase velocity
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity -= Time.deltaTime;

            if (velocity < 0.0f)
                velocity = 0.0f;

            veocityText.text = velocity.ToString("0.00");
        }

        //Decrease velocity
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += Time.deltaTime;

            if (velocity > 30.0f)
                velocity = 30.0f;

            veocityText.text = velocity.ToString("0.00");
        }

    }
}
