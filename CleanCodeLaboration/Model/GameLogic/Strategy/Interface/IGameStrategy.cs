using CleanCodeLaboration.Model.GameDAO.Interface;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.Interface
{
    public interface IGameStrategy
    {
        void SetGameDAO(IGameDAO gameDAO);
        string GetEvaluatedGuess(string guess); //Fungerar Evaluate som namn?? Det kanske också är en metod som ska gömmas bakom en Get-metod? eller Kanske ha en privat EvaluateGuess-metod och sen döper du omd enna metod till GetEvaluatedGuess?
        string GenerateRandomGoal(); //Denna säger inget om att den också ska "ge tillbaka" ett RandomGoal. Kan du kanske gömma just den funktionen i Moogame osv. private void GenerateRandomGoal och denna heter GetRandomGoal()?
        string GetFinishedGameMessage();
        string GetGameIntroduction();
        bool IsGameActive();
        void SetGoal(string goal);
        string GetHighScore();
        void SetPlayerName(string userName);
        void StartNewGame(); //Fortfarande kanske otydligt vad den gör? För abstrakt? StartNewGame?
        void SaveGame();
        void IncrementGuess(); //Denna kanske behöver bytas namn på, kanske borde heta något i stil med incrementNumberOfGuesses?
        bool IsCorrectGuess(string guess);
        void DeactivateGame();
        string GetRightAnswer();
    }
}