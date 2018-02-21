using UnityEngine;
using System.Collections;
using System;

public class Individual : MonoBehaviour {

    private void Awake()
    {

    }

    public void Handler()
    {

    }

    private static IEnumerator Passive()
    {
        //Cease all activty, set velocity to 0
        yield return 0f;
    }

    private static IEnumerator Flock()
    {
        //Stay X distance from members of the flock
        //Move with the flock
        //Move closer to the flock
        yield return 0f;
    }

    private static IEnumerator Dog()
    {
        //Used for 1-2 solitary formation members
        //follows mothership/Red Leader and protects from enemies approaching within the danger zone.
        yield return 0f;
    }

    private static IEnumerator Formation()
    {
        //Execute given formation unless receiving commands from Red Leader
        yield return 0f;
    }

    private static IEnumerator Alert()
    {
        //If the drone detects an enemy, it will radio Red Leader.  If no orders are received, Drone should attack.
        //Alternatively, set Alert Status to true and await orders.
        yield return 0f;
    }

    private static IEnumerator Dead()
    {
        //Notifies RedLeader of death. 
        //Kills Script
        yield return 0f;
    }
}
