using UnityEngine;

namespace TheGame
{
    public class Present : MonoBehaviour
    {
        public float disableX = -10f;
        public float speed = 1f;

        private bool _isDragged = false;
        private Vector2 _conveyorPosition;

        void Start()
        {
            _conveyorPosition = gameObject.transform.position;
        }
        
        void Update()
        {
            _conveyorPosition += Vector2.left * (speed * Time.deltaTime);

            if (!_isDragged)
            {
                gameObject.transform.position = _conveyorPosition;
            }
            
            if (gameObject.transform.position.x < disableX)
            {
                gameObject.SetActive(false);
            }
        }

        public void setIsDragged(bool isDragged)
        {
            _isDragged = isDragged;
        }

        public void setPosition(Vector2 position)
        {
            if (_isDragged)
            {
                gameObject.transform.position = position;
            }
        }
    }
}
