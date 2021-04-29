using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenSpawner : MonoBehaviour
{
    [SerializeField] Transform playerSpawn;
    [SerializeField] GameObject player;
    [SerializeField] GameObject shelf;
    [SerializeField] GameObject chair;
    [SerializeField] GameObject table;
    [SerializeField] GameObject ambulance;

    public int levelSelected;

    private void Awake()
    {
        environmentObjectSpawn();
        Instantiate(player, playerSpawn.position, playerSpawn.rotation);
    }
   


    // THIS IS USED TO SPAWN ALL THE ENVIRONMENT OBJECT AND MUST BE CALLED BEFORE PLAYER IS SPAWNED IF MORE LEVELS ARE ADDED IN FUTURE

    void environmentObjectSpawn()
    {
        switch (levelSelected)
        {

            case 1:
                break;



            default:
                break;
        }

    }








}
