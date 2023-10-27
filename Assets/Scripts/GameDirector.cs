using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hp_Gage;
    Image hp_Img;
    GameObject score;
    Text ScoreText;
    GameObject player;
    void Start()
    {
        hp_Gage = GameObject.Find("Hp_Gage");
        if (hp_Gage != null)
            hp_Img = this.hp_Gage.GetComponent<Image>();

        score = GameObject.Find("Score");
        if (score != null)
            ScoreText = this.score.GetComponent<Text>();
        player = GameObject.Find("player");
        
    }
    public void ScoreUp()
    {
        if (ScoreText == null || hp_Img == null)
            return;
        if (player.GetComponent<PlayerController>().Life <= 0)
            return;

        ScoreText.text = "Score : " + player.GetComponent<PlayerController>().score;
    }
    public void DecreaseHp()
    {
        if (hp_Img == null)
            return;

        hp_Img.fillAmount = this.player.GetComponent<PlayerController>().Life/10;
    }
}
