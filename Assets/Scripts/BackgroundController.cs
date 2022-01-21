using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] List<Sprite> backgroundSprites;
    int currentBackgroundIndex = 0;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void GenerateNewBackground()
    {
        //Advance to the next Background
        currentBackgroundIndex++;
        if (currentBackgroundIndex >= backgroundSprites.Count)
            currentBackgroundIndex = 0;

        spriteRenderer.sprite = backgroundSprites[currentBackgroundIndex];

        GetComponent<BackgroundSlider>().Reset();
    }
}
