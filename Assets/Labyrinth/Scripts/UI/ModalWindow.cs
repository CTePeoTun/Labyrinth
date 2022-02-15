using UnityEngine;
using UnityEngine.UI;

public class ModalWindow : MonoBehaviour
{
    [SerializeField] private bool _isHidedOnStart = true;
    [SerializeField] private GameObject _background;
    [SerializeField] protected GameObject _window;

    protected virtual void Awake()
    {
        if (_isHidedOnStart)
        {
            Hide();
        } else
        {
            Show();
        }
        
    }

    public virtual void Hide()
    {
        _window.SetActive(false);
        _background.SetActive(false);
    }

    public virtual void Show()
    {
        _window.SetActive(true);
        _background.SetActive(true);
    }
}
