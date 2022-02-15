using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Labyrinth.UI
{
    public class ResultWindow : ModalWindow
    {
        [SerializeField] private Text _header;
        [SerializeField] private Text _score;
        [SerializeField] private Button _next;
        [SerializeField] private Button _repeat;

        private Player _player;
        private SceneLoader _sceneLoader;
        private GameWindow _gameWindow;
        private SettingsWindow _settingsWindow;

        [Inject]
        public void Construct(Player player, SceneLoader sceneLoader, GameWindow gameWindow, SettingsWindow settingsWindow)
        {
            _player = player;
            _sceneLoader = sceneLoader;
            _gameWindow = gameWindow;//todo: rework in future, extra information about other windows
            _settingsWindow = settingsWindow;//todo: 
        }

        protected override void Awake()
        {
            _player.OnDeath += ShowLose;
            _player.OnFinish += ShowWin;
            base.Awake();
        }

        private void OnDestroy()
        {
            _player.OnDeath -= ShowLose;
            _player.OnFinish -= ShowWin;
        }

        public void ShowWin()
        {
            SetInfo("Win!", 1000, false); //TODO: Localize, hardcode scores
            base.Show();
        }

        public void ShowLose()
        {
            SetInfo("Lose!", 0, false);//TODO: Localize, hardcode scores
            base.Show();
        }

        private void SetInfo(string header, int score, bool isWin)
        {
            _settingsWindow.Hide(); 
            _gameWindow.Hide();
            _header.Set(header);
            _score.SetIntText(score);
            SetButtonsState(isWin);
        }

        public void Repeat()
        {
            _sceneLoader.ReloadScene();//TODO: temp
        }

        public void Next()
        {
            _sceneLoader.ReloadScene();//TODO: temp
        }

        private void SetButtonsState(bool isForWinner)
        {
            _next.gameObject.SetActive(isForWinner);
            _repeat.gameObject.SetActive(!isForWinner);
        }
    }
}