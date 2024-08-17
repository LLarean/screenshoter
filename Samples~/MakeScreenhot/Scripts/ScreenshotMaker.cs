using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class ScreenshotMaker : MonoBehaviour
{
    [Header("Required settings")]
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector2Int _screenshotSize;
    [Header("Viewing the received screenshot")]
    [SerializeField] private Image _preview;
    [SerializeField] private Button _clearPreview;
    [Header("Options for how the screenshot was received")]
    [SerializeField] private Button _getTexture;
    [SerializeField] private Button _getSprite;
    [SerializeField] private Button _getByteArray;
    
    private Screenshoter _screensoter;

    private void Start()
    {
        _screensoter = new Screenshoter(_camera);

        ClearPreview();
        _clearPreview.onClick.AddListener(ClearPreview);
        
        _getSprite.onClick.AddListener(GetSprite);
        _getTexture.onClick.AddListener(GetTexture);
        _getByteArray.onClick.AddListener(GetByteArray);
    }

    private void ClearPreview()
    {
        _preview.color = Color.black;
        _preview.sprite = null;
    }

    private void GetSprite()
    {
        ClearPreview();
        _preview.color = Color.white;
        
        var sprite = _screensoter.GetScreenshotSprite(_screenshotSize);
        _preview.sprite = sprite;
    }
    
    private void GetTexture()
    {
        ClearPreview();
        _preview.color = Color.white;

        var texture2D = _screensoter.GetScreenshotTexture2D(_screenshotSize);
        var sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height),
            new Vector2(0.5f, 0.5f));

        _preview.sprite = sprite;
    }

    private void GetByteArray()
    {
        ClearPreview();
        _preview.color = Color.white;
        
        var spriteBytes = _screensoter.GetScreenshotArray(_screenshotSize);
        var texture2D = new Texture2D(1, 1);
        texture2D.LoadImage(spriteBytes);
        var sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height),
            new Vector2(0.5f, 0.5f));
        
        _preview.sprite = sprite;
    }
}