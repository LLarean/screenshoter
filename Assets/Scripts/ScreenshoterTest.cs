using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class ScreenshoterTest : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector2Int _screenshotSize;
    [Space]
    [SerializeField] private Image _loadedSScreenshot;
    [Space]
    [SerializeField] private Button _getTexture;
    [SerializeField] private Button _getSprite;
    [SerializeField] private Button _getByteArray;
    
    private Screenshoter _screensoter;

    private void Start()
    {
        _screensoter = new Screenshoter(_camera);
        
        _getSprite.onClick.AddListener(GetSprite);
        _getTexture.onClick.AddListener(GetTexture);
        _getByteArray.onClick.AddListener(GetByteArray);

        _screensoter.GetScreenshotArray(_screenshotSize);
    }

    private void GetSprite()
    {
        _loadedSScreenshot.sprite = null;
        
        var sprite = _screensoter.GetScreenshotSprite(_screenshotSize);
        _loadedSScreenshot.sprite = sprite;
    }
    
    private void GetTexture()
    {
        _loadedSScreenshot.sprite = null;

        Texture2D texture = new Texture2D(1, 1);
        texture = _screensoter.GetScreenshotTexture(_screenshotSize);

        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        _loadedSScreenshot.sprite = newSprite;
    }

    private void GetByteArray()
    {
        _loadedSScreenshot.sprite = null;
        
        var spriteBytes = _screensoter.GetScreenshotArray(_screenshotSize);
        
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(spriteBytes);

        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        
        _loadedSScreenshot.sprite = newSprite;
    }
}