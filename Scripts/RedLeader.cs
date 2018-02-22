using UnityEngine;
using System.Collections;
using System;
public class RedLeader : MonoBehaviour
{
    //Handles squad tactics and how they interact with other squads
    //Assigns targets to individual pilots for priority
    //Determines if an engagement is winnable or not during the engagement, executes a kill, chase, or flee decision
    //Responsible for oscillating formations while not dogfighting
    //Sets patrol routes and formationss for maximum coverage around the mothership

    //what decides a RedLeader is needed for a fleet/group?
    //How does RedLeader make decisions if Admiral is offline?
    private Vector3 squadPosition;
    private Vector3 squadVelocity;
    private Vector3 squadBoundary;

    private int size;
    private int dead;
    private int frequency = -1;
    private delegate float Pilot();

    private Pilot[] pilots;

    private void Awake()
    {
        if (GetAdmiral() == true)
        {
            frequency = Admiral.getFrequency(frequency);
        }
        else
        {
            frequency = -1;
        }
    }

    private void Update()
    {
        //check how many Pilots are dead, report to Admiral every 60th iteration
        //if all pilots are dead, set state to Dead()
    }

    private bool GetAdmiral()
    {
        if (frequency == -1)
        {
            return false;
        }
        return true; 
    }

    public int GetSquadStatus(int f)
    {
        int status = 000000000;
        //queries the drones for their individual status
        //compiles information and forwards it to the Admiral, if there is one
        return status;
    }
    private int Gather()
    {
        int ready = 0;
        //Set formation type
        //Tell pilots to move to their locations in the formation
        //Wait for pilots to check in
        return ready;
    }
    private void SetAttackFormation()
    {
        //normal mode: sets a static attack formation randomly chosen from an array
        //Deep Learning: sets a static attack formation best suited for the enemy types based on empirical data
    }
    private int MoveTo(Vector3 location)
    {
        int ready = 0;
        //determine bounds of enemy vessels
        //set stagingLocation the same as location if no bounding boxes within X meters
        //set stagingLocation short of location by X meters to avoid bounding boxes
        //set squadVelocity towards stagingLocation
        //wait for squadPosition ~= stagingLocation
        return ready;
    }

    private IEnumerator Passive()
    {
        //Set wedge formation
        //Set squadVelocity to 0
        //Set pilots to Passive state
    }

    private IEnumerator Attack()
    {
        //Choose a target based on parameters
        //Choose an optimal distance (90% of maximum weapons range)
        //Run Gather() to collect the formation and MoveTo() to travel to the enemy
        //Set an evasive priority based on enemy fleet strength (query Admiral) (likelihood of dying in a single shot)
            //priority 0: move to optimal distance, fire at max range, stop moving, continue firing
            //priority 1: move to optimal distance, fire at max range, stop moving, continue firing, oscillate position and formation
            //priority 2: strafe the target in oscillating patterns, maximize damage on the dive, maximize acceleration on the climb out,
        //turn around and strafe again once outside ship maximum weapon range

        //subroutine dogfight() - only used if maneuverable vessel facing other manueverable vessels
        //Vessels will break off into pairs and attack individual fighters at speed.
    }

    private IEnumerator Dogfight()
    {
        //only called by Attack()
        //release control to the Pilots to engage in pairs or individually
        //attempts to fly like Elite: Dangerous with flight assist off
        //OPTIONAL: use RedLeader to give Pilots some group tactics during dogfight
    }

    private IEnumerator Withdraw()
    {
        //All Pilots move to a set retreat formation
        //formation moves with all possible speed to mothership, while oscillating
        //pilots face backwards if possible to maximize firepower on the enemy
        //once back at mothership, send flag to Admiral to check in
    }
    
    private IEnumerator Dead()
    {
        //Remove self from squad array, report to admiral that all are dead, await instructions
        //when dead, RedLeader object goes to an object pool contained in the game world, for faster loading.
    }
}
