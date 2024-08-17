# Screenshoter

This package provides a simple utility for taking screenshots of a scene in Unity3D

## INSTALLATION

There are 3 ways to install this plugin:

- import [Screenshoter.unitypackage](https://github.com/llarean/screenshoter/releases) via *Assets-Import Package*
- clone/[download](https://github.com/llarean/screenshoter/archive/master.zip) this repository and move the *Plugins* folder to your Unity project's *Assets* folder
- *(via Package Manager)* Select Add package from git URL from the add menu. A text box and an Add button appear. Enter a valid Git URL in the text box:
    - `"https://github.com/llarean/screenshoter.git"`
- *(via Package Manager)* add the following line to *Packages/manifest.json*:
    - `"com.llarean.screenshoter": "https://github.com/llarean/screenshoter.git",`

## HOW TO and EXAMPLE CODE


1. Create an instance of the class and pass to the constructor the camera from which the screenshot will be taken

```csharp
using UnityEngine;
using Utilities;

public interface Example : MonoBehaviour
{
    [SerializeField] private Camera _screenshotCamera;
    [SerializeField] private Vector2Int _screenshotSize;
    
    private Screenshoter _screensoter;
    
    private void Start()
    {
        _screensoter = new Screenshoter(_screenshotCamera);
    }
}
```

2. To get a screenshot in the form of a sprite

```csharp
private void GetSprite()
{
    Sprite sprite = _screensoter.GetScreenshotSprite(_screenshotSize);
}
```

3. To get a screenshot in the form of a texture

```csharp
private void GetTexture()
{
    Texture2D texture2D = _screensoter.GetScreenshotTexture2D(_screenshotSize);
}
```

4. To get a screenshot in the form of an array of bytes

```csharp
private void GetTexture()
{
    byte[] spriteBytes = _screensoter.GetScreenshotArray(_screenshotSize);
}
```