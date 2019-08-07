using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private Vector2 _minSpawnPosition;
    [SerializeField] private Vector2 _maxSpawnPosition;
    [SerializeField] private GameObject _pointPrefab;
    [SerializeField] private Transform _pointsHolder;
    [SerializeField] private TMPro.TextMeshProUGUI _pointsCounterText;

    public static PointsController Instance { get; private set; }
    public int Points { get { return _points; }
        private set
        {
            _points = value;
            _pointsCounterText.text = _points.ToString();
        }
    }
    public int HighestScore { get; private set; }
    private int _points;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnPoint()
    {
        GameObject coin = Instantiate(_pointPrefab, _pointsHolder);
        coin.GetComponent<RectTransform>().anchoredPosition = GetRandomPosition();
    }

    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(_minSpawnPosition.x, _maxSpawnPosition.x);
        float y = Random.Range(_minSpawnPosition.y, _maxSpawnPosition.y);

        return new Vector2(x, y);
    }
    public bool AddPoints(int ammount)
    {
        if (ammount < 0)
            return false;

        Points += ammount;
        if (CheckHighestScore())
            HighestScore = Points;

        SpawnPoint();
        return true;
    }
    public void ResetPoints()
    {
        Points = 0;
    }
    public bool CheckHighestScore()
    {
        if (Points > HighestScore)
            return true;
        return false;
    }
}
