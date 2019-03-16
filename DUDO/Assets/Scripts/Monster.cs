using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private bool isHitted = false;
    public GameObject explosion;

    private bool isAttacker;

    private float timer = -1f;
    private float sign = 1f;
    private float scale;
    private float speed;
    private Vector3 basePosition;

    void Start()
    {
        basePosition = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime * sign * speed / 100;
        transform.position = basePosition + new Vector3(sign * (timer * timer - 1) / (timer * timer + 1) * scale, sign * 2 * timer * (timer * timer - 1) / Mathf.Pow((timer * timer + 1), 2) * scale, 0);
        if (timer > 1f || timer < -1f)
        {
            sign *= -1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isHitted)
        {
            isHitted = true;
            GameManager.score += 1000;
            Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
    }

    public void SetParam(bool isAttacker, float shakingScale = 0f, float shakingSpeedPercent = 100f)
    {
        this.isAttacker = isAttacker;

        scale = shakingScale;
        speed = shakingSpeedPercent;
    }
}
