using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Added since we need to use 'OrderBy' to sort waypoint sequence.

// this script gets all the checkpoints from the scene and makes tham avaliable as an array
//  used by the patrol script to control navigation of enemys
public sealed class GameEnvironment
{
    // Create an instance of the GameEnvironment class called 'instance'.
    private static GameEnvironment instance;

    // Create a list of game objects called 'checkpoints'
    private List<GameObject> checkpoints = new List<GameObject>();

    // Create public reference for retrieving checkpoints list.
    public List<GameObject> Checkpoints { get { return checkpoints; } }

    // Create singleton if it doesn't already exist and populate list with any objects found with tag set to "Checkpoint".
    public static GameEnvironment Singleton
    {
        get
        {
            // If we have no static instance create one
            if(instance == null)
            {
                instance = new GameEnvironment();
                instance.Checkpoints.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint"));

                instance.checkpoints = instance.checkpoints.OrderBy(waypoint => waypoint.name).ToList(); // Order waypoints in ascending alphabetical order by name, so that the NPC follows them correctly.
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