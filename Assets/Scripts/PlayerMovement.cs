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
            Vector3 spawnAbove = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            GameObject capsule = Instantiate(PlayerCorpsePrefab, transform.position, transform.rotation);
            transform.position = spawnPoint;
            rb.velocity = Vector3.zero;
        }

        transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        JumpCount += 1;
    }

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "Ground")
        {
            JumpCount = 0;
        }
    }
}
