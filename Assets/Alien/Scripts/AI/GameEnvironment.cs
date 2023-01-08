using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Added since we need to use 'OrderBy' to sort waypoint sequence.

// This script gets all the checkpoints from the scene and makes tham avaliable as an array
//  used by the patrol script to control navigation of enemys

// Doesnt need to inherit from MonoBehaviour since we dont use it in the inspector
public sealed class GameEnvironment
{
    // Create a static instance of the GameEnvironment class
    private static GameEnvironment instance;

    // Create a list of game objects called "checkpoints"
    private List<GameObject> checkpoints = new List<GameObject>();

    // Create public reference (getter) for retrieving checkpoints list
    //  This is because We dont want other classes to be able to edit the list
    public List<GameObject> Checkpoints { get { return checkpoints; } }

    // Create singleton if it doesn't already exist and populate list with any objects found with tag set to "Checkpoint".
    // We are using a static singleton because its easier to access and more efficient
    // (dont have to create a new object and fill the checkpoints every time)
    public static GameEnvironment Singleton
    {
        get
        {
            // If we have no static instance create one
            if(instance == null)
            {
                instance = new GameEnvironment();
                // Get all the checkpoint gameobjects and add them
                instance.Checkpoints.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint"));

                // Order waypoints in ascending alphabetical order by name, so that the enemy follows them correctly
                // Dont really need this (since the checkpoints are followered randomlly)
                instance.checkpoints = instance.checkpoints.OrderBy(waypoint => waypoint.name).ToList(); 
            // If we have a static instance, but the Checkpoints have changed (EG when loading two levels in one session), create new static instance
            } else if(instance.Checkpoints[0] == null){
                instance = new GameEnvironment();
                instance.Checkpoints.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint"));

                instance.checkpoints = instance.checkpoints.OrderBy(waypoint => waypoint.name).ToList(); // Order waypoints in ascending alphabetical order by name, so that the NPC follows them correctly.
            }
            return instance;
        }
    }

}