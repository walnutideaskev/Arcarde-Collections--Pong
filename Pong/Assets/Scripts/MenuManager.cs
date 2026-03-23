using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject singleplayerMenu;
        [SerializeField] private GameObject multiplayerMenu;
        
        [Header("Menu Sounds")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip btnClickClip;
        [SerializeField] private AudioClip gameStartClip;

        public void BackButton_Click()
        {
            Debug.Log("BackButton_Click");
            audioSource.PlayOneShot(btnClickClip);
            this.multiplayerMenu.SetActive(false);
            this.singleplayerMenu.SetActive(false);
            this.mainMenu.SetActive(true);
        }

        public void QuitButton_Click()
        {
            audioSource.PlayOneShot(btnClickClip);
            Application.Quit();
        }
        
        public void OptionsButton_Click()
        {
            audioSource.PlayOneShot(btnClickClip);
            Debug.Log("OptionsButton_Click");
        }
        
        public void SinglePlayerButton_Click()
        {
            Debug.Log("SinglePlayerButton_Click");
            audioSource.PlayOneShot(btnClickClip);
            this.mainMenu.SetActive(false);
            this.singleplayerMenu.SetActive(true);
        }

        public void MultiplayerButton_Click()
        {
            Debug.Log("MultiplayerButton_Click");
            audioSource.PlayOneShot(btnClickClip);
            this.mainMenu.SetActive(false);
            this.multiplayerMenu.SetActive(true);
        }

        
        
        public void BestOfTheeButtonSP_Click()
        {
            audioSource.PlayOneShot(btnClickClip);
            Debug.Log("BestOfTheeButton_Click");
        }

        public void BestOfFiveButtonSP_Click()
        {
            audioSource.PlayOneShot(btnClickClip);
            Debug.Log("BestOfFiveButton_Click");
        }
        
        public void PracticeModeButtonSP_Click()
        {
            audioSource.PlayOneShot(btnClickClip);
            Debug.Log("PracticeModeButton_Click");
        }
        
        
        
        public void BestOfTheeButtonMP_Click()
        {
            audioSource.PlayOneShot(btnClickClip);
            Debug.Log("BestOfTheeButtonMP_Click");
        }

        public void BestOfFiveButtonMP_Click()
        {
            audioSource.PlayOneShot(btnClickClip);
            Debug.Log("BestOfFiveButtonMP_Click");
        }
        
        public void PracticeModeButtonMP_Click()
        {
            audioSource.PlayOneShot(btnClickClip);
            Debug.Log("PracticeModeButtonMP_Click");
        }
        

    }
}
