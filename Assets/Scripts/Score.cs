using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hastriggered;

    private InGameManager _scoreManager;

    private void Start()
    {
        _scoreManager = InGameManager.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hastriggered)
        {
            hastriggered = true;
            _scoreManager.ChangeScore(value);
        }
    }
}
