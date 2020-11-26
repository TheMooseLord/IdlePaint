using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;
using System;

[Serializable]
public class PlayerData
{
    public short notationType;

    public BigDouble[] challengeLevel = new BigDouble[4];

    public bool isChallenge1Active;
    public bool isChallenge2Active;
    public bool isChallenge3Active;

    //paint
    public BigDouble paint;
    public BigDouble paintPerSecond;
    public BigDouble nextColorsCost;

    //colors
    public BigDouble[] colorUpgradeCost = new BigDouble[6];
    public BigDouble[] colorUpgradePower = new BigDouble[6];
    public BigDouble[] colorUpgradeLevel = new BigDouble[6];

    //prestige
    public BigDouble dye;
    public BigDouble dyeToGet;

    public BigDouble paintBoost;
    public BigDouble paintBoostCost;
    public BigDouble dyeBoost;
    public BigDouble dyeBoostCost;

    public int screenResolutionIndex;

    public PlayerData()
    {
        FullReset();
    }

    public void FullReset()
    {
        //paint
        paint = 10;
        paintPerSecond = 0;
        nextColorsCost = 7.28e3;

        //colors
        colorUpgradePower[0] = 1;
        colorUpgradeLevel[0] = 0;
        colorUpgradeCost[0] = 10;

        colorUpgradePower[1] = 5;
        colorUpgradeLevel[1] = 0;
        colorUpgradeCost[1] = 25;

        colorUpgradePower[2] = 25;
        colorUpgradeLevel[2] = 0;
        colorUpgradeCost[2] = 125;

        colorUpgradePower[3] = 20000;
        colorUpgradeLevel[3] = 0;
        colorUpgradeCost[3] = 65000;

        colorUpgradePower[4] = 100000;
        colorUpgradeLevel[4] = 0;
        colorUpgradeCost[4] = 200000;

        colorUpgradePower[5] = 225000;
        colorUpgradeLevel[5] = 0;
        colorUpgradeCost[5] = 500000;

        //dye
        dye = 0;
        dyeToGet = 1;

        paintBoost = 1;
        paintBoostCost = 10;
        dyeBoost = 1;
        dyeBoostCost = 1.28e3;
    }
}

public class Main : MonoBehaviour
{
    public PlayerData data;

    //paint
    public Text paintText;
    public Text paintPerSecText;

    //red
    public Text[] colorText = new Text[6];

    //prestige
    public Text dyeText;
    public Text dyeToGetText;

    public Text paintBoostText;
    public Text dyeBoostText;

    public void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, true);
        Application.runInBackground = true;

        SaveSystem.LoadPlayer(ref data);
    }

    public void Update()
    {
        data.paintPerSecond = (data.colorUpgradeLevel[0] * data.colorUpgradePower[0]) + (data.colorUpgradeLevel[1] * data.colorUpgradePower[1]) + (data.colorUpgradeLevel[2] * data.colorUpgradePower[2]) + (data.colorUpgradeLevel[3] * data.colorUpgradePower[3]) + (data.colorUpgradeLevel[4] * data.colorUpgradePower[4]) + (data.colorUpgradeLevel[4] * data.colorUpgradePower[4]);

        //prestige
        data.dyeToGet = (150 * Sqrt(data.paint / 5e5));
        dyeText.text = $"Dye: {Methods.NotationMethod(data.dye, "F0")}";
        dyeToGetText.text = $"Collect Dye:\n+{Methods.NotationMethod(data.dyeToGet, "F0")} Dye";

        paintBoostText.text = $"{Methods.NotationMethod(data.paintBoost, "F2")}x Paint Boost\nUpgrade: {Methods.NotationMethod(data.paintBoostCost, "F0")} Dye";
        dyeBoostText.text = $"{Methods.NotationMethod(data.dyeBoost, "F2")}x More Dye\nUpgrade: {Methods.NotationMethod(data.dyeBoostCost, "F0")} Dye";

        //paint
        paintText.text = $"paint: {Methods.NotationMethod(data.paint, "F0")}";
        paintPerSecText.text = $"{Methods.NotationMethod(data.paintPerSecond, "F0")} paint/s";

        for (int i = 0; i < colorText.Length; i++)
        {
            colorText[i].text = $"Upgrade\n+{Methods.NotationMethod(data.colorUpgradePower[i], "F0")} Paint/s\n {Methods.NotationMethod(data.colorUpgradeCost[i], "F0")} Paint\nLevel: {Methods.NotationMethod(data.colorUpgradeLevel[i], "F0")}";
        }

        data.paint += data.paintPerSecond * Time.deltaTime;
        SaveSystem.SavePlayer(data);
    }
}
