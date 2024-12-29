using System;
using UnityEngine;

namespace TheGame
{
    public class DragNDropHandler : MonoBehaviour
    {

        [SerializeField]
        private LayerMask _layerMask;
        [SerializeField]
        private float m_rotationSpeed = 20f;
        
        // private float lastWheelValue = 0;
        // private GameInputController m_gameInputController;

        // public void Initialize(GameInputController gameInputController)
        // {
        //     m_gameInputController = gameInputController;
        // }
        //
        
        private Present draggedObject = null;

        public void Init()
        {
            // Debug.Log($"Init");
            GameController.Instance.InputController.OnSendBox += InputControllerOnOnSendBox;
            GameController.Instance.InputController.OnRMC += InputControllerOnOnRMC;
            GameController.Instance.InputController.OnLMC += InputControllerOnOnLMC;
            GameController.Instance.InputController.OnWheelRotated += InputControllerOnOnWheelRotated;


        }

        public void OnDestroy()
        {
            GameController.Instance.InputController.OnSendBox -= InputControllerOnOnSendBox;
            GameController.Instance.InputController.OnRMC -= InputControllerOnOnRMC;
            GameController.Instance.InputController.OnLMC -= InputControllerOnOnLMC;
            GameController.Instance.InputController.OnWheelRotated -= InputControllerOnOnWheelRotated;
        }

        void Update()
        {
            // Get mouse position in world space
            Vector2 mousePosition = GameController.Instance.InputController.mouseWorldPosition;

            // Check if there's a collider at the mouse position
            Collider2D colliderUnderMouse = Physics2D.OverlapPoint(mousePosition);

            // if (colliderUnderMouse != null)
            // {
            //     Debug.Log("Mouse is over: " + colliderUnderMouse.gameObject.name);
            // }

            draggedObject?.SetPosition(mousePosition);

            // Для колесика
            // if (GameController.Instance.InputController.mouseWheelScroll != lastWheelValue)
            // {
            //     Debug.Log(GameController.Instance.InputController.mouseWheelScroll);
            //     lastWheelValue = GameController.Instance.InputController.mouseWheelScroll;
            // }
        }

        private void InputControllerOnOnSendBox(object sender, EventArgs e)
        {
            // Debug.Log($"Send Box: {e}");
        }

        private void InputControllerOnOnRMC(object sender, bool pressed)
        {
            if (pressed)
            {
                Vector2 mousePosition = GameController.Instance.InputController.mouseWorldPosition;
                Collider2D colliderUnderMouse = Physics2D.OverlapPoint(mousePosition, _layerMask);
                if (colliderUnderMouse != null)
                {
                    draggedObject = colliderUnderMouse.gameObject.GetComponent<Present>();
                    draggedObject.SetIsDragged(true);
                }
                
                
            }
            else if (draggedObject != null)
            {
                draggedObject.SetIsDragged(false);
                draggedObject = null;
            }
        }

        private void InputControllerOnOnWheelRotated(object sender, float e)
        {
            if (draggedObject != null)
                draggedObject.transform.Rotate(new Vector3(0f, 0f, e * m_rotationSpeed), Space.World);
        }

        private void InputControllerOnOnLMC(object sender, bool pressed)
        {
            // Debug.Log($"LMC: {pressed}");
        }
    }
}
