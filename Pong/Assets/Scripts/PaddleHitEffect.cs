using System.Collections;
using UnityEngine;

namespace WalnutIdeas
{
    public class PaddleHitEffect : MonoBehaviour
    {
        private SpriteRenderer sr;
        private Color baseColor;
        private Coroutine routine;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            if (sr != null)
                baseColor = sr.color;
        }

        public void Play()
        {
            if (sr == null)
                return;

            if (routine != null)
                StopCoroutine(routine);

            routine = StartCoroutine(Flash());
        }

        private IEnumerator Flash()
        {
            sr.color = Color.white;
            yield return new WaitForSeconds(0.05f);
            sr.color = baseColor;
        }
    }
}
