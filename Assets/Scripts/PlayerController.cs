using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int score = 0;
    public float Life = 10.0f;
    float hAxis;
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
    }

    void inputKey()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        
    }

    public void LeftButtonDown()
    {
         this.transform.position += new Vector3(-1, 0, 0);
    }

    public void RightButtonDown()
    {
         this.transform.position += new Vector3(1, 0, 0);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }



}
