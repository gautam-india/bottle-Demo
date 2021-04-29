using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaryCheck : MonoBehaviour
{
    [SerializeField] GameObject gameOver;

    private void Start()
    {
        gameOver.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
