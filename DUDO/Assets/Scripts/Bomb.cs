using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    public float lastingTime = 5f;

    // Update is called once per frame
    void Update()
    {
        lastingTime -= Time.deltaTime;
        if (lastingTime <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
