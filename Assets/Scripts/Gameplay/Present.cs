using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace TheGame
{
    public class Present : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _boxLayerMask;
        [SerializeField]
        private LayerMask _presentLayerMask;

        [SerializeField] private float m_presentValue = 5f;
        public float presentValue => m_presentValue;
        
        public float disableX = -10f;
        public float speed = 1f;

        private PresentState _currState = PresentState.OnConveyor;
        private Vector2 _conveyorPosition;

        void Start()
        {
            _conveyorPosition = gameObject.transform.position;
        }

        void Update()
        {
            _conveyorPosition += Vector2.left * (speed * Time.deltaTime);

            if (_currState == PresentState.OnConveyor)
            {
                gameObject.transform.position = _conveyorPosition;
            }

            if (gameObject.transform.position.x < disableX)
            {
                gameObject.SetActive(false);
            }
        }

        /**
         * Если произошел захват мышкой и подарок на ленте - текущий стейт становится = Dragged.
         * Если произошел drop, то проверяем, полностью ли подарок входит в коллайдер коробки и в соответствии с
         * результатом проверки присваиваем стейт InBox или OnConveyor.
         */
        public void SetIsDragged(bool isDragged)
        {
            if (isDragged)
            {
                if (_currState == PresentState.OnConveyor)
                {
                    _currState = PresentState.Dragged;
                }
            }
            else
            {
                List<Collider2D> overlapBoxList = GetOverlapColliders(_boxLayerMask);
                if (overlapBoxList.Count > 0 && IsFullyInsideBox(overlapBoxList[0].gameObject))
                {
                    _currState = PresentState.InBox;
                    overlapBoxList[0].gameObject.GetComponent<BoxController>()
                        .AddPresent(this, GetOverlapColliders(_presentLayerMask).Count > 0);
                }
                else
                {
                    _currState = PresentState.OnConveyor;
                }
            }
        }

        /**
         * Метод для установки позиции подарка при помощи мышки
         */
        public void SetPosition(Vector2 position)
        {
            if (_currState == PresentState.Dragged)
            {
                gameObject.transform.position = position;
            }
        }

        private bool IsFullyInsideBox(GameObject box)
        {
            PolygonCollider2D innerCollider = gameObject.GetComponent<PolygonCollider2D>();
            PolygonCollider2D outerCollider = box.GetComponent<PolygonCollider2D>();

            foreach (Vector2 point in innerCollider.points)
            {
                Vector2 worldPoint = gameObject.transform.TransformPoint(point);
                if (!outerCollider.OverlapPoint(worldPoint))
                {
                    return false;
                }
            }
            return true;
        }

        private List<Collider2D> GetOverlapColliders(LayerMask layerMask)
        {
            List<Collider2D> overlapList = new List<Collider2D>();
            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(layerMask);
            Physics2D.OverlapCollider(gameObject.GetComponent<Collider2D>(), contactFilter, overlapList);
            return overlapList;
        }

        public enum PresentState
        {
            OnConveyor,
            Dragged,
            InBox
        }
    }
}
