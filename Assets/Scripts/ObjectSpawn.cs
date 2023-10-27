using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject[] Type;
    GameObject Player;

    float delta = 0.0f;
    float span = 1.0f;
    float iTRT = 3.0f;
    void Start()
    {
        Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Player.GetComponent<PlayerController>().Life <= 0)
            return;

        if (span <= 0.3f)
            span = 0.3f;

        delta += Time.deltaTime;
        iTRT -= Time.deltaTime;
        if (delta >= span)
        {
            
            span -= 0.1f;
            delta = 0.0f;
            int rand = Random.Range(0, Type.Length);
            if (Type[rand].GetComponent<ObjectController>().ObjType == ObjectController.Obj.item)
            {
                if(iTRT<=0.0f)
                {
                iTRT = 3.0f;
                GameObject goItem = Instantiate(Type[rand]) as GameObject;
                int p1x = Random.Range(-8, 9);
                goItem.transform.position = new Vector3(p1x, 7, 0);
                return;
                }
            }
            else
            {
                GameObject goArrow = Instantiate(Type[rand]) as GameObject;
                int p2x = Random.Range(-8, 9);
                goArrow.transform.position = new Vector3(p2x, 7, 0);

            }
        }
    }
}
