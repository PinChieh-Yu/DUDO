using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    //public Quaternion rotation;
    public Quaternion defaultRotate;

    private Vector3 direction;

    private ParticleSystem ps;

    [SerializeField]
    private GameObject bomb;

    void Start()
    {
        defaultRotate = Quaternion.Euler(0, 0, 0);
        ps = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 20f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        direction = worldPos - transform.position;

        transform.rotation = Quaternion.LookRotation(direction) * defaultRotate;
    }

    public void Fire()
    {
        ps.Play();
        GameObject bm = Instantiate(bomb, ps.transform.position, transform.rotation);
        bm.GetComponent<Rigidbody>().AddForce(direction * 100f);
    }
}
