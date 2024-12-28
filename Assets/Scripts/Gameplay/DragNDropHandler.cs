using UnityEngine;

namespace TheGame
{
    public class DragNDropHandler : MonoBehaviour
    {

        private GameInputController m_gameInputController;

        public void Initialize(GameInputController gameInputController)
        {
            m_gameInputController = gameInputController;
        }
        
        void Update()
        {
            // Get mouse position in world space
            Vector2 mousePosition = m_gameInputController.mouseWorldPosition;

            // Check if there's a collider at the mouse position
            Collider2D colliderUnderMouse = Physics2D.OverlapPoint(mousePosition);

            if (colliderUnderMouse != null)
            {
                Debug.Log("Mouse is over: " + colliderUnderMouse.gameObject.name);
            }
        }
        
        
        
    }
}
