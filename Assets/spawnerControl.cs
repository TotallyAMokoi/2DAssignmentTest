using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerControl : MonoBehaviour
{
    //Will only create one per
    //Arrays for spawn position and (de)buff spawned
    // not needed but keeping for documentation sake:  public Transform[] spawnPoint;
    //made private because apparently that's how to fix "array is out of range" or whatever
    //Never fucking mind that didn't do shit either
    public List<GameObject> spawnEmpty = new List<GameObject>();
    public GameObject[] buff;
    //for the loop I think?
    public int totalSpawns;
    public int currentSpawn;
    public int frame;
    // Use this for initialization
    void Start()
    {

        //ignore these errors
        int totalSpawns = 2;
        int currentSpawn = 0;
        int frame = 1;
        //moved loop to update
    }

    

    void spawnAThing()
    {
        currentSpawn++;

        //Chooses spawn point from 5 waypoints
        int spawnHere = Random.Range(0, spawnEmpty.Count);
        //"""Chooses""" between buff or debuff
        //Never chooses the last one
        int whichBuff = Random.Range(0, 3);

        //!!!ASK SIR HOW TO REMOVE PART OF AN ARRAY AFTER RUNNING!!!

        /*      HIDDEN/COMMENTED FOR TESTING
                //Actually spawn it
                Instantiate(buff[whichBuff], spawnPoint[spawnHere].position, spawnPoint[spawnHere].rotation);*/
        
        //Should make the object deletable to prevent two things spawning in the wrong spot


        Instantiate(buff[whichBuff], spawnEmpty[spawnHere].transform.position, spawnEmpty[spawnHere].transform.rotation);
        Debug.Log("spawned a thing");
        //keeps spawning seven for some reason...
        //moving the loop to update fixed that

        spawnEmpty.RemoveAt(spawnHere);


        //Likes putting several in the same spot even with this in place?!?!?
        //maybe if I try breaking it?
        //nope
        //As it is it still fits the requirement for the assignment
        //But this still bothers me...
        //http://i.imgur.com/siA7C.gif

        
        
    }

    // Update is called once per frame    
    //Change fixedupdate to update if this doesn't fix the doublespawn issue
    void FixedUpdate()
    {
        if (frame == 9)
        {
            frame = 0;
            Debug.Log("Frame count stopped");
        }
        else if (frame != 0)
        {
            Debug.Log("Frame:" + frame);
            if (frame != 2 && frame != 3)
            {
                while (currentSpawn < totalSpawns)
                {
                    spawnAThing();
                }
            }
            frame = frame + 1;

        }
        // https://www.youtube.com/watch?v=fvtQYsckLxk
    }
}
//I fucking did it
//I am amazing
//Suck my raycast, Kevin
//I am not a useless cunt
//
//░░░░░░░░▄▄▄███░░░░░░░░░░░░░░░░░░░░
//░░░▄▄██████████░░░░░░░░░░░░░░░░░░░
//░███████████████░░░░░░░░░░░░░░░░░░
//░▀███████████████░░░░░▄▄▄░░░░░░░░░
//░░░███████████████▄███▀▀▀░░░░░░░░░    LIKE
//░░░░███████████████▄▄░░░░░░░░░░░░░    A
//░░░░▄████████▀▀▄▄▄▄▄░▀░░░░░░░░░░░░    BOSS
//▄███████▀█▄▀█▄░░█░▀▀▀░█░░▄▄░░░░░░░
//▀▀░░░██▄█▄░░▀█░░▄███████▄█▀░░░▄░░░
//░░░░░█░█▀▄▄▀▄▀░█▀▀▀█▀▄▄▀░░░░░░▄░▄█
//░░░░░█░█░░▀▀▄▄█▀░█▀▀░░█░░░░░░░▀██░
//░░░░░▀█▄░░░░░░░░░░░░░▄▀░░░░░░▄██░░
//░░░░░░▀█▄▄░░░░░░░░▄▄█░░░░░░▄▀░░█░░
//░░░░░░░░░▀███▀▀████▄██▄▄░░▄▀░░░░░░
//░░░░░░░░░░░█▄▀██▀██▀▄█▄░▀▀░░░░░░░░
//░░░░░░░░░░░██░▀█▄█░█▀░▀▄░░░░░░░░░░
//░░░░░░░░░░█░█▄░░▀█▄▄▄░░█░░░░░░░░░░                                                                               tho if it turns out actually
//░░░░░░░░░░█▀██▀▀▀▀░█▄░░░░░░░░░░░░░                                                                               not working cos my ten tests
//░░░░░░░░░░░░▀░░░░░░░░░░░▀░░░░░░░░░                                                                               wasn't enough I'll kms