using UnityEngine;
using Zenject;

public class ProjectInstallers : MonoInstaller
{
    [SerializeField] private SceneLoader _sceneLoader;
    public override void InstallBindings()
    {
        Container.Bind<SceneLoader>().FromComponentsInNewPrefab(_sceneLoader).AsSingle();
    }
}
