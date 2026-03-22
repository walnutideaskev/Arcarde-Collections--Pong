using UnityEngine;

namespace WalnutIdeas
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        public AudioSource audioSource;

        [Header("Clips")]
        public AudioClip paddleHit;
        public AudioClip wallHit;
        public AudioClip score;

        private void Awake()
        {
            Instance = this;
        }

        public void Play(AudioClip clip)
        {
            if (clip == null || audioSource == null)
                return;

            audioSource.PlayOneShot(clip);
        }

        public void PlayPaddleHit() => Play(paddleHit);
        public void PlayWallHit() => Play(wallHit);
        public void PlayScore() => Play(score);
    }
}
