using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Rigidbody rigidBody;
    private AudioSource audio;
    private Cannon[] cannons;

    public float reloadTimer;
    private float reloadSpeed;

    private float baseReloadSpeed = 100;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        cannons = GetComponentsInChildren<Cannon>();
        reloadTimer = 100f;
        reloadSpeed = baseReloadSpeed;

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (reloadTimer < 100f)
        {
            reloadTimer += Time.deltaTime * reloadSpeed;
        }

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

        if (Input.GetKeyDown(KeyCode.Space) && reloadTimer >= 100f)
        {
            reloadTimer = 0f;
            audio.Play();
            foreach (Cannon cannon in cannons)
            {
                cannon.Fire();
            }
        }

        if (transform.position.y < -5f)
        {
            gm.PlayerReduceLife(10);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            gm.PlayerReduceLife(1);
        }
        else
        {
            Vector3 velo = rigidBody.velocity;
            velo.y = 0;
            rigidBody.velocity = velo;
            rigidBody.AddForce(Vector3.up * jumpForce);
        }
    }
}
