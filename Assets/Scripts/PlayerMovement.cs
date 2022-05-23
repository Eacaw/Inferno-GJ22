using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Base user speed
    [SerializeField] private float speed = 5.0f;
    private Rigidbody rb;
    public GameObject PlayerCorpsePrefab;
    private Vector3 spawnPoint;

    public int MaxJump = 1;
    int JumpCount = 0;
    float RotateSpeed = 50.0f;

    void Start()
    {
        spawnPoint = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {


        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < MaxJump)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 spawnAbove = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            GameObject capsule = Instantiate(PlayerCorpsePrefab, transform.position, transform.rotation);
            transform.position = spawnPoint;
            rb.velocity = Vector3.zero;
        }

        // THIS BIT IS THE PROBLEM
        // if (rb.velocity != Vector3.zero)
        // {
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, 
        //     Quaternion.LookRotation(new Vector3(transform.GetComponent<Rigidbody>().velocity.x, 0, transform.GetComponent<Rigidbody>().velocity.z)), 
        //     Time.deltaTime * RotateSpeed);
        // }

        transform.Translate(new Vector3(-1 * vertical, 0, horizontal) * (speed * Time.deltaTime));
    }

    void FixedUpdate()
    {
        // Get the velocity
        Vector3 horizontalMove = rb.velocity;
        // Don't use the vertical velocity
        horizontalMove.y = 0;
        // Calculate the approximate distance that will be traversed
        float distance = horizontalMove.magnitude * Time.fixedDeltaTime;
        // Normalize horizontalMove since it should be used to indicate direction
        horizontalMove.Normalize();
        RaycastHit hit;

        // Check if the body's current velocity will result in a collision
        if (rb.SweepTest(horizontalMove, out hit, distance))
        {
            // If so, stop the movement
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        JumpCount += 1;
    }

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "Ground" || Col.gameObject.tag == "Player")
        {
            JumpCount = 0;
        }
    }
}
