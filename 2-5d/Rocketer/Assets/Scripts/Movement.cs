using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rigidBody;

    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationSpeed = 100f;

    int rotateForward = -1;
    int rotateBackward = 1;

    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        ProcessInput();

    }

    private void ProcessInput()
    {

        Thrust();
        Rotation();

    }

    private void Thrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    private void Rotation()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(rotateBackward);
            return;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(rotateForward);
            return;
        }

    }

    private void Rotate(int directionMultiplier)
    {

        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * directionMultiplier);
        rigidBody.freezeRotation = false;

    }

}
