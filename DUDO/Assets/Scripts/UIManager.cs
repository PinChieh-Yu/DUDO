using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private PlayerController pc;

    private TMP_Text scoreText;
    private Image reloadBar;
    private TMP_Text lifeText;

    private GameManager gm;

    void Start()
    {
        reloadBar = transform.Find("ReloadBar").Find("Energy").GetComponent<Image>();
        scoreText = transform.Find("Score").Find("Point").GetComponent<TMP_Text>();
        lifeText = transform.Find("Life").Find("Point").GetComponent<TMP_Text>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        reloadBar.fillAmount = Mathf.Clamp01(pc.reloadTimer / 100f);
        scoreText.text = gm.score.ToString();
        lifeText.text = gm.lifeRemain.ToString();
    }
}
