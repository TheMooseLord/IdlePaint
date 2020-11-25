using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;
using System;

[Serializable]
public class PlayerData
{
    //paint
    public BigDouble paint;
    public BigDouble paintPerSecond;
    public BigDouble nextColorsCost;

    //red
    public BigDouble redUpgradeCost;
    public BigDouble redUpgradePower;
    public BigDouble redUpgradeLevel;
    //orange
    public BigDouble orangeUpgradeCost;
    public BigDouble orangeUpgradePower;
    public BigDouble orangeUpgradeLevel;
    //yellow
    public BigDouble yellowUpgradeCost;
    public BigDouble yellowUpgradePower;
    public BigDouble yellowUpgradeLevel;
    //green
    public BigDouble greenUpgradeCost;
    public BigDouble greenUpgradePower;
    public BigDouble greenUpgradeLevel;
    //blue
    public BigDouble blueUpgradeCost;
    public BigDouble blueUpgradePower;
    public BigDouble blueUpgradeLevel;
    //purple
    public BigDouble purpleUpgradeCost;
    public BigDouble purpleUpgradePower;
    public BigDouble purpleUpgradeLevel;

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
        nextColorsCost = 15000;

        //red
        redUpgradePower = 1;
        redUpgradeLevel = 0;
        redUpgradeCost = 10;
        //orange
        orangeUpgradePower = 5;
        orangeUpgradeLevel = 0;
        orangeUpgradeCost = 25;
        //yellow
        yellowUpgradePower = 25;
        yellowUpgradeLevel = 0;
        yellowUpgradeCost = 125;
        //green
        greenUpgradePower = 20000;
        greenUpgradeLevel = 0;
        greenUpgradeCost = 65000;
        //blue
        blueUpgradePower = 100000;
        blueUpgradeLevel = 0;
        blueUpgradeCost = 200000;
        //purple
        purpleUpgradePower = 225000;
        purpleUpgradeLevel = 0;
        purpleUpgradeCost = 500000;

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
    public int notationType;

    //paint
    public Text paintText;
    public Text paintPerSecText;

    //red
    public Text redUpgradeText;
    //orange
    public Text orangeUpgradeText;
    //yellow
    public Text yellowUpgradeText;
    //green
    public Text greenUpgradeText;
    //blue
    public Text blueUpgradeText;
    //purple
    public Text purpleUpgradeText;

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
        data.paintPerSecond = (data.redUpgradeLevel * data.redUpgradePower) + (data.orangeUpgradeLevel * data.orangeUpgradePower) + (data.yellowUpgradeLevel * data.yellowUpgradePower) + (data.greenUpgradeLevel * data.greenUpgradePower) + (data.blueUpgradeLevel * data.blueUpgradePower) + (data.purpleUpgradeLevel * data.purpleUpgradePower);

        //prestige
        data.dyeToGet = (150 * Sqrt(data.paint / 5e5));
        dyeText.text = $"Dye: {Methods.NotationMethod(data.dye, "F0")}";
        dyeToGetText.text = $"Collect Dye:\n+{Methods.NotationMethod(data.dyeToGet, "F0")} Dye";

        paintBoostText.text = $"{Methods.NotationMethod(data.paintBoost, "F2")}x Paint Boost\nUpgrade: {Methods.NotationMethod(data.paintBoostCost, "F0")} Dye";
        dyeBoostText.text = $"{Methods.NotationMethod(data.dyeBoost, "F2")}x More Dye\nUpgrade: {Methods.NotationMethod(data.dyeBoostCost, "F0")} Dye";

        //paint
        paintText.text = $"paint: {Methods.NotationMethod(data.paint, "F0")}";
        paintPerSecText.text = $"{Methods.NotationMethod(data.paintPerSecond, "F0")} paint/s";

        //red
        redUpgradeText.text = $"Upgrade\n+{Methods.NotationMethod(data.redUpgradePower, "F0")} Paint/s\n {Methods.NotationMethod(data.redUpgradeCost, "F0")} Paint\nLevel: {Methods.NotationMethod(data.redUpgradeLevel, "F0")}";
        orangeUpgradeText.text = $"Upgrade\n+{Methods.NotationMethod(data.orangeUpgradePower, "F0")} Paint/s\n {Methods.NotationMethod(data.orangeUpgradeCost, "F0")} Paint\nLevel: {Methods.NotationMethod(data.orangeUpgradeLevel, "F0")}";
        yellowUpgradeText.text = $"Upgrade\n+{Methods.NotationMethod(data.yellowUpgradePower, "F0")} Paint/s\n {Methods.NotationMethod(data.yellowUpgradeCost, "F0")} Paint\nLevel: {Methods.NotationMethod(data.yellowUpgradeLevel, "F0")}";
        greenUpgradeText.text = $"Upgrade\n+{Methods.NotationMethod(data.greenUpgradePower, "F0")} Paint/s\n {Methods.NotationMethod(data.greenUpgradeCost, "F0")} Paint\nLevel: {Methods.NotationMethod(data.greenUpgradeLevel, "F0")}";
        blueUpgradeText.text = $"Upgrade\n+{Methods.NotationMethod(data.blueUpgradePower, "F0")} Paint/s\n {Methods.NotationMethod(data.blueUpgradeCost, "F0")} Paint\nLevel: {Methods.NotationMethod(data.blueUpgradeLevel, "F0")}";
        purpleUpgradeText.text = $"Upgrade\n+{Methods.NotationMethod(data.purpleUpgradePower, "F0")} Paint/s\n {Methods.NotationMethod(data.purpleUpgradeCost, "F0")} Paint\nLevel: {Methods.NotationMethod(data.purpleUpgradeLevel, "F0")}";

        data.paint += data.paintPerSecond * Time.deltaTime;
        SaveSystem.SavePlayer(data);
    }
}
