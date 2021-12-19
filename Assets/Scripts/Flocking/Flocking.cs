using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    // spawn variables
    [Header("Spawn Setup")]
    [SerializeField] private FlockBehaviour flockingBee;
    [SerializeField] private int flockSize;
    [SerializeField] private Vector3 spawner;

    // speed variables 
    [Header("Speed Setup")]
    [Range(0, 10)]
    [SerializeField] private float _minSpeed;
    public float minSpeed { get { return _minSpeed; } }
    
    [Range(0, 10)]
    [SerializeField] private float _maxSpeed;
    public float maxSpeed { get { return _maxSpeed; } }


    // flock detection variables
    [Header("Detection Distance")]

    [Range(0,10)]
    [SerializeField] private float _cohesionDistance;
    public float cohesionDistance { get { return _cohesionDistance; } }

    [Range(0, 10)]
    [SerializeField] private float _avoidanceDistance;
    public float avoidanceDistance { get { return _avoidanceDistance; } }

    [Range(0, 10)]
    [SerializeField] private float _alignmentDistance;
    public float alignmentDistance { get { return _alignmentDistance; } }

    [Range(0, 100)]
    [SerializeField] private float _confinementDistance;
    public float confinementDistance { get { return _confinementDistance; } }

    [Range(0, 100)]
    [SerializeField] private float _obstacleDistance;
    public float obstacleDistance { get { return _obstacleDistance; } }


    // flock behaviour strength
    [Header("Weights")]

    [Range(0, 10)]
    [SerializeField] private float _cohesionWeight;
    public float cohesionWeight { get { return _cohesionWeight; } }

    [Range(0, 10)]
    [SerializeField] private float _avoidanceWeight;
    public float avoidanceWeight { get { return _avoidanceWeight; } }

    [Range(0, 10)]
    [SerializeField] private float _aligementWeight;
    public float aligementWeight { get { return _aligementWeight; } }

    [Range(0, 10)]
    [SerializeField] private float _confinementWeight;
    public float confinementWeight { get { return _confinementWeight; } }

    [Range(0, 100)]
    [SerializeField] private float _obstacleWeight;
    public float obstacleWeight { get { return _obstacleWeight; } }


    public FlockBehaviour[] allBee { get; set;}

    // instantiate flock units
    private void Start()
    {
        GenerateBee();
    }

    private void Update()
    {
        for (int i = 0;  i < allBee.Length; i++){
            allBee[i].MoveBee();
        }
    }


    // instantiate bees within specified field size

    private void GenerateBee()
    {
        allBee = new FlockBehaviour[flockSize];
        for(int i = 0; i < flockSize; i++)
        {
            var randomVector = Random.insideUnitSphere;
            randomVector = new Vector3(randomVector.x * spawner.x, randomVector.y 
                * spawner.y, randomVector.z * spawner.z);

            var spawnPosition = transform.position + randomVector;
            var rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            allBee[i] = Instantiate(flockingBee, spawnPosition, rotation);
            allBee[i].AssignFlock(this);
            allBee[i].InitialiseSpeed(Random.Range(minSpeed, maxSpeed));
         }
    }


        


 }
