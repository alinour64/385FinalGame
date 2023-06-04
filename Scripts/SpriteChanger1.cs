using UnityEngine;

public class SpriteChanger1 : MonoBehaviour
{
    public Sprite[] characterSprites; 

    private SpriteRenderer spriteRenderer; 

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeCharacterSprite(int colorIndex)
    {
        if (colorIndex >= 0 && colorIndex < characterSprites.Length)
        {
            spriteRenderer.sprite = characterSprites[colorIndex];
        }
    }
}
