using UnityEngine;
//using System.Collections;
using System.Collections.Generic;
public class Admiral : MonoBehaviour
{
    //Class will be assigned to a 'Mothership' object
    //Distinguish target groups for Red Leader based on damage capability and fragility
    //Determine if the battle is won or lost, and execute mop up or retreat commands as needed.
    //Overall positioning and movement of the Battle Group.
    //Disabled if the 'Mothership' Object is destroyed

    //What decides an Admiral is needed for a fleet/group? (activated by the player or Creator)
    //How will this command set be activated? 
    //What controls the Admiral?
    //How does it select targets?

    //AI ships will be under the assumptions of the Dark Forest theory of Cosmic Sociology.  Thus, their primary goal is long term survival.

    //AI controlled ships will have a specific tag/marker associated with them, that tells the scripts to grab them and use them.
    //They will also contain a faction tag to use for IFF and fleet organization purposes.

    //structure is extremely similar to a binary search tree - should that function be used to organize the fleet?
    //If so, what limits will that impose on the AI? What innate advantages?
    public Transform mothership;
    private Vector3 groupPosition;
    private Vector3 groupVelocity;
    private Vector3 groupBoundary;

    public int factionNumber;
    public bool aiUsableTag;

    private delegate float groupFormation(float x, float z, float t);
    private delegate float squad();
    private squad[] squads;
    private static List<int> freq = new List<int>();
    private static List<int> latestStatus = new List<int>();
    private static List<int> prevStatus = new List<int>();
    
    [Range(0, 2)]
    public int evasive = 0;
    
    private void Awake ()
    {

    }

    private void Update ()
    {
        //Check for Mothership, if no mothership, set Red Leaders to autonomous mode and kill the script
    }

    //Looks for nearby AI ships and assigns squad leaders, frequencies, and tells them they are under Admiral control
    private void CreateFleet()
    {
        //Look for nearby (quantitize) AI-tagged objects of the same faction
        //Assign all ships to a temporary array/list, sorted by size/weight/speed, largest to smallest
        //1 RedLeader per multiple of 5 if less then 45 ships.  1 RedLeader per multiple of 10 if greater than 46
        //Assign frequencies to RedLeaders.  Assign ships per previous conditions to each RedLeader
        //initialize RedLeaders to form basic static formation around mothership
        //Assign initial Fleet Strength values for later use
        ReportFleetStatus();
        //If there are only 1-2 other ships, assign 1 RedLeader to the mothership and initialize Individual.Dog() protocol
    }

    //fetches evasive value
    private int getEvasive()
    {
        return evasive;
    }

    //Each Red Leader is assigned a float to distinguish them from one another.  GetFrequency checks for this float and assigns new ones.
    public static int getFrequency(int f)
    {
        if (freq.Count == 0)
        {
            //set f to frequency 1f
            f = 1;
            //store it in the list
            freq.Insert(0, f);
            return f;
        }
        else
        {
            bool isContained = freq.Contains(f);
            if (isContained == false)
            {
                //set f to a new frequency
                f = freq.Count;
                //store it in the list
                freq.Add(f);
                return f;
            }
            else
            {
                return f;
            }
        }
    }

    //simply removes the frequency from the list.  The Remove() function is built to handle values outside of the list
    private void RemoveFrequency(int f)
    {
            //delete frequency
            freq.Remove(f);
    }

    private void ReportFleetStatus()
    {
        //checks lists for # of Red Leaders, then asks red leaders to report in
        //first compare latestStatus to prevStatus, determine the change in fleet strength over time.  Save seperately.
        //Then clear prevStatus, copy latestStatus to it, then clear latestStatus
        prevStatus.clear();
        prevStatus.AddRange(latestStatus);
        latestStatus.Clear();
        //for each attached RedLeader, request an update and store in latestStatus
        freq.ForEach(delegate(int f)
        {
            latestStatus.Add(RedLeader.GetSquadStatus(f));
        });
        //compare latestStatus to prevStatus, determine the change in fleet strength over time.  Save seperately.
    }

    private System.Collections.IEnumerator Passive()
    {
        //set groupVelocity to 0
        //Contract groupBoundary to tighten the group
        //set Red Leaders to passive state
    }

    //Complex behavior
    private System.Collections.IEnumerator Ambush()
    {
        //find target location and set ambush locations at perpindicular locations
        //enlarge group Boundary to enclose both the enemy group and friendly group
        //equally distribute Red Leader groups between all ambush locations
        //upon arrival, jump into Attack()
        //If detected and fired upon, abandon positioning attempt and jump into Attack()
    }

    private System.Collections.IEnumerator Attack()
    {
        //set Red Leaders to Attack state.
        //monitor group status and victory/defeat probability
        //if defeat inevitable after a mass-proportionate amount of time, retreat or regroup.
        //if victory inevitable, continue the attack until all enemy units are defeated.
        //some sort of method to prevent excessive chasing of retreating enemy units
    }

    private System.Collections.IEnumerator Retreat()
    {
        //Set Red Leaders to Withdraw state
        //contract groupBoundary around mothership
        //wait for Red Leaders to check in that their ships are close to the mothership and ready to leave
        //set velocity at full speed away from the enemy and towards a safe coordinate
        //Red Leaders form up behind the mothership and protect it
    }

    private System.Collections.IEnumerator Regroup()
    {
        //Set Red Leaders to Withdraw state
        //contract Group Boundary around mothership
        //wait for Red Leaders to check in
        //reorganize formations and spread damaged ships evenly among the Red Leaders
        //Expand groupBoundary to include the enemy
        //Set Red Leaders to Attack state
    }
}