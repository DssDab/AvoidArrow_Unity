using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hp_Gage;
    GameObject score;
    GameObject player;
    void Start()
    {
        hp_Gage = GameObject.Find("Hp_Gage");
        score = GameObject.Find("Score");
        player = GameObject.Find("player");
        
    }
    public void ScoreUp()
    {
        this.score.GetComponent<Text>().text = "Score : " + player.GetComponent<PlayerController>().score;
    }
    public void DecreaseHp()
    {
        this.hp_Gage.GetComponent<Image>().fillAmount = this.player.GetComponent<PlayerController>().Life/10;
    }
}
