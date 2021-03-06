using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script is for generating monster prefabs
public class MonsterGenerator : MonoBehaviour
{
    public static MonsterGenerator Instance;

    [SerializeField] List<GameObject> monstersList;
    [SerializeField] int colorsCount = 6; //Number of colors in the set

    [Space]
    [Header("UI Elements")]
    [SerializeField] TMP_InputField seedInputField;
    [SerializeField] TextMeshProUGUI placeHolderSeedText;
    [SerializeField] TextMeshProUGUI seedName;

    GameObject currentMonster = null;

    private void Awake()
    {
        Instance = this;

        GenerateNewMonster();
    }

    public void GenerateNewMonster()
    {
        SetRandomSeed();

        seedName.text = seedInputField.text;

        //Destroy the previous Monster
        if (currentMonster != null) Destroy(currentMonster);

        //Select new Color
        SetNewColorIndex();

        //Spawn new Monster
        currentMonster = Instantiate(monstersList[Random.Range(0, monstersList.Count)]);
        currentMonster.transform.position = this.transform.position;
    }

    #region Random Seed Manipulation
    int currentSeed;
    void SetRandomSeed()
    {
        if (seedInputField.text != "")
        {
            try //only numbers
            {
                currentSeed = System.Int32.Parse(seedInputField.text);
            }
            catch //if contains Letters
            {
                currentSeed = seedInputField.text.GetHashCode();
            }
        }
        else
            currentSeed = Random.seed;


        Random.InitState(currentSeed);
        placeHolderSeedText.text = currentSeed.ToString();
    }

    public void CopySeedToClipboard()
    {
        GUIUtility.systemCopyBuffer = currentSeed.ToString();
    }
    public void ClearSeed()
    {
        seedInputField.text = "";
    }
    #endregion

    #region Colors
    int colorIndex = 0;
    public int GetColorIndex() { return colorIndex; }
    void SetNewColorIndex()
    {
        colorIndex = Random.Range(0, colorsCount);
    }

    bool isMultiColor = true;
    public bool IsMultiColor() { return isMultiColor; }

    //Called from the UI
    public void SetIsMultiColor(bool flag) { isMultiColor = flag; }

    #endregion
}
