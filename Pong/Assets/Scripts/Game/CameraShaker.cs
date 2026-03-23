using System.Collections;
using UnityEngine;

namespace WalnutIdeas
{
    public class CameraShake : MonoBehaviour
    {
        public static CameraShake Instance;

        private Vector3 basePos;
        private Coroutine routine;

        private void Awake()
        {
            Instance = this;
            basePos = transform.localPosition;
        }

        public void Shake(float duration, float strength)
        {
            if (routine != null)
                StopCoroutine(routine);

            routine = StartCoroutine(DoShake(duration, strength));
        }

        private IEnumerator DoShake(float duration, float strength)
        {
            float t = 0f;

            while (t < duration)
            {
                Vector2 offset = Random.insideUnitCircle * strength;
                transform.localPosition = basePos + new Vector3(offset.x, offset.y, 0f);

                t += Time.deltaTime;
                yield return null;
            }

            transform.localPosition = basePos;
        }
    }
}
