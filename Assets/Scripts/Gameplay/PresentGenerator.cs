using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

namespace TheGame
{
    public class PresentGenerator : MonoBehaviour
    {
        [SerializeField] private float m_minGenerationDelay = 2f;
        [SerializeField] private float m_maxGenerationDelay = 5f;
        [SerializeField] private List<Present> m_presentsList;  // TODO: заменить на список подарков, из которого будет доставаться случайный элемент
        
        private Sequence m_generationSequence;
        
        private float generateDelay
        {
            get
            {
                return Random.Range(m_minGenerationDelay, m_maxGenerationDelay);
            }
        }
        private Coroutine m_generatingCoroutine;

        void Start()
        {
            // StartCoroutine(Generating());
        }
        
        private IEnumerator Generating()
        {
            Instantiate(m_presentsList[Random.Range(0, m_presentsList.Count)], gameObject.transform);
            yield return new WaitForSeconds(generateDelay);
            StartCoroutine(Generating());
        }

        public void StartGeneration()
        {
            m_generationSequence = Sequence.Create(cycles: 1000)
                .ChainCallback(() =>
                    Instantiate(m_presentsList[Random.Range(0, m_presentsList.Count)], gameObject.transform))
                .ChainDelay(generateDelay);
            // m_generatingCoroutine = StartCoroutine(Generating());
        }

        public void StopGeneration()
        {
            Debug.Log("Stopping generation");
            m_generationSequence.Complete();
        }
    }
}
