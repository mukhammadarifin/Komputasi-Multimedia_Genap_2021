using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTexture : MonoBehaviour
{
    public GameObject photoGUI;

    public GameObject frameGUI;

    public float ratio = 0.25f;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1)) StartCoroutine(CaptureScreen());
    }

    IEnumerator CaptureScreen()
    {
        photoGUI.SetActive(false);
        int sw = Screen.width;
        int sh = Screen.height;
        RectTransform frameTransform = frameGUI.GetComponent<RectTransform>();
        Rect framing = frameTransform.rect;
        Vector2 pivot = frameTransform.pivot;
        Vector2 origin = frameTransform.anchorMin;
        origin.x *= sw;
        origin.y *= sh;
        float xOffset = pivot.x * framing.width;
        origin.x += xOffset;
        float yOffset = pivot.y * framing.height;
        origin.y += yOffset;
        framing.x += origin.x;
        framing.y += origin.y;
        int textWidth = (int) framing.width;
        int textHeight = (int) framing.height;
        Texture2D texture = new Texture2D(textWidth, textHeight);
        yield return new WaitForEndOfFrame();
        texture.ReadPixels(framing, 0, 0);
        texture.Apply();
        photoGUI.SetActive(true);
        Vector3 photoScale =
            new Vector3(framing.width * ratio, framing.height * ratio, 1);
        photoGUI.GetComponent<RectTransform>().localScale = photoScale;
        photoGUI.GetComponent<RawImage>().texture = texture;
    }
}