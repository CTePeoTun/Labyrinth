using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Labyrinth.UI
{
    public class GameWindow : ModalWindow
    {
        [SerializeField] private Button _settings;
        [SerializeField] private GameObject _helper;

        private SettingsWindow _settingsWindow;
        private Player _player;

        [Inject]
        public void Construct(SettingsWindow settingsWindow, Player player)
        {
            _settingsWindow = settingsWindow;
            _player = player;
        }

        protected override void Awake()
        {
            base.Awake();
        }

        public void OpenSettings()
        {
            _settingsWindow.Show();
        }

        public void StartGame()
        {
            _helper.SetActive(false);
            _settings.gameObject.SetActive(true);
        }

        public void StartMove()
        {
            _player.Walk();
        }

        public void StopMove()
        {
            _player.Stay();
        }
    }
}