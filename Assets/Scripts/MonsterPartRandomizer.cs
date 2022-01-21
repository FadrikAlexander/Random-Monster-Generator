using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for selecting a random sprite for the part
public class MonsterPartRandomizer : MonoBehaviour
{
    [SerializeField] List<Sprite> monsterPartSprites;
    [SerializeField] int partsSetCount = 1;
    [SerializeField] bool isMultiColor = false; //can the sprite be in multiple colors

    private void OnEnable()
    {
        Sprite partSprite;

        if (MonsterGenerator.Instance.IsMultiColor() && isMultiColor)
        {
            //Choose a part
            int partIndex = Random.Range(0, partsSetCount);

            //Hop the list to Choose the part in that color
            partIndex += MonsterGenerator.Instance.GetColorIndex() * partsSetCount;

            partSprite = monsterPartSprites[partIndex];
        }
        else
            partSprite = monsterPartSprites[Random.Range(0, monsterPartSprites.Count)];


        if (GetComponent<SpriteRenderer>() != null) //if only one sprite renderer change it (Mouth - Nose)
            GetComponent<SpriteRenderer>().sprite = partSprite;
        else // if multiple spriteRenderers are in the object they all get the same sprite (Eyes - Arms ...)
        {
            foreach (var v in GetComponentsInChildren<SpriteRenderer>())
                v.sprite = partSprite;
        }
    }
}
