using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private float timeToReloadScene;

        [Space, SerializeField]
        private UnityEvent onGameOver;
        [SerializeField]
        private UnityEvent onIncreaseScore;

        public bool isGameOver { get; private set; }
        public int scoreCount { get; private set; }

        public static GameManager Instance
        {
            get; private set;
        }

        private void Awake()
        {
            if (Instance != null)
                DestroyImmediate(gameObject);
            else
                Instance = this;
        }

        public void GameOver()
        {
            Debug.Log("GameManager :: GameOver()");

            isGameOver = true;

            if (onGameOver != null)
                onGameOver.Invoke();
        }

        public void RestartGame()
        {
            StartCoroutine(ReloadScene());
        }

        public void IncreaseScore()
        {
            scoreCount++;

            if (onIncreaseScore != null)
                onIncreaseScore.Invoke();
        }

        private IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(timeToReloadScene);

            SceneManagerC.Instance.LoadScene_(1);
        }
    }
}