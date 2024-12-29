using System;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using VectorVisualizer;

namespace TheGame
{
    public class BoxController : MonoBehaviour
    {
        public Action<bool> OnBoxChangeAvaliability;
        
        [SerializeField] private Vector2 m_initialPosition;
        // [VisualizableVector]
        [SerializeField] private Vector2 m_standPosition;
        [SerializeField] private Vector2 m_outPosition;
        
        [SerializeField] private GameObject m_contentsRoot;

        private List<GameObject> m_presentsList = new(); 

        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            m_initialPosition = transform.position;

            OnBoxChangeAvaliability += b => Debug.Log(b);

            Sequence.Create(1)
                .ChainCallback(() => OnBoxChangeAvaliability?.Invoke(false))
                .Chain(Tween.Position(transform, endValue: m_standPosition, duration: 1f, ease: Ease.InOutSine));
            // .ChainDelay(2f)
            // .Chain(Tween.Position(transform, endValue: m_outPosition, duration: 1f, ease: Ease.InOutSine))
            // .ChainCallback(() => OnBoxChangeAvaliability?.Invoke(true));


            // Tween.Position(transform, endValue: m_standPosition, duration: 0.5f, ease: Ease.InBounce);
        }

        public void AddPresent(GameObject present)
        {
            present.transform.SetParent(m_contentsRoot.transform);
            m_presentsList.Add(present);
        }

        public void ClearContents()
        {
            m_presentsList.ForEach(Destroy);
        }
        
    }
}
