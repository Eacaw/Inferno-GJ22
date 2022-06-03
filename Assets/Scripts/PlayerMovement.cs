using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Base user speed
    [SerializeField] private float speed = 5.0f;
    private Rigidbody rb;
    public GameObject PlayerModel, PlayerCorpsePrefab;
    private Vector3 spawnPoint, respawnPoint;

    public int MaxJump = 1;
    int JumpCount = 0;
    private float rotateSpeed = 180.0f;

    private Quaternion qTo;
    private bool inputDisabled = false;

    public VariableJoystick variableJoystick;

    public Button JumpButton;
    public Button SacrificeButton;

    void Start()
    {
        spawnPoint = transform.position;
        respawnPoint = transform.position + new Vector3(0, -20, 0);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        var horizontal = (float)this.getHorizontal();
        var vertical = (float)this.getVertical();

        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < MaxJump)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale != 0f)
        {
            this.dieAndRespawn(0);

        }
        Vector3 direction = Vector3.left * variableJoystick.Vertical + Vector3.forward * variableJoystick.Horizontal;
        transform.Translate(direction * (speed * Time.deltaTime));
    }

    void FixedUpdate()
    {
        if (!this.inputDisabled)
        {
            var horizontal = variableJoystick.Horizontal;
            var vertical = variableJoystick.Vertical;

            Vector3 target = new Vector3(transform.position.x + horizontal,
                                        transform.position.y + vertical,
                                        0);
            var lookPos = target - transform.position;
            float angle = Mathf.Atan2(lookPos.x, lookPos.y) * Mathf.Rad2Deg - 90;
            qTo = Quaternion.AngleAxis(angle, Vector3.up);
            PlayerModel.transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotateSpeed);
        }
    }

    public void Jump()
    {
        if (JumpCount == 0)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            JumpCount++;
        }
    }

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "Ground")
        {
            FindObjectOfType<SoundManager>().Play("PlayerSplat");
            JumpCount = 0;
        }
        else if (Col.gameObject.tag == "Corpse")
        {
            FindObjectOfType<SoundManager>().Play("CorpseSplat");
            JumpCount = 0;
        }
    }

    double getHorizontal()
    {
        if (!this.inputDisabled)
        {
            return Input.GetAxis("Horizontal");
        }
        else
        {
            return 0;
        }
    }

    double getVertical()
    {
        if (!this.inputDisabled)
        {
            return Input.GetAxis("Vertical");
        }
        else
        {
            return 0;
        }
    }

    public void dieAndRespawn(int type)
    {
        //Type 0 = Spawn a corpse
        //Type 1 = Respawn without corpse (laser)
        if (type == 0)
        {
            Vector3 spawnAbove = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            GameObject capsule = Instantiate(PlayerCorpsePrefab, transform.position, transform.rotation);
        }

        this.inputDisabled = false;
        rb.freezeRotation = true;
        rb.rotation = Quaternion.identity;
        transform.position = respawnPoint;
        rb.velocity = Vector3.zero;


    }

    public void setRespawn(int zMultiplier, int yMultiplier, int xMultiplier)
    {
        respawnPoint = transform.position + new Vector3((1 * xMultiplier), (1 * yMultiplier), (1 * zMultiplier));
    }

    public void disableInput()
    {

        rb.freezeRotation = false;

        rb.AddForce(new Vector3((float)(-5 * getVertical()), 0, (float)(5 * getHorizontal())), ForceMode.Impulse);
        this.inputDisabled = true;
    }
}
