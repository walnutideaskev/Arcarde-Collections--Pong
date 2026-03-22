using UnityEngine;

namespace WalnutIdeas
{
    public class GoalController : MonoBehaviour
    {
        public bool isLeftGoal;
        public PongManager manager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Ball"))
                return;

            if (isLeftGoal)
                manager.ScoreRight();
            else
                manager.ScoreLeft();
        }
    }
}
