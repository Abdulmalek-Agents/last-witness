using UnityEngine;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace LastWitness.Case01
{
    public class Case01Director : MonoBehaviour
    {
        [SerializeField] private string caseId = "C01";
        [SerializeField] private GameObject openingCutscene;
        [SerializeField] private GameObject accusationPanel;
        [SerializeField] private GameObject verdictPanel;
        private IMissionService _m;
        private void Start() { _m = ServiceLocator.Get<IMissionService>(); _m.OnMissionCompleted += C; if (openingCutscene) openingCutscene.SetActive(true); }
        private void OnDestroy() { if (_m != null) _m.OnMissionCompleted -= C; }
        public void OpenAccusation() { if (accusationPanel) accusationPanel.SetActive(true); }
        public void ShowVerdict() { if (verdictPanel) verdictPanel.SetActive(true); }
        private void C(MissionDataSO m) { if (m.missionId == caseId) ShowVerdict(); }
    }
}
