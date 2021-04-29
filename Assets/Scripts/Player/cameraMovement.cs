using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public static float offsetX;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            moveTheCamera();
        }
    }

    void moveTheCamera()
    {

        Vector3 temp = transform.position;
        temp.x = player.position.x + offsetX;
        transform.position = temp;

    }
}
