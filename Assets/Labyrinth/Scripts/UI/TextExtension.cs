using UnityEngine.UI;

public static class TextExtension
{
    public static void SetIntText(this Text text, int value)
    {
        text.text = value.ToString(); 
    }

    public static void Set(this Text text, string value)
    {
        text.text = value;
    }
}
