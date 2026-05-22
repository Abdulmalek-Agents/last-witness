using System;
using UnityEngine;
using InventixGames.Core;
using LastWitness.Cases;
using LastWitness.Evidence;
namespace LastWitness.Deduction
{
    public enum Verdict { TrueEvidenced, TrueUnderEvidenced, False }

    public class DeductionEvaluator : MonoBehaviour
    {
        public void Evaluate(CaseSO caseData, string accusedSuspectId, List<EvidenceItemSO> bundle, string accusationText, Action<Verdict, string> onResult)
        {
            string sys = "You are a fair, strict judge in a detective game. You receive the case's HIDDEN TRUTH plus the player's accusation. Score one of: TRUE_EVIDENCED (correct + strongly evidenced), TRUE_UNDEREVIDENCED (correct but weak evidence), FALSE. Reply ONLY with the label on line 1 then a one-paragraph rationale on line 2.";
            string evList = string.Join(", ", bundle.ConvertAll(e => e.displayName));
            string user = $"HIDDEN TRUTH:\n{caseData.hiddenTruth}\n\nPLAYER ACCUSATION:\nSuspect: {accusedSuspectId}\nEvidence cited: {evList}\nAccusation text: {accusationText}";
            ServiceLocator.Get<IAICopilotService>().Ask(sys, user, raw =>
            {
                var parts = raw.Split(new[] { '\n' }, 2, StringSplitOptions.RemoveEmptyEntries);
                var label = parts.Length > 0 ? parts[0].Trim().ToUpperInvariant() : "FALSE";
                var rationale = parts.Length > 1 ? parts[1].Trim() : "";
                var v = label.Contains("TRUE_EVIDENCED") ? Verdict.TrueEvidenced
                       : label.Contains("TRUE_UNDEREVIDENCED") ? Verdict.TrueUnderEvidenced
                       : Verdict.False;
                onResult?.Invoke(v, rationale);
            });
        }
    }

    using System.Collections.Generic; // placeholder fix; remove from final
}
