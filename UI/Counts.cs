using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class Counts : MonoBehaviour
{
    PlayerCollisin playerCollisin;

    public TMP_Text textAppleCount, textBananaCount, textBerriesCount, textBerryCount, textBreadCount,
        textCheeseCount, textCleverCount, textCoinCount, textCrystalCount, textEggsCount, textEyeCount,
        textFishCount, textFungusCount, textHealthPotionCount, textMagicFishCount,
        textMeatCount, textPieCount, textSardinsCount;

    private int appleCount = 0, bananaCount = 0, berriesCount = 0, berryCount = 0, breadCount = 0,
        cheeseCount = 0, cleverCount = 0, coinCount = 0, crystalCount = 0, eggsCount = 0,
        eyeCount = 0, fishCount = 0, fungusCount = 0, healthPotionCount = 0,
        magicFishCount = 0, meatCount = 0, pieCount = 0, sardinsCount = 0;
    /*
    private int tempappleCount, tempbananaCount, tempberriesCount, tempberryCount, tempbreadCount,
        tempcheeseCount, tempcleverCount, tempcoinCount, tempcrystallCount, tempeggsCount, 
        tempeyeCount, tempfishCount, tempfungusCount, temphealthPotionCount, 
        tempmagicFishCount, tempmeatCount, temppieCount, tempsardinsCount;
    */
    private int currentCoins;
    private int currentCrystals;
    private void Start()
    {
        playerCollisin = FindObjectOfType<PlayerCollisin>().GetComponent<PlayerCollisin>();
        //playerCheckerCounts = FindObjectOfType<PlayerCheckerCounts>().GetComponent<PlayerCheckerCounts>();

        currentCoins = PlayerPrefs.GetInt("Coins", 0);
        currentCrystals = PlayerPrefs.GetInt("Crystals", 0);

        LoadSaveFromCloud();

    }
    private void OnEnable()
    {
        if (textAppleCount != null)
            AppleEventScript.OnAppleDeath += IncrementAppleCountCount;
        if (textBananaCount != null)
            BananaEventScript.OnBananaDeath += IncrementBananaCountCount;
        if (textBerriesCount != null)
            BerriesEventScript.OnBerriesDeath += IncrementBerriesCountCount;
        if (textBerryCount != null)
            BerryEventScript.OnBerryDeath += IncrementBerryCountCount;
        if (textBreadCount != null)
            BreadEventScript.OnBreadDeath += IncrementBreadCountCount;
        if (textCheeseCount != null)
            CheeseEventScript.OnCheeseDeath += IncrementCheeseCountCount;
        if (textCleverCount != null)
            CleverEventScript.OnCleverDeath += IncrementCleverCountCount;
        if (textCoinCount != null)
            CoinEventScript.OnCoinDeath += IncrementCoinCountCount;
        if (textCrystalCount != null)
            CrystallEventScript.OnCrystallDeath += IncrementCrystallCountCount;
        if (textEggsCount != null)
            EggsEventScript.OnEggsDeath += IncrementEggsCountCount;
        if (textEyeCount != null)
            EyeEventScript.OnEyeDeath += IncrementEyeCountCount;
        if (textFishCount != null)
            FishEventScript.OnFishDeath += IncrementFishCountCount;
        if (textFungusCount != null)
            FungusEventScript.OnFungusDeath += IncrementFungusCountCount;
        if (textHealthPotionCount != null)
            HealthPotionEventScript.OnHealthPotionDeath += IncrementHealthPotionCountCount;
        if (textMagicFishCount != null)
            MagicEventScript.OnMagicDeath += IncrementMagicFishCountCount;
        if (textMeatCount != null)
            MeatEventScript.OnMeatDeath += IncrementMeatCountCount;
        if (textPieCount != null)
            PieEventScript.OnPieDeath += IncrementPieCountCount;
        if (textSardinsCount != null)
            SardinsEventScript.OnSardinsDeath += IncrementSardinsCountCount;

        YandexGame.GetDataEvent += LoadSaveFromCloud;
    }

    private void OnDisable()
    {
        AppleEventScript.OnAppleDeath -= IncrementAppleCountCount;
        BananaEventScript.OnBananaDeath -= IncrementBananaCountCount;
        BerriesEventScript.OnBerriesDeath -= IncrementBerriesCountCount;
        BerryEventScript.OnBerryDeath -= IncrementBerryCountCount;
        BreadEventScript.OnBreadDeath -= IncrementBreadCountCount;
        CheeseEventScript.OnCheeseDeath -= IncrementCheeseCountCount;
        CleverEventScript.OnCleverDeath -= IncrementCleverCountCount;
        CoinEventScript.OnCoinDeath -= IncrementCoinCountCount;
        CrystallEventScript.OnCrystallDeath -= IncrementCrystallCountCount;
        EggsEventScript.OnEggsDeath -= IncrementEggsCountCount;
        EyeEventScript.OnEyeDeath -= IncrementEyeCountCount;
        FishEventScript.OnFishDeath -= IncrementFishCountCount;
        FungusEventScript.OnFungusDeath -= IncrementFungusCountCount;
        HealthPotionEventScript.OnHealthPotionDeath -= IncrementHealthPotionCountCount;
        MagicEventScript.OnMagicDeath -= IncrementMagicFishCountCount;
        MeatEventScript.OnMeatDeath -= IncrementMeatCountCount;
        PieEventScript.OnPieDeath -= IncrementPieCountCount;
        SardinsEventScript.OnSardinsDeath -= IncrementSardinsCountCount;

        YandexGame.GetDataEvent -= LoadSaveFromCloud;
    }

    private void IncrementAppleCountCount()
    {
        appleCount += 1;
        if (playerCollisin != null)
        {
            textAppleCount.text = $"{appleCount}/{playerCollisin.score}";
        }
        else { textAppleCount.text = $"{appleCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementBananaCountCount()
    {
        bananaCount += 1;
        if (playerCollisin != null)
        {
            textBananaCount.text = $"{bananaCount}/{playerCollisin.score}";
        }
        else { textBananaCount.text = $"{bananaCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementBerriesCountCount()
    {
        berriesCount += 1;
        if (playerCollisin != null)
        {
            textBerriesCount.text = $"{berriesCount}/{playerCollisin.score}";
        }
        else { textBerriesCount.text = $"{berriesCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementBerryCountCount()
    {
        berryCount += 1;
        if (playerCollisin != null)
        {
            textBerryCount.text = $"{berryCount}/{playerCollisin.score}";
        }
        else { textBerryCount.text = $"{berryCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementBreadCountCount()
    {
        breadCount += 1;
        if (playerCollisin != null)
        {
            textBreadCount.text = $"{breadCount}/{playerCollisin.score}";
        }
        else { textBreadCount.text = $"{breadCount}/{PlayerCheckerCounts.score}"; }

    }
    private void IncrementCheeseCountCount()
    {
        cheeseCount += 1;
        if (playerCollisin != null)
        {
            textCheeseCount.text = $"{cheeseCount}/{playerCollisin.score}";
        }
        else { textCheeseCount.text = $"{cheeseCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementCleverCountCount()
    {
        cleverCount += 1;
        if (playerCollisin != null)
        {
            textCleverCount.text = $"{cleverCount}/{playerCollisin.score}";
        }
        else { textCleverCount.text = $"{cleverCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementCoinCountCount()
    {
        coinCount += 1;
        currentCoins += 1;
        PlayerPrefs.SetInt("Coins", currentCoins);
        MySaves();

        textCoinCount.text = coinCount.ToString();
    }
    private void IncrementCrystallCountCount()
    {
        crystalCount += 1;
        currentCrystals += 1;
        PlayerPrefs.SetInt("Crystals", currentCrystals);
        MySaves();

        textCrystalCount.text = crystalCount.ToString();
    }
    private void IncrementEggsCountCount()
    {
        eggsCount += 1;
        if (playerCollisin != null)
        {
            textEggsCount.text = $"{eggsCount}/{playerCollisin.score}";
        }
        else { textEggsCount.text = $"{eggsCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementEyeCountCount()
    {
        eyeCount += 1;
        if (playerCollisin != null)
        {
            textEyeCount.text = $"{eyeCount}/{playerCollisin.score}";
        }
        else { textEyeCount.text = $"{eyeCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementFishCountCount()
    {
        fishCount += 1;
        if (playerCollisin != null)
        {
            textFishCount.text = $"{fishCount}/{playerCollisin.score}";
        }
        else { textFishCount.text = $"{fishCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementFungusCountCount()
    {
        fungusCount += 1;
        if (playerCollisin != null)
        {
            textFungusCount.text = $"{fungusCount}/{playerCollisin.score}";
        }
        else { textFungusCount.text = $"{fungusCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementHealthPotionCountCount()
    {
        healthPotionCount += 1;
        if (playerCollisin != null)
        {
            textHealthPotionCount.text = $"{healthPotionCount}/{playerCollisin.score}";
        }
        else { textHealthPotionCount.text = $"{healthPotionCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementMagicFishCountCount()
    {
        magicFishCount += 1;
        if (playerCollisin != null)
        {
            textMagicFishCount.text = $"{magicFishCount}/{playerCollisin.score}";
        }
        else { textMagicFishCount.text = $"{magicFishCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementMeatCountCount()
    {
        meatCount += 1;
        if (playerCollisin != null)
        {
            textMeatCount.text = $"{meatCount}/{playerCollisin.score}";
        }
        else { textMeatCount.text = $"{meatCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementPieCountCount()
    {
        pieCount += 1;
        if (playerCollisin != null)
        {
            textPieCount.text = $"{pieCount}/{playerCollisin.score}";
        }
        else { textPieCount.text = $"{pieCount}/{PlayerCheckerCounts.score}"; }
    }
    private void IncrementSardinsCountCount()
    {
        sardinsCount += 1;
        if (playerCollisin != null)
        {
            textSardinsCount.text = $"{sardinsCount}/{playerCollisin.score}";
        }
        else { textSardinsCount.text = $"{sardinsCount}/{PlayerCheckerCounts.score}"; }
    }

    public void LoadSaveFromCloud()
    {
        currentCoins = YandexGame.savesData.coins;
        currentCrystals = YandexGame.savesData.crystals;
        Debug.Log("Всего монет загружено" + coinCount);
        Debug.Log("Всего монет загружено" + crystalCount);
    }
    public void MySaves()
    {
        YandexGame.savesData.coins = currentCoins;
        Debug.Log("Всего монет сохранено" + currentCoins);
        YandexGame.savesData.crystals = currentCrystals;
        Debug.Log("Всего монет сохранено" + currentCrystals);

        YandexGame.SaveProgress();
    }
}
