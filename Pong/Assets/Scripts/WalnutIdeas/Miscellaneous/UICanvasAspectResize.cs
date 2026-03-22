using System;
using UnityEngine;

namespace WalnutIdeas.UI
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform))]
    public class UICanvasAspectResize : MonoBehaviour
    {
        [SerializeField]
        private Camera m_Camera;
        
        private RectTransform m_RectTransform;

        private void Awake()
        {
            this.m_RectTransform = this.transform as RectTransform;
        }

        private void Update()
        {
            if (this.m_Camera == null)
                return;
            
            this.m_RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, this.m_Camera.aspect * this.m_RectTransform.rect.size.y);
        }
    }
}
