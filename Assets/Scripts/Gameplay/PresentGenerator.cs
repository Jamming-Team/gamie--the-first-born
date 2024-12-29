using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

namespace TheGame
{
    public class PresentGenerator : MonoBehaviour
    {
        [SerializeField] private float m_minGenerationDelay = 2.5f;
        [SerializeField] private float m_maxGenerationDelay = 3.5f;
        [SerializeField] private List<Present> m_presentsList;  // TODO: заменить на список подарков, из которого будет доставаться случайный элемент
        [SerializeField] private float m_generateDelayNotRandom = 2.5f;
        
        
        private Sequence m_generationSequence;

        private float m_generateDelay = 2f;
        private Coroutine m_generatingCoroutine;

        void Start()
        {
            // StartCoroutine(Generating());
        }
        
        private IEnumerator Generating()
        {
            Instantiate(m_presentsList[Random.Range(0, m_presentsList.Count)], gameObject.transform);
            yield return new WaitForSeconds(m_generateDelay);
            StartCoroutine(Generating());
        }

        public void StartGeneration()
        {
            m_generationSequence = Sequence.Create(cycles: 1000, cycleMode: CycleMode.Incremental)
                .ChainCallback(() =>
                    Instantiate(m_presentsList[Random.Range(0, m_presentsList.Count)], gameObject.transform))
                // .ChainCallback(SetNewRandomDelay)
                .ChainDelay(m_generateDelayNotRandom);
            // m_generatingCoroutine = StartCoroutine(Generating());
        }

        public void StopGeneration()
        {
            Debug.Log("Stopping generation");
            m_generationSequence.Complete();
        }

        public void SetNewRandomDelay()
        {
            m_generateDelay = Random.Range(m_minGenerationDelay, m_maxGenerationDelay);
        }
    }
}
