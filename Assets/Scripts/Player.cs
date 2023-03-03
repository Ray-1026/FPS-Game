using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool isGround;
    public static int level = 1;

    private CharacterController cc;
    private AudioSource foot;
    private float horizontalMove, verticalMove;
    private Vector3 dir;
    private Vector3 velocity;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        foot = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 2 && SceneManager.GetActiveScene().buildIndex < 6)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

        if (isGround && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (foot.isPlaying == false)
            {
                foot.Play();
            }
        }
        else
        {
            foot.Stop();
        }

        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;
        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = jumpSpeed;
        }

        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }
}
