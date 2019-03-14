using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Rigidbody rigidBody;
    private Cannon[] cannons;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        cannons = GetComponentsInChildren<Cannon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Cannon cannon in cannons)
            {
                cannon.Fire();
            }
        }
    }

    void OnCollisionEnter()
    {
        Vector3 velo = rigidBody.velocity;
        velo.y = 0;
        rigidBody.velocity = velo;
        rigidBody.AddForce(Vector3.up * jumpForce);
    }
}
