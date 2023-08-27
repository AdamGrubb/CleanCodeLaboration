﻿using CleanCodeLaboration.Controller;
using CleanCodeLaboration.Model.GameDAO.Interface;
using CleanCodeLaboration.Model.GameDAO;
using CleanCodeLaboration.Model.GameLogic.Interface;
using CleanCodeLaboration.Model.GameLogic;
using CleanCodeLaboration.View.Interface;
using CleanCodeLaboration.View;
using CleanCodeLaboration.Model.GameMenu;
using CleanCodeLaboration.Model.GameMenu.Interface;

IIO iO = new ConsoleView();
IGameDAO gameDAO = new LocalFileDAO();
IGameContext gameContext = new GameContext(gameDAO);
IGameMenu gameMenu = new GameMenu();
GameController controller = new GameController(gameContext, iO);
controller.SetGameMenu(gameMenu);


controller.StartCleanCodeGameLoop();