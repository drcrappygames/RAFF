using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;

    private void Start()
    {
        GameController.PlayerFailed += OnPlayerFailed;
        LostPanelController.GameContinue += OnPlayerContinue;
    }
    private void OnDisable()
    {
        GameController.PlayerFailed -= OnPlayerFailed;
        LostPanelController.GameContinue -= OnPlayerContinue;
    }

    public float ShootForce { get; set; }
    public void ShootPlayerFromPosition(Vector2 position)
    {
        Vector2 direction = _player.position - position;
        _player.AddForce(direction.normalized * ShootForce);
    }

    private void OnPlayerFailed()
    {
        _player.velocity = Vector2.zero;
    }
    private void OnPlayerContinue()
    {

    }
}
