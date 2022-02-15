using Labyrinth;
using Labyrinth.UI;
using UnityEngine;
using Zenject;

public class GameInstallers : MonoInstaller
{
    [SerializeField] private Player _player;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(_player).AsSingle();
    }
}
