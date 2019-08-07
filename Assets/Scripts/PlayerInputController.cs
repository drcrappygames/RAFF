using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public static PlayerInputController Instance { get; private set; }

    private Camera _camera;
    private ForceCalculator _forceCalculator;
    private PlayerMotor _playerMotor;
    private EffectDisplayer _effectDisplayer;
    private Vector3 _inputPoint;
    private bool _waitingForStart = true;
    private bool _blockControls = false;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _camera = Camera.main;
        _forceCalculator = GetComponent<ForceCalculator>();
        _playerMotor = GetComponent<PlayerMotor>();
        _effectDisplayer = GetComponent<EffectDisplayer>();

        GameController.PlayerFailed += OnPlayerFailed;
        LostPanelController.GameContinue += OnPlayerContinue;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_blockControls)
                return;

            if (_waitingForStart)
            {
                _waitingForStart = false;
                GameController.Instance.StartGameplay();
            }
            _inputPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
            _playerMotor.ShootForce = _forceCalculator.GenerateForce();

            AttractingMove();
        }
    }
    private void OnDisable()
    {
        GameController.PlayerFailed -= OnPlayerFailed;
        LostPanelController.GameContinue -= OnPlayerContinue;
    }

    private void OnPlayerFailed()
    {
        _blockControls = true;
    }
    private void OnPlayerContinue()
    {
        _blockControls = false;
    }

    private void RepellingMove()
    {
        _playerMotor.ShootPlayerFromPosition(_inputPoint);
        PointsController.Instance.AddPoints(1);
    }
    private void AttractingMove()
    {
        _playerMotor.MoveTowardsPosition(_inputPoint);
    }
}
