using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public int score = 0;
    public float Life = 10.0f;
    float hAxis;
   [HideInInspector] public bool isLBtnDown = false;
   [HideInInspector]public bool isRBtnDown = false;
    [Header("---GameUI---")]
    public GameObject Replay;
    public Text ScoreT;

    void Update()
    {
        if(Life <=0)
        {
            Life = 0;
            ScoreT.text = "Score : " + score;
            Replay.gameObject.SetActive(true);
            return;
        }
        inputKey();

            this.transform.position += new Vector3((hAxis*6*Time.deltaTime), 0,0);

        if (this.transform.position.x > 8.0f)
            this.transform.position = new Vector3(8.0f, -3.6f, 0);

        if (this.transform.position.x < -8.0f)
            this.transform.position = new Vector3(-8.0f, -3.6f, 0);

        if (isLBtnDown)
            this.transform.position += new Vector3((-1.0f*6*Time.deltaTime),0,0);
        if (isRBtnDown)
            this.transform.position += new Vector3((1.0f*6*Time.deltaTime), 0, 0);
    }

    void inputKey()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
        PlayerPrefs.DeleteAll();

    }

    public void onLeftDown()
    {
        isLBtnDown = true;
    }
    public void OnLeftUp()
    {
        isLBtnDown = false;
    }
    public void OnRightDown()
    {
        isRBtnDown = true;
    }
    public void OnRightUp()
    {
        isRBtnDown = false;
    }
}
