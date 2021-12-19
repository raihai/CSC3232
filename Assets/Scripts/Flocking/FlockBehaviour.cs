using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockBehaviour : MonoBehaviour
{
    // assign variable 
    [SerializeField] private float FOVAngle;
    [SerializeField] private float smoothDamp;
    [SerializeField] private LayerMask terrainMask;
    [SerializeField] private Vector3[] avoidDirections;

    // Flock variables 
    private List<FlockBehaviour> cohesionNeighbours = new List<FlockBehaviour>();
    private List<FlockBehaviour> avoidanceNeighbours = new List<FlockBehaviour>();
    private List<FlockBehaviour> alignmentNeighbours = new List<FlockBehaviour>(); 
    private Flocking assignedFlock;
    private Vector3 currentVelocity;
    private float moveSpeed;
    private Vector3 currentAvoidDirection;


    public Transform unitTransform { get; set; }

    private void Awake()
    {
        unitTransform = transform;
    }

    public void AssignFlock(Flocking flock)
    {
        assignedFlock = flock;
    }


    public void InitialiseSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
       
    }

    // control movement of the flock
    public void MoveBee()
    {
        LocateNeighbour();
        CalculateSpeed();
        var cohesionVector = CalculateCohesionVector() * assignedFlock.cohesionWeight;
        var avoidanceVector = CalculateAvoidanceVector() * assignedFlock.avoidanceDistance;
        var alignmentVector = CalculateAlignmentVector() * assignedFlock.aligementWeight;
        var confinementVector = CalculateConfinementVector() * assignedFlock.confinementWeight;
        var obstacleVector = CalculateObstaclesVector() * assignedFlock.obstacleWeight;

        var moveVector = cohesionVector + avoidanceVector + alignmentVector + confinementVector + obstacleVector;
        moveVector = Vector3.SmoothDamp(unitTransform.forward, moveVector, ref currentVelocity, smoothDamp);
        moveVector = moveVector.normalized.normalized * moveSpeed;
        if (moveVector == Vector3.zero)
            moveVector = transform.forward;

        unitTransform.forward = moveVector;
        unitTransform.position += moveVector * Time.deltaTime;
    }


    // method to find all bee unit in the flock and calculate the distance between them
    private void LocateNeighbour()
    {
        cohesionNeighbours.Clear();
        avoidanceNeighbours.Clear();
        alignmentNeighbours.Clear();

        var allBees = assignedFlock.allBee;
        for (int i = 0; i < allBees.Length; i++)
        {
            var currentBee = allBees[i];
            if(currentBee != this)
            {
                float currentNeighbourDistanceSqr = Vector3.SqrMagnitude(currentBee.transform.position - transform.position);
                if(currentNeighbourDistanceSqr <= assignedFlock.cohesionDistance * assignedFlock.cohesionDistance)
                {
                    cohesionNeighbours.Add(currentBee);
                }
                if (currentNeighbourDistanceSqr <= assignedFlock.avoidanceDistance * assignedFlock.avoidanceDistance)
                {
                    avoidanceNeighbours.Add(currentBee);
                }
                if (currentNeighbourDistanceSqr <= assignedFlock.alignmentDistance * assignedFlock.alignmentDistance)
                {
                    alignmentNeighbours.Add(currentBee);
                }
            }
        } 
    }

    // flock unit speed within the confinement space
    private void CalculateSpeed()
    {
        if(cohesionNeighbours.Count == 0)
        {
            return;
        }
        moveSpeed = 0;
        for (int i = 0; i < cohesionNeighbours.Count; i++)
        {
            moveSpeed += cohesionNeighbours[i].moveSpeed;
        }
        moveSpeed /= cohesionNeighbours.Count;
        moveSpeed = Mathf.Clamp(moveSpeed, assignedFlock.minSpeed, assignedFlock.maxSpeed);
    }

    // depending on the cohesion vector, flock unit move closer 

    private Vector3 CalculateCohesionVector()
    {
        var cohesionVector = Vector3.zero;
        if(cohesionNeighbours.Count == 0)
        {
            return cohesionVector;
        }


        int neighboursInFOV = 0;
        for(int i = 0; i < cohesionNeighbours.Count; i++)
        {
            if (IsInFOV(cohesionNeighbours[i].unitTransform.position))
            {
                neighboursInFOV++;
                cohesionVector += cohesionNeighbours[i].unitTransform.position;
            }
        }
        if (neighboursInFOV == 0)
            return cohesionVector;
        cohesionVector /= neighboursInFOV;
        cohesionVector -= unitTransform.position;
        cohesionVector = cohesionVector.normalized;

        return cohesionVector;

    }

    // alignment range of the flock unit
    private Vector3 CalculateAlignmentVector()
    {
        var alignmentVector = unitTransform.forward;
        if(alignmentNeighbours.Count == 0)
        {
            return alignmentVector;
        }

        int neighboursInFOV = 0;
        for (int i = 0; i < alignmentNeighbours.Count; i++)
        {
            if (IsInFOV(alignmentNeighbours[i].unitTransform.position))
            {
                neighboursInFOV++;
                alignmentVector += alignmentNeighbours[i].unitTransform.forward;
            }
        }
       
        alignmentVector /= neighboursInFOV;
        alignmentVector = alignmentVector.normalized;
        return alignmentVector;

    }

    // calculate the avoidance range of the flock units
    private Vector3 CalculateAvoidanceVector()
    {
        var avoidanceVector = Vector3.zero;
        if (avoidanceNeighbours.Count == 0)
        {
            return Vector3.zero;
        }

        int neighboursInFOV = 0;
        for (int i = 0; i < avoidanceNeighbours.Count; i++)
        {
            if (IsInFOV(avoidanceNeighbours[i].unitTransform.position))
            {
                neighboursInFOV++;
                avoidanceVector += (unitTransform.position - avoidanceNeighbours[i].unitTransform.position);
            }
        }
       
        avoidanceVector /= neighboursInFOV;
        avoidanceVector = avoidanceVector.normalized;
        return avoidanceVector;
    }

    // bound size of flock 
    private Vector3 CalculateConfinementVector()
    {
        var offsetToCenter = assignedFlock.transform.position - unitTransform.position;
        bool isNearCenter = (offsetToCenter.magnitude >= assignedFlock.confinementDistance * 0.9f);
        return isNearCenter ? offsetToCenter.normalized : Vector3.zero;
    }

    // calcuate obstacle distance from flock unit
    private Vector3 CalculateObstaclesVector()
    {
        var obstacleVector = Vector3.zero;
        RaycastHit hit;
        if (Physics.Raycast(unitTransform.position, unitTransform.forward, out hit, assignedFlock.obstacleDistance, terrainMask))
        {
            obstacleVector = OptimalObstacleAvoidance();
        }
        else
        {
            currentAvoidDirection = Vector3.zero;
        }
        return obstacleVector;
    }

    // redirect flock unit away from obstacle using the most optimal path
    private Vector3 OptimalObstacleAvoidance()
    {
        if (currentAvoidDirection != Vector3.zero)
        {
            RaycastHit hit;
            if (!Physics.Raycast(unitTransform.position, unitTransform.forward, out hit, assignedFlock.obstacleDistance, terrainMask))
            {
                return currentAvoidDirection;
            }
        }
        float maxDistance = int.MinValue;
        var optimalDirection = Vector3.zero;
        for (int i = 0; i < avoidDirections.Length; i++)
        {

            RaycastHit hit;
            var currentDirection = unitTransform.TransformDirection(avoidDirections[i].normalized);
            if (Physics.Raycast(unitTransform.position, currentDirection, out hit, assignedFlock.obstacleDistance, terrainMask))
            {

                float currentDistance = (hit.point - unitTransform.position).sqrMagnitude;
                if (currentDistance > maxDistance)
                {
                    maxDistance = currentDistance;
                    optimalDirection = currentDirection;
                }
            }
            else
            {
                optimalDirection = currentDirection;
                currentAvoidDirection = currentDirection.normalized;
                return optimalDirection.normalized;
            }
        }
        return optimalDirection.normalized;
    }

    private bool IsInFOV(Vector3 position)
    {
        return Vector3.Angle(unitTransform.forward, position - unitTransform.position) <= FOVAngle;

    }
}
