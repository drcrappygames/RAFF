using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Some algorithms on generating that force later (patterns etc)
public class ForceCalculator : MonoBehaviour
{
    [SerializeField] private float _force = 20f;

    public float GenerateForce()
    {
        return _force + (PointsController.Instance.Points /2f);
    }
}
