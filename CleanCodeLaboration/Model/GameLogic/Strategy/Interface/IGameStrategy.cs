using CleanCodeLaboration.Model.GameDAO.Interface;

namespace CleanCodeLaboration.Model.GameLogic.Strategy.Interface
{
    public interface IGameStrategy
    {
        void SetGameDAO(IGameDAO gameDAO);
        string GetEvaluatedGuess(string guess);
        string GenerateGoal(); //Denna säger inget om att den också ska "ge tillbaka" ett RandomGoal. Kan du kanske gömma just den funktionen i Moogame osv. private void GenerateRandomGoal och denna heter GetRandomGoal()?
        string GetFinishedGameMessage();
        string GetGameIntroduction();
        bool IsGameActive();
        void SetGoal(string goal);
        List<IPlayerScore> GetPlayerScores();
        void ActivateGame(); //Fortfarande kanske otydligt vad den gör? För abstrakt? StartNewGame?
        void SaveGame(string playerName); //Skulle jag kunna stoppa in name här istället då?
        void IncrementGuessCount(); //Denna kanske behöver bytas namn på, kanske borde heta något i stil med incrementNumberOfGuesses?
        bool IsCorrectGuess(string guess);
        void DeactivateGame();
        string GetRightAnswer();
    }
}