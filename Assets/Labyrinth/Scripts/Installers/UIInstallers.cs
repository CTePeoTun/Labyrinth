using Labyrinth.UI;
using UnityEngine;
using Zenject;

public class UIInstallers : MonoInstaller
{
    [SerializeField] private ResultWindow _resultWindow;
    [SerializeField] private GameWindow _gameWindow;
    [SerializeField] private SettingsWindow _settingsWindow;

    public override void InstallBindings()
    {
        Container.Bind<ResultWindow>().FromInstance(_resultWindow).AsSingle();
        Container.Bind<GameWindow>().FromInstance(_gameWindow).AsSingle();
        Container.Bind<SettingsWindow>().FromInstance(_settingsWindow).AsSingle();
    }
}