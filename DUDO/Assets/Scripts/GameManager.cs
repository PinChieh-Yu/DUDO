using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject monster;
    public int score = 0;
    public int lifeRemain = 10;

    public GameObject player;

    [SerializeField]
    private int maxMonsterCount;
    private int monsterCount;
    [SerializeField]
    [Range(0f, 1f)]
    private float monsterAttackProbability;

    public Vector3 spawningRangeFrom, spawningRangeTo;

    [SerializeField]
    private GameObject restartUI;

    void Start()
    {
        restartUI.SetActive(false);
        CreateMonsters();
    }

    private void CreateMonsters()
    {
        for (int i = 0; i < maxMonsterCount; i++)
        {
            GameObject go = Instantiate(monster, new Vector3(Random.Range(spawningRangeFrom.x, spawningRangeTo.x), Random.Range(spawningRangeFrom.y, spawningRangeTo.y), Random.Range(spawningRangeFrom.z, spawningRangeTo.z)), new Quaternion(0, 0, 0, 0));
            go.GetComponent<Monster>().SetParam(Random.Range(0f, 1f) < monsterAttackProbability, Random.Range(0f, 10f), Random.Range(1f, 300f));
        }
    }

    public void PlayerReduceLife(int amount)
    {
        lifeRemain -= amount;
        if (lifeRemain <= 0)
        {
            Time.timeScale = 0;
            restartUI.SetActive(true);
            restartUI.GetComponentInChildren<TMP_Text>().text = score.ToString() + "pt";
        }
    }

    public void RestartGame()
    {
        GameObject[] monsterRemain = GameObject.FindGameObjectsWithTag("Monster");
        GameObject[] fireBallRemain = GameObject.FindGameObjectsWithTag("FireBall");
        foreach (GameObject monster in monsterRemain)
        {
            Destroy(monster);
        }
        foreach (GameObject fireball in fireBallRemain)
        {
            Destroy(fireball);
        }

        score = 0;
        lifeRemain = 10;
        Time.timeScale = 1;

        CreateMonsters();

        player.transform.position = new Vector3(0f, 0f, 0f);

        restartUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
