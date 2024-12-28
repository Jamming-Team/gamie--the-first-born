using UnityEngine;

namespace TheGame
{
    public static class GameConstants
    {
        public class SceneNames
        {
            public const string EMPTY = "Empty";
            public const string MAIN_MENU = "MainMenu";
            public const string GAMEPLAY = "Gameplay";
            public const string GAMEPLAY_TEST = "GameplayTest";
        }

        public class Input
        {
            public class Main
            {
                public const string RMC = "RMC";
                public const string LMC = "LMC";
                public const string SEND_BOX = "SEND_BOX";
            }
        }

        public class Views
        {
            public const string PLAY_BUTTON = "PlayButton";
            public const string HOW_TO_PLAY_BUTTON = "HowToPlayButton";
            public const string QUIT_BUTTON = "QuitButton";
            public const string BACK_BUTTON = "BackButton";
        }
    }
}