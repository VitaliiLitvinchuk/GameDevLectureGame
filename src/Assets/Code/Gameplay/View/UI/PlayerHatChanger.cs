using System;
using Assets.Code.Data;
using Assets.Code.Infrastructure.Services.PlayerInventory;
using Assets.Code.Infrastructure.Services.StaticData;
using Assets.Code.StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code.Gameplay.View.UI
{
    public class PlayerHatChanger : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private Image _hatImage;

        [Inject]
        private IPlayerInventoryService _playerInventoryService;

        [Inject]
        private IStaticDataService _staticDataService;

        private void Start()
        {
            UpdateView();
        }

        private void Awake()
        {
            _button.onClick.AddListener(ChangeHat);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void ChangeHat()
        {
            if (!_playerInventoryService.HasAnyHat())
                return;

            _playerInventoryService.SelectNextHat();

            UpdateView();
        }

        private void UpdateView()
        {
            var selectedHat = _playerInventoryService.SelectedHat;

            bool validHat = selectedHat != HatTypeId.Unknown;
            _hatImage.enabled = validHat;

            if (!validHat)
                return;

            HatConfig config = _staticDataService.GetHatConfig(selectedHat);
            _hatImage.sprite = config.Sprite;
        }
    }
}