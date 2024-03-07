using UnityEngine;

public class GoalController : MonoBehaviour
{

    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private int _index = 0;

    public int CurrentScore{get; private set;}
    private int _currentScore = 0;
    private AudioSource _goalSound;

    private void Awake()
    {
        _goalSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _goalSound.Play();
        _currentScore += 1;
        _scoreView.SetScore(_index, _currentScore);
    }  
}