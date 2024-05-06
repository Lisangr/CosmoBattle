using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class Counts : MonoBehaviour
{
    PlayerCollisin playerCollisin;
    public TMP_Text textAppleCount,textBananaCount, textBerriesCount, textBerryCount, textBreadCount,
        textCheeseCount, textCleverCount, textCoinCount, textCrystalCount, textEggsCount, textEyeCount,
        textFishCount, textFungusCount, textGreenCleverCount, textHealthPotionCount, textMagicFishCount,
        textMeatCount, textPieCount, textSardinsCount;

    private int appleCount = 0, bananaCount = 0, berriesCount = 0, berryCount = 0, breadCount = 0, 
        cheeseCount = 0, cleverCount = 0, coinCount = 0, crystalCount = 0, eggsCount = 0, 
        eyeCount = 0, fishCount = 0, fungusCount = 0, greenCleverCount = 0, healthPotionCount = 0,
        magicFishCount = 0, meatCount = 0, pieCount = 0, sardinsCount = 0;
    /*
    private int tempappleCount, tempbananaCount, tempberriesCount, tempberryCount, tempbreadCount,
        tempcheeseCount, tempcleverCount, tempcoinCount, tempcrystallCount, tempeggsCount, 
        tempeyeCount, tempfishCount, tempfungusCount, tempgreenCleverCount, temphealthPotionCount, 
        tempmagicFishCount, tempmeatCount, temppieCount, tempsardinsCount;
    */
    private int currentCoins;
    private int currentCrystals;
    private void Start()
    {
        playerCollisin = FindObjectOfType<PlayerCollisin>().GetComponent<PlayerCollisin>();

        currentCoins = PlayerPrefs.GetInt("Coins", 0);
        currentCrystals = PlayerPrefs.GetInt("Crystals", 0);

        if (YandexGame.SDKEnabled == true)
        {
            LoadSaveFromCloud();
        }
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
        if (textGreenCleverCount != null)
            GreenCleverEventScript.OnGreenCleverDeath += IncrementGreenCleverCountCount;
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
        GreenCleverEventScript.OnGreenCleverDeath -= IncrementGreenCleverCountCount;
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
        textAppleCount.text = $"{appleCount}/{playerCollisin.score}";
        //textAppleCount.text = $"{appleCount}/{tempappleCount}";
    }
    private void IncrementBananaCountCount()
    {
        bananaCount += 1;
        textBananaCount.text = $"{bananaCount}/{playerCollisin.score}";
    }
    private void IncrementBerriesCountCount()
    {
        berriesCount += 1;
        textBerriesCount.text = $"{berriesCount}/{playerCollisin.score}";
    }
    private void IncrementBerryCountCount()
    {
        berryCount += 1;
        textBerryCount.text = $"{berryCount}/{playerCollisin.score}";
    }
    private void IncrementBreadCountCount()
    {
        breadCount += 1;
        textBreadCount.text = $"{breadCount}/{playerCollisin.score}";
    }
    private void IncrementCheeseCountCount()
    {
        cheeseCount += 1;
        textCheeseCount.text = $"{cheeseCount}/{playerCollisin.score}";
        Debug.Log("произошло событие подбора сыра счетчик увеличен на 1");
    }
    private void IncrementCleverCountCount()
    {
        cleverCount += 1;
        textCleverCount.text = $"{cleverCount}/{playerCollisin.score}";
    }
    private void IncrementCoinCountCount()
    {
        coinCount += 1;
        currentCoins += coinCount;
        PlayerPrefs.SetInt("Coins", currentCoins);
        MySaves();

        textCoinCount.text = coinCount.ToString();
    }
    private void IncrementCrystallCountCount()
    {
        crystalCount += 1;
        currentCrystals += crystalCount;
        PlayerPrefs.SetInt("Crystals", currentCrystals);
        MySaves();

        textCrystalCount.text = crystalCount.ToString();
    }
    private void IncrementEggsCountCount()
    {
        eggsCount += 1;
        textEggsCount.text = $"{eggsCount}/{playerCollisin.score}";
    }
    private void IncrementEyeCountCount()
    {
        eyeCount += 1;
        textEyeCount.text = $"{eyeCount}/{playerCollisin.score}";
    }
    private void IncrementFishCountCount()
    {
        fishCount += 1;
        textFishCount.text = $"{fishCount}/{playerCollisin.score}";
    }
    private void IncrementFungusCountCount()
    {
        fungusCount += 1;
        textFungusCount.text = $"{fungusCount}/{playerCollisin.score}";
    }
    private void IncrementGreenCleverCountCount()
    {
        greenCleverCount += 1;
        textGreenCleverCount.text = $"{greenCleverCount}/{playerCollisin.score}";
    }
    private void IncrementHealthPotionCountCount()
    {
        healthPotionCount += 1;
        textHealthPotionCount.text = $"{healthPotionCount}/{playerCollisin.score}";
    }
    private void IncrementMagicFishCountCount()
    {
        magicFishCount += 1;
        textMagicFishCount.text = $"{magicFishCount}/{playerCollisin.score}";
    }
    private void IncrementMeatCountCount()
    {
        meatCount += 1;
        textMeatCount.text = $"{meatCount}/{playerCollisin.score}";
    }
    private void IncrementPieCountCount()
    {
        pieCount += 1;
        textPieCount.text = $"{pieCount}/{playerCollisin.score}";
    }
    private void IncrementSardinsCountCount()
    {
        sardinsCount += 1;
        textSardinsCount.text = $"{sardinsCount}/{playerCollisin.score}";
    }

    public void LoadSaveFromCloud()
    {
        textCoinCount.text = YandexGame.savesData.coins.ToString();
        textCrystalCount.text = YandexGame.savesData.crystals.ToString();
    }
    public void MySaves()
    {
        YandexGame.savesData.coins = currentCoins;
        YandexGame.savesData.crystals = currentCrystals;

        YandexGame.SaveProgress();
    }
}
