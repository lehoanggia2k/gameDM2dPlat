using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    private Transform player;   //character

    // Start is called before the first frame update
    void Start()
    {
        //component
        player = GameObject.Find("BU").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player!= null) //check player input
        {
            // camera location
            Vector3 pos = transform.position;
            pos.x = player.position.x;
            //transform.position = pos;
            pos.y = player.position.y + 5;
            transform.position = pos;
        }

    }
}
