using System.Collections;
using UnityEngine;

namespace TheGame
{
    public class Present : MonoBehaviour
    {
        public float disableX = -10f;
        public float speed = 1f;

        void Update()
        {
            gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (gameObject.transform.position.x < disableX)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
