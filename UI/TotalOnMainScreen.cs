using TMPro;
using UnityEngine;
using YG;

public class TotalOnMainScreen : MonoBehaviour
{
    public int coinsPP;
    public int crystalsPP;
    public TMP_Text textCoinCount;
    public TMP_Text textCrystalCount;

    private int coinsYa;
    private int crystalsYa;

    void Start()
    {
        coinsPP = PlayerPrefs.GetInt("Coins");
        crystalsPP = PlayerPrefs.GetInt("Crystals");

        coinsYa = YandexGame.savesData.coins;
        crystalsYa = YandexGame.savesData.crystals;

        if (coinsPP > coinsYa)
        {
            textCoinCount.text = coinsPP.ToString();
        }
        else
        {
            textCoinCount.text = coinsYa.ToString();
        }

        if (crystalsPP > crystalsYa)
        {
            textCrystalCount.text = crystalsPP.ToString();
        }
        else
        {
            textCrystalCount.text = crystalsYa.ToString();
        }

        if (crystalsPP == crystalsYa)
        {
            textCrystalCount.text = crystalsYa.ToString();
        }
        if (coinsPP == coinsYa)
        {
            textCoinCount.text = coinsYa.ToString();
        }

    }
}
