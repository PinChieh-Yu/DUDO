﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Update is called once per frame
    public GameObject explosion;
    bool isHitted = false;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 20);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isHitted)
        {
            isHitted = true;
            Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0)).transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            Destroy(gameObject);
        }
    }
}
