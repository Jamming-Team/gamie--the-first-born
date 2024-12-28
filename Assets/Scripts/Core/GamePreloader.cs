using System;
using UnityEngine;

namespace TheGame
{
    public class GamePreloader : MonoBehaviour
    {
        private void Start()
        {
            GameController.Instance.LoadScene(GameConstants.SceneNames.MAIN_MENU);
        }
    }
}