using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class ObjectController : MonoBehaviour
{
    GameObject Player;
    public float downSpeed = 0.1f;
   
    public enum Obj { item, arrow}
    public Obj ObjType;
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0, -downSpeed, 0);


        if (this.transform.position.y < -5.0f)
            Destroy(this.gameObject);

        Vector2 p1 = transform.position;
        Vector2 p2 = this.Player.transform.position;
        Vector2 dir = p1 - p2;
        float distance = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if (distance < r1 + r2)
        {
        if (this.ObjType == Obj.arrow)
        {
            Destroy(this.gameObject);
            this.Player.GetComponent<PlayerController>().Life--;
            GameObject Director = GameObject.Find("GameDirector");
            Director.GetComponent<GameDirector>().DecreaseHp();
            }
        else if(this.ObjType == Obj.item)
        {
            Destroy(this.gameObject);
            this.Player.GetComponent<PlayerController>().score += 10;
            GameObject Director = GameObject.Find("GameDirector");
            Director.GetComponent<GameDirector>().ScoreUp();
        }
        }
    }
}
