using UnityEngine;
using System.Collections.Generic;
using LastWitness.Suspects;
using LastWitness.Evidence;
namespace LastWitness.Cases
{
    [CreateAssetMenu(menuName = "Last Witness/Case", fileName = "Case_")]
    public class CaseSO : ScriptableObject
    {
        public string caseId;
        public string displayName;
        [TextArea(3, 8)] public string briefingText;
        public List<SuspectPersonaSO> suspects = new();
        public List<EvidenceItemSO> evidenceItems = new();
        [TextArea(3, 10)]
        [Tooltip("Hidden truth used ONLY by DeductionEvaluator. Never sent to suspects.")]
        public string hiddenTruth;
        public List<string> requiredEvidenceForFullCase = new();
    }
}
