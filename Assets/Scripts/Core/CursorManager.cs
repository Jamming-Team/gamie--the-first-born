using UnityEngine;

namespace TheGame
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] private Texture2D cursor;
        [SerializeField] private Texture2D cursorGrab;
        
        private Vector2 _cursorHotspot;
        
        void Start()
        {
            _cursorHotspot = new Vector2(cursor.width / 4f, cursor.height / 2f);
            Cursor.SetCursor(cursor, _cursorHotspot, CursorMode.ForceSoftware);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Cursor.SetCursor(cursorGrab, _cursorHotspot, CursorMode.ForceSoftware);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Cursor.SetCursor(cursor, _cursorHotspot, CursorMode.ForceSoftware);
            }
        }
    }
}
