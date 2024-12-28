using UnityEngine;

namespace TheGame
{
    public class GMC_MainMenu : GameModeControllerBase
    {
        [SerializeField]
        protected DragNDropHandler m_dragNDropHandler;
        
        
        public override void Initialize(GameInputController inputManager)
        {
            base.Initialize(inputManager);
            m_dragNDropHandler.Initialize(inputManager);
        }
    }
}