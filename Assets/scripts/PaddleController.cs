using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;

    void Update()
    {
        if (GameController.instance.inPause == false && GameController.instance.inPlay == true)
        {
            PaddleMovement();
        }
    }

    void PaddleMovement()
    {
        if (Input.GetKey("left") && transform.position.x > -6.25)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey("right") && transform.position.x < 6.2)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }
    }

    
}
