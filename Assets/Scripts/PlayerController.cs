using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private float horizontalInput;
    private float xRange = 11;

    void Update()
    {
        ControlMovement();
    }
    private void ControlMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        float xPos = Mathf.Clamp(transform.position.x,-xRange,xRange);
        transform.position = new Vector3(xPos,transform.position.y,transform.position.z);
    }
}
