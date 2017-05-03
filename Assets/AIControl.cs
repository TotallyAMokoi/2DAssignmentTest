using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    public Transform[] waypoints;
    public bool crouch = false;
    public bool jump = false;
    public float stoppingDistance = 5f;

    private Player character;
    private int currentPoint = 0;
    private float distance = 0;

    // Use this for initialization
    void Start()
    {
        character = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        float playerPosX = transform.position.x;
        float waypointPosX = GetWaypointPos().x;
        float move = 0;
        if (playerPosX > waypointPosX)
        {
            move = -1;
        }
        else
        {
            move = 1;
        }
        character.Move(move, crouch, jump);
        jump = false;
    }

    Vector3 GetWaypointPos()
    {
        Vector3 waypointPos = waypoints[currentPoint].position;
        distance = Vector3.Distance(transform.position, waypointPos);

        if (distance <= stoppingDistance)
        {
            currentPoint++;
        }
        if (currentPoint >= waypoints.Length)
        {
            currentPoint = 0;
        }
        return waypoints[currentPoint].position;
    }
}
