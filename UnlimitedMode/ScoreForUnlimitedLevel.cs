using UnityEngine;
using YG;
using TMPro;

public class ScoreForUnlimitedLevel : MonoBehaviour
{
    public TMP_Text textForScore;
    private int score;
    private float lastScore;

    private void Start()
    {
        score = 0;
        textForScore.text = score.ToString();

        lastScore = YandexGame.savesData.totalScore;
    }
    private void OnEnable()
    {
            AppleEventScript.OnAppleDeath += IncrementScore;
            BananaEventScript.OnBananaDeath += IncrementScore;
            BerriesEventScript.OnBerriesDeath += IncrementScore;
            BerryEventScript.OnBerryDeath += IncrementScore;
            BreadEventScript.OnBreadDeath += IncrementScore;
            CheeseEventScript.OnCheeseDeath += IncrementScore;
            CleverEventScript.OnCleverDeath += IncrementScore;
            CoinEventScript.OnCoinDeath += IncrementScore;
            CrystallEventScript.OnCrystallDeath += IncrementScore;
            EggsEventScript.OnEggsDeath += IncrementScore;
            EyeEventScript.OnEyeDeath += IncrementScore;
            FishEventScript.OnFishDeath += IncrementScore;
            FungusEventScript.OnFungusDeath += IncrementScore;
            HealthPotionEventScript.OnHealthPotionDeath += IncrementScore;
            MagicEventScript.OnMagicDeath += IncrementScore;
            MeatEventScript.OnMeatDeath += IncrementScore;
            PieEventScript.OnPieDeath += IncrementScore;
            SardinsEventScript.OnSardinsDeath += IncrementScore;
    }
    private void OnDisable()
    {
        AppleEventScript.OnAppleDeath -= IncrementScore;
        BananaEventScript.OnBananaDeath -= IncrementScore;
        BerriesEventScript.OnBerriesDeath -= IncrementScore;
        BerryEventScript.OnBerryDeath -= IncrementScore;
        BreadEventScript.OnBreadDeath -= IncrementScore;
        CheeseEventScript.OnCheeseDeath -= IncrementScore;
        CleverEventScript.OnCleverDeath -= IncrementScore;
        CoinEventScript.OnCoinDeath -= IncrementScore;
        CrystallEventScript.OnCrystallDeath -= IncrementScore;
        EggsEventScript.OnEggsDeath -= IncrementScore;
        EyeEventScript.OnEyeDeath -= IncrementScore;
        FishEventScript.OnFishDeath -= IncrementScore;
        FungusEventScript.OnFungusDeath -= IncrementScore;
        HealthPotionEventScript.OnHealthPotionDeath -= IncrementScore;
        MagicEventScript.OnMagicDeath -= IncrementScore;
        MeatEventScript.OnMeatDeath -= IncrementScore;
        PieEventScript.OnPieDeath -= IncrementScore;
        SardinsEventScript.OnSardinsDeath -= IncrementScore;
    }
    private void IncrementScore()
    {
        score += 5;
        textForScore.text = score.ToString();

        if (score >= lastScore) 
        {
            AddScoreLeaderboard();
            SaveScore();
        }
        
    }
    private void SaveScore()
    {
        YandexGame.savesData.totalScore = score;
        YandexGame.SaveProgress();
    }

    private void AddScoreLeaderboard()
    {
        YandexGame.NewLeaderboardScores("TotalScore", score);
    }
}
