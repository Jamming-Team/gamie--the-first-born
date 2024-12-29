using System.Collections;
using UnityEngine;

namespace TheGame
{
    public class PresentGenerator : MonoBehaviour
    {
        public float generateDelay = 3f;
        public GameObject present;  // TODO: заменить на список подарков, из которого будет доставаться случайный элемент

        void Start()
        {
            StartCoroutine(Generating());
        }
        
        private IEnumerator Generating()
        {
            Instantiate(present, gameObject.transform);
            yield return new WaitForSeconds(generateDelay);
            StartCoroutine(Generating());
        }
    }
}
