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
                public const string PAUSE = "PAUSE";
            }
        }

        public class Views
        {
            public const string PLAY_BUTTON = "PlayButton";
            public const string HOW_TO_PLAY_BUTTON = "HowToPlayButton";
            public const string QUIT_BUTTON = "QuitButton";
            public const string BACK_BUTTON = "BackButton";
            public const string CREDITS_BUTTON = "CreditsButton";
            public const string HOW_TO_PLAY_NEXT_BUTTON = "HowToPlayNextButton";

            public const string RESUME_BUTTON = "ResumeButton";
            public const string RESTART_BUTTON = "RestartButton";
            public const string TO_MAIN_MENU_BUTTON = "ToMainMenuButton";
            public const string COUNTDOWN_LABEL = "CountdownLabel";
            public const string SCORE_LABEL = "ScoreLabel";
            public const string FINAL_SCORE_LABEL = "FinalScoreLabel";
            public const string PAUSE_BUTTON = "PauseButton";
        }
    }
}