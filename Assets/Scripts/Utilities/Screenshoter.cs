using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// The utility allows you to create screenshots with the size you specify
    /// </summary>
    public class Screenshoter
    {
        /// <summary>
        /// The camera that will be used to create the screenshot
        /// </summary>
        private readonly Camera _camera;

        /// <summary>
        /// The camera should be looking at the object the screenshot of which will be taken
        /// </summary>
        /// <param name="camera">The camera that will be used to create the screenshot</param>
        public Screenshoter(Camera camera)
        {
            _camera = camera;
        }
        
        /// <summary>
        /// Creates a screenshot with the specified size and returns the Sprite
        /// </summary>
        /// <param name="screenshotSize">The size of the screenshot being created</param>
        public Sprite GetScreenshotSprite(Vector2Int screenshotSize)
        {
            EnablePhotoMode(screenshotSize);
            
            var byteArray = GetByteArray(screenshotSize);
            Texture2D texture2D = new Texture2D(1, 1);
            texture2D.LoadImage(byteArray);
            
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
            
            _camera.targetTexture = null;
            return sprite;
        }

        /// <summary>
        /// Creates a screenshot with the specified size and returns the Texture2D
        /// </summary>
        /// <param name="screenshotSize">The size of the screenshot being created</param>
        public Texture2D GetScreenshotTexture(Vector2Int screenshotSize)
        {
            EnablePhotoMode(screenshotSize);
            
            var byteArray = GetByteArray(screenshotSize);
            Texture2D texture2D = new Texture2D(1, 1);
            texture2D.LoadImage(byteArray);
            
            _camera.targetTexture = null;
            return texture2D;
        }

        /// <summary>
        /// Creates a screenshot of the specified size and returns the byte[]
        /// </summary>
        /// <param name="screenshotSize">The size of the screenshot being created</param>
        public byte[] GetScreenshotArray(Vector2Int screenshotSize)
        {
            EnablePhotoMode(screenshotSize);
            
            var byteArray = GetByteArray(screenshotSize);

            _camera.targetTexture = null;
            return byteArray;
        }
        
        private void EnablePhotoMode(Vector2Int photoSize)
        {
            var screenTexture = new RenderTexture(photoSize.x, photoSize.y, 16);
            RenderTexture.active = screenTexture;
            _camera.targetTexture = screenTexture;
            _camera.Render();
        }

        private byte[] GetByteArray(Vector2Int screenshotSize)
        {
            var renderedTexture = GetRendererTexture(screenshotSize);
            byte[] byteArray = renderedTexture.EncodeToPNG();
            return byteArray;
        }

        private Texture2D GetRendererTexture(Vector2Int screenshotSize)
        {
            var renderedTexture = new Texture2D(screenshotSize.x, screenshotSize.y);
            renderedTexture.ReadPixels(new Rect(0, 0, screenshotSize.x, screenshotSize.y), 0, 0);
            return renderedTexture;
        }
    }
}