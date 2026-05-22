using UnityEngine;
using UnityEngine.UI;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace InventixGames.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private MissionDatabaseSO database;
        [SerializeField] private Button newCaseButton, continueButton, quitButton;
        private void Start() { newCaseButton.onClick.AddListener(OnNewCase); continueButton.onClick.AddListener(OnContinue); quitButton.onClick.AddListener(OnQuit); var s = ServiceLocator.Get<ISaveService>(); continueButton.interactable = s.Data.completedMissionIds.Count > 0; }
        private void OnNewCase() { var s = ServiceLocator.Get<ISaveService>(); s.Data.completedMissionIds.Clear(); s.Save(); if (database.missions.Count > 0) ServiceLocator.Get<IMissionService>().StartMission(database.missions[0].missionId); }
        private void OnContinue() { var s = ServiceLocator.Get<ISaveService>(); foreach (var m in database.missions) if (!s.IsMissionComplete(m.missionId)) { ServiceLocator.Get<IMissionService>().StartMission(m.missionId); return; } }
        private void OnQuit() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
