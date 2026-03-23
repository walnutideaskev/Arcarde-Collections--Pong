using System.Collections;
using UnityEngine;

namespace WalnutIdeas
{
    public class BallController : MonoBehaviour
    {
        public float baseSpeed = 6f;
        public float maxBounceAngle = 60f;
        public float speedIncreasePerHit = 0.2f;
        public float maxSpeed = 14f;

        private Rigidbody2D rb;
        private float speed;

        private Vector3 baseScale;
        private Coroutine squashRoutine;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            baseScale = transform.localScale;
        }

        public void Launch()
        {
            speed = baseSpeed;

            float x = Random.value < 0.5f ? -1f : 1f;
            float y = Random.Range(-0.5f, 0.5f);

            Vector2 dir = new Vector2(x, y).normalized;
            rb.linearVelocity = dir * speed;
        }

        public void ResetBall(Vector3 pos)
        {
            rb.linearVelocity = Vector2.zero;
            transform.position = pos;
        }

        private void FixedUpdate()
        {
            if (rb.linearVelocity.sqrMagnitude > 0.01f)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * speed;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Paddle Hit
            if (collision.gameObject.CompareTag("Paddle"))
            {
                speed = Mathf.Min(speed + speedIncreasePerHit, maxSpeed);

                Transform paddle = collision.transform;

                float paddleHeight = collision.collider.bounds.size.y;
                float offset = transform.position.y - paddle.position.y;

                float normalized = Mathf.Clamp(offset / (paddleHeight / 2f), -1f, 1f);
                float angle = normalized * maxBounceAngle * Mathf.Deg2Rad;

                float dirX = paddle.position.x < 0f ? 1f : -1f;

                Vector2 newDir = new Vector2(dirX, Mathf.Sin(angle)).normalized;
                rb.linearVelocity = newDir * speed;

                // 🎮 GAME FEEL
                AudioManager.Instance?.PlayPaddleHit();
                //CameraShake.Instance?.Shake(0.07f, 0.07f);
                PlaySquash();

                PaddleHitEffect fx = collision.gameObject.GetComponent<PaddleHitEffect>();
                fx?.Play();
            }
            //  Wall Hit
            else if (collision.gameObject.CompareTag("Wall"))
            {
                CameraShake.Instance?.Shake(0.04f, 0.04f);
                AudioManager.Instance?.PlayWallHit();
                PlaySquash();
            }
        }

        private void PlaySquash()
        {
            if (squashRoutine != null)
                StopCoroutine(squashRoutine);

            squashRoutine = StartCoroutine(Squash());
        }

        private IEnumerator Squash()
        {
            transform.localScale = new Vector3(baseScale.x * 1.2f, baseScale.y * 0.8f, 1f);
            yield return new WaitForSeconds(0.05f);
            transform.localScale = baseScale;
        }
    }
}