using UnityEngine;
using System.Collections.Generic;
namespace LastWitness.Evidence
{
    [CreateAssetMenu(menuName = "Last Witness/Evidence Item", fileName = "Evidence_")]
    public class EvidenceItemSO : ScriptableObject
    {
        public string evidenceId;
        public string displayName;
        [TextArea] public string description;
        public Sprite icon;
    }

    /// <summary>Per-case ledger of evidence the player has collected + suspect lines they've tagged.</summary>
    public class EvidenceLedger : MonoBehaviour
    {
        private readonly List<EvidenceItemSO> _items = new();
        private readonly List<(string suspectId, string line)> _lines = new();
        public IReadOnlyList<EvidenceItemSO> Items => _items;
        public IReadOnlyList<(string suspectId, string line)> Lines => _lines;

        public void Add(EvidenceItemSO item) { if (!_items.Contains(item)) _items.Add(item); }
        public void Tag(string suspectId, string line) { _lines.Add((suspectId, line)); }
    }
}
