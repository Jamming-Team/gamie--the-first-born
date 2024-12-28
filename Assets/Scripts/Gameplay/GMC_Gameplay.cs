using UnityEngine;

namespace TheGame
{
    public class GMC_Gameplay : GameModeControllerBase
    {
        [SerializeField]
        protected DragNDropHandler m_dragNDropHandler;
        
        // public override void Initialize(GameInputController inputManager)
        // {
        //     base.Initialize(inputManager);
        //     m_dragNDropHandler.Initialize(inputManager);
        // }
        
        public override void Initialize()
        {
            base.Initialize();
            m_dragNDropHandler.Init();
        }
    }
}
