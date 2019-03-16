using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject monster;
    public static int score = 0;
    public static int lifeRemain = 10;

    [SerializeField]
    private int maxMonsterCount;
    private int monsterCount;

    public Vector3 spawningRangeFrom, spawningRangeTo;

    void Start()
    {
        for (int i = 0; i < maxMonsterCount; i++)
        {
            GameObject go = Instantiate(monster, new Vector3(Random.Range(spawningRangeFrom.x, spawningRangeTo.x), Random.Range(spawningRangeFrom.y, spawningRangeTo.y), Random.Range(spawningRangeFrom.z, spawningRangeTo.z)), new Quaternion(0, 0, 0, 0));
            go.GetComponent<Monster>().SetParam(false, Random.Range(0f, 10f), Random.Range(1f, 300f));
        }
    }
}
