﻿using CleanCodeLaboration.Controller.GameLoop.Interface;
using CleanCodeLaboration.Controller.GameMenu.Interface;
using CleanCodeLaboration.Model.GameLogic.Strategy.Interface;

namespace CleanCodeLaboration.Controller
{
    public class GameController
    {
        private readonly IGameLoop gameLoop;
        private IGameMenu gameMenu;

        public GameController(IGameLoop gameLoop, IGameMenu gameMenu)
        {
            this.gameLoop = gameLoop;
            this.gameMenu = gameMenu;
        }

        public void StartGame()
        {
            PromptUserForName();
            do
            {
                OutputMenu();
                ChooseGame();
            } while (KeepPlaying());
        }
        private void PromptUserForName()
        {
            gameLoop.PromptUserForName();
        }
        private void OutputMenu()
        {
            gameMenu.OutputMenu();
        }
        private void ChooseGame()
        {
            gameMenu.MakeMenuSelection();
        }
        private bool KeepPlaying()
        {
            return gameMenu.ContinuePlaying();
        }
    }
}
