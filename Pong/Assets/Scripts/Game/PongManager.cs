using UnityEngine;
using TMPro;
using System.Collections;

namespace WalnutIdeas
{
    public class PongManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private BallController ball;
        [SerializeField] private Transform ballSpawnPoint;
        [SerializeField] private TextMeshProUGUI leftScoreText;
        [SerializeField] private TextMeshProUGUI rightScoreText;
        [SerializeField] private TextMeshProUGUI winnerTextBox;

        [Header("Settings")]
        [SerializeField] private float roundStartDelay = 1.5f;
        [SerializeField] private int scoreToWin = 3;

        private int m_PlayerScore = 0;
        private int m_CpuScore = 0;
        private bool m_RoundOver = false;

        private void Start()
        {
            UpdateUI();
            StartCoroutine(StartRound());
            this.winnerTextBox.gameObject.SetActive(false);
        }

        public void ScorePlayer()
        {
            if (m_RoundOver) return;

            m_PlayerScore++;
            UpdateUI();

            AudioManager.Instance?.PlayScore();
            CameraShake.Instance?.Shake(0.12f, 0.15f);

            CheckWinCondition();
        }

        public void ScoreCPU()
        {
            if (m_RoundOver) return;

            m_CpuScore++;
            UpdateUI();

            AudioManager.Instance?.PlayScore();
            CameraShake.Instance?.Shake(0.12f, 0.15f);

            CheckWinCondition();
        }

        private void UpdateUI()
        {
            if (leftScoreText != null)
                leftScoreText.text = m_PlayerScore.ToString();

            if (rightScoreText != null)
                rightScoreText.text = m_CpuScore.ToString();
        }

        private void CheckWinCondition()
        {
            if (m_PlayerScore >= scoreToWin)
            {
                m_RoundOver = true;
                //Debug.Log("Player Wins!");
                this.winnerTextBox.gameObject.SetActive(true);
                this.winnerTextBox.text = "Player Win";
                ball.ResetBall(ballSpawnPoint.position);
                return;
            }

            if (m_CpuScore >= scoreToWin)
            {
                m_RoundOver = true;
                this.winnerTextBox.gameObject.SetActive(true);
                this.winnerTextBox.text = "CPU Win";
                ball.ResetBall(ballSpawnPoint.position);
                return;
            }

            StartCoroutine(StartRound());
        }

        private IEnumerator StartRound()
        {
            ball.ResetBall(ballSpawnPoint.position);

            yield return new WaitForSeconds(roundStartDelay);

            if (!m_RoundOver)
                ball.Launch();
        }
    }
}