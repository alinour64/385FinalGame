using UnityEngine;
using TMPro;

public class ColorPicker2 : MonoBehaviour
{
    public SpriteChanger2 characterSpriteChanger; 

    private TMP_Dropdown colorDropdown; 

    private void Start()
    {
        colorDropdown = GetComponent<TMP_Dropdown>(); 
        colorDropdown.onValueChanged.AddListener(OnColorDropdownValueChanged);
    }

    private void OnColorDropdownValueChanged(int colorIndex)
    {
        characterSpriteChanger.ChangeCharacterSprite(colorIndex);
    }
}
