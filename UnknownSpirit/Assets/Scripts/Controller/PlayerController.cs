using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE,
    WALK,
    SHOOT
}

public class PlayerController : MonoBehaviour
{
    public PlayerState state;

    private Rigidbody myRigibody;

    Vector3 moveInput;
    Vector3 moveVelocity;

    Camera mainCamera;

    [SerializeField]
    public float speed = 6.0f;

    public GunController gunController;

    // Start is called before the first frame update
    void Start()
    {
        state = PlayerState.IDLE;
        myRigibody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Shoot(false);
        }

        Walk();
        FaceMouseDirection();
    }

    void FixedUpdate()
    {
        myRigibody.velocity = moveVelocity;
    }

    void Shoot(bool fire)
    {
        if (fire)
        {
            state = PlayerState.SHOOT;
        }
        gunController.isFiring = fire;
    }

    void Walk()
    {
        state = PlayerState.WALK;
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * speed;
    }

    void FaceMouseDirection()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
