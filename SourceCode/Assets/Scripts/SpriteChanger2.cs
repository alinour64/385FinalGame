using UnityEngine;

public class SpriteChanger2 : MonoBehaviour
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
