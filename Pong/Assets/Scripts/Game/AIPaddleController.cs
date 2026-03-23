using UnityEngine;

namespace WalnutIdeas
{
    public class AIPaddleController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform ball;
        [SerializeField] private Rigidbody2D ballRb;

        [Header("Movement")]
        [SerializeField] private float moveSpeed = 6f;
        [SerializeField] private float deadZone = 0.25f;
        [SerializeField] private float centerY = 0f;

        [Header("Limits")]
        [SerializeField] private float minY = -4f;
        [SerializeField] private float maxY = 4f;

        [Header("AI Side")]
        [SerializeField] private bool isRightSide = true;

        private void Update()
        {
            if (ball == null || ballRb == null) return;

            bool ballComingToAI = isRightSide ? ballRb.linearVelocity.x > 0f : ballRb.linearVelocity.x < 0f;
            float targetY = ballComingToAI ? ball.position.y : centerY;

            float currentY = transform.position.y;
            float direction = 0f;

            if (targetY > currentY + deadZone)
                direction = 1f;
            else if (targetY < currentY - deadZone)
                direction = -1f;

            Vector3 newPosition = transform.position + Vector3.up*direction*moveSpeed*Time.deltaTime;
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = newPosition;
        }
    }
}
