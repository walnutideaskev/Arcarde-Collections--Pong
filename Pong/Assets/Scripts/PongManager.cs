using UnityEngine;
using TMPro;
using System.Collections;

namespace WalnutIdeas
{
    public class PongManager : MonoBehaviour
    {
        [Header("References")]
        public BallController ball;
        public Transform ballSpawnPoint;

        public TextMeshProUGUI leftScoreText;
        public TextMeshProUGUI rightScoreText;

        [Header("Settings")]
        public float roundStartDelay = 1f;

        private int m_LeftScore = 0;
        private int m_RightScore = 0;

        private void Start()
        {
            UpdateUI();
            StartCoroutine(StartRound());
        }

        public void ScoreLeft()
        {
            this.m_LeftScore++;
            UpdateUI();

            AudioManager.Instance?.PlayScore();
            CameraShake.Instance?.Shake(0.12f, 0.15f);

            StartCoroutine(StartRound());
        }

        public void ScoreRight()
        {
            this.m_RightScore++;
            UpdateUI();

            AudioManager.Instance?.PlayScore();
            CameraShake.Instance?.Shake(0.12f, 0.15f);

            StartCoroutine(StartRound());
        }

        private void UpdateUI()
        {
            leftScoreText.text = this.m_LeftScore.ToString();
            rightScoreText.text = this.m_RightScore.ToString();
        }

        private IEnumerator StartRound()
        {
            ball.ResetBall(ballSpawnPoint.position);

            yield return new WaitForSeconds(roundStartDelay);

            ball.Launch();
        }
    }
}
