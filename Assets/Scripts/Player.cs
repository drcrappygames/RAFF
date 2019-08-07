using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basically just an identifier
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private RectTransform _playerTransform;
    [SerializeField] private float _xMultipler;
    [SerializeField] private float _yMultipler;

    private Vector2 _velocity;
    private Vector2 _direction;
    private float _vectorLength;

    private void Start()
    {
    }
    private void Update()
    {
  //      ScaleByVelocity();
    }

    private void ScaleByVelocity()
    {
        _direction = _playerRigidbody.velocity.normalized;
        
        if(_direction.x > _direction.y)
        {

        }
    }
}

