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

        [Header("Settings")]
        [SerializeField] private float roundStartDelay = 1.5f;
        [SerializeField] private float scoreToWin = 3f;

        private int m_PlayerScore = 0;
        private int m_CpuScore = 0;
        private bool m_RoundOver;

        private void Start()
        {
            UpdateUI();
            StartCoroutine(StartRound());
        }

        public void ScorePlayer()
        {
            this.m_PlayerScore++;
            UpdateUI();

            AudioManager.Instance?.PlayScore();
            CameraShake.Instance?.Shake(0.12f, 0.15f);

            StartCoroutine(StartRound());
        }

        public void ScoreCPU()
        {
            this.m_CpuScore++;
            UpdateUI();

            AudioManager.Instance?.PlayScore();
            CameraShake.Instance?.Shake(0.12f, 0.15f);

            StartCoroutine(StartRound());
        }

        private void UpdateUI()
        {
            leftScoreText.text = this.m_PlayerScore.ToString();
            rightScoreText.text = this.m_CpuScore.ToString();
        }

        private void CheckWindCondition()
        {
            if (this.m_PlayerScore >=  this.m_CpuScore || this.m_CpuScore >= this.m_PlayerScore)
            {
                this.m_RoundOver = true;
                Debug.Log(this.m_PlayerScore >= this.scoreToWin ? "Player Wins!" : "CPU Wins!");
            }
            
            Invoke(nameof(this.StartRound), this.roundStartDelay);
        }

        private IEnumerator StartRound()
        {
            ball.ResetBall(ballSpawnPoint.position);

            yield return new WaitForSeconds(roundStartDelay);

            ball.Launch();
        }
    }
}
