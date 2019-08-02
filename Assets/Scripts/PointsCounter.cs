using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _pointsCounterText;

    public static PointsCounter Instance { get; private set; }
    public int Points { get { return _points; }
        private set
        {
            _points = value;
            _pointsCounterText.text = _points.ToString();
        }
    }
    public int HighestScore { get; private set; }
    
    private int _points;
    private void Start()
    {
        Instance = this;
    }

    public bool AddPoints(int ammount)
    {
        if (ammount < 0)
            return false;

        Points += ammount;
        if (CheckHighestScore())
            HighestScore = Points;
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
