using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SettingsWindow : ModalWindow
{
    private SceneLoader _sceneLoader;

    [Inject]
    public void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void Repeat()
    {
        _sceneLoader.ReloadScene();
    }


}
