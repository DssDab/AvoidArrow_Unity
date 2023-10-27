using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ObjectController;

public class ObjectSpawn : MonoBehaviour
{
    
    public GameObject[] Type;
    GameObject Player;
    float delta = 0.0f;
    float span = 1.0f;
    int ratio = 3;
    float m_DownSpeed = -0.1f;
    void Start()
    {
        Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Player.GetComponent<PlayerController>().Life <= 0)
            return;
        // --- 난이도 설정---
        m_DownSpeed -= (Time.deltaTime * 0.005f);

        if (m_DownSpeed < -0.3f)
            m_DownSpeed = -0.3f;

        span -= (Time.deltaTime * 0.03f);

        if (span <= 0.1f)
            span = 0.1f;
        // ---난이도 설정---

        delta += Time.deltaTime;
            
        if (delta >= span)
        {
            delta = 0.0f;

            int rand = Random.Range(0, Type.Length);
            GameObject go = null;
            int dice = Random.Range(1, 11);
            if (dice <= ratio)
            {
                if (Type[rand].GetComponent<ObjectController>().ObjType == Obj.item)
                {
                     go = Instantiate(Type[rand]) as GameObject;
                    go.GetComponent<ObjectController>().downSpeed = m_DownSpeed;
                }
                else
                {
                     go = Instantiate(Type[rand]) as GameObject;
                     go.GetComponent<ObjectController>().downSpeed = m_DownSpeed;
                }
                int p1x = Random.Range(-8, 9);
                go.transform.position = new Vector3(p1x, 7, 0);


            }
        }
    }
}

