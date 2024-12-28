using System;
using UnityEngine;

namespace TheGame
{
    public static class GameEventsView
    {
        // Main Menu
        public static Action OnPressPlay;
        public static Action OnPressHowToPlay;
        public static Action OnPressBack;
        public static Action OnPressQuitGame;
        
        // --- ---
        
        // Gameplay
        public static Action OnPressResume;
        public static Action OnPressRestartGame;
        public static Action OnPressToMainMenu;
        public static Action<int> OnTimerChanged;
    }
}