using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public Player player;
    public TMPro.TMP_Text scoreText;

    void Start()
    {
        player.OnScoreChanged += UpdateScore;
    }

    private void UpdateScore(int score)
    {
        scoreText.text = $"{score}";
    }
}
