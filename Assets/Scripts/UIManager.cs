using UnityEngine;
using TMPro;

namespace FlappyBird
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI score;
        [SerializeField] GameObject gameOverPanel;

        public void UpdateScore()
        {
            if (score != null)
                score.text = GameManager.Instance.scoreCount.ToString();
        }

        public void GameOverScreen()
        {
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);
        }
    }
}