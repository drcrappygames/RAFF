using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Some algorithms on generating that force later (patterns etc)
public class ForceCalculator : MonoBehaviour
{
    [SerializeField] private float _minimalForce;
    [SerializeField] private float _maximalForce;

    public float Force { get; private set; }
    public void RecalculateForce()
    {
        Force = GenerateRandomForce();
    }

    private void Start()
    {
        RecalculateForce();
    }
    private float GenerateRandomForce()
    {
        return Random.Range(_minimalForce, _maximalForce);
    }
}
