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
        public static Action OnPressHowToPlayNext;
        public static Action OnPressCredits;
        
        // --- ---
        
        // Gameplay
        public static Action OnPressResume;
        public static Action OnPressRestartGame;
        public static Action OnPressToMainMenu;
        public static Action<int> OnTimerChanged;
        public static Action<float> OnScoreChanged;
        public static Action OnPressPause;
    }
}