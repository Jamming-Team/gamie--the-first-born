using System.Collections;
using UnityEngine;

namespace TheGame
{
    public class PresentGenerator : MonoBehaviour
    {
        public float generateDelay = 3f;
        public Transform generatorPosition;
        public GameObject present;  // TODO: заменить на список подарков, из которого будет доставаться случайный элемент

        void Start()
        {
            generatorPosition.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            StartCoroutine(Generating());
        }
        
        private IEnumerator Generating()
        {
            yield return new WaitForSeconds(generateDelay);
            Instantiate(present, generatorPosition);
            StartCoroutine(Generating());
        }
    }
}
