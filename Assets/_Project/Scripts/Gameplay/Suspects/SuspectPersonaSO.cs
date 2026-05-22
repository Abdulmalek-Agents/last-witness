using UnityEngine;
using System.Collections.Generic;
namespace LastWitness.Suspects
{
    /// <summary>
    /// Extends the base AI persona with detective-genre fields: secrets, tells, lie strategy.
    /// The systemPrompt field combines all of these at runtime.
    /// </summary>
    [CreateAssetMenu(menuName = "Last Witness/Suspect Persona", fileName = "SuspectPersona_")]
    public class SuspectPersonaSO : InventixGames.Core.AICopilotPersonaSO
    {
        [Header("Detective fields")]
        [TextArea(3, 10)] public string privateKnowledge;
        [TextArea(2, 6)] public string secret;
        [TextArea(3, 8)] public string relationshipsBriefing;
        [TextArea(2, 6)] public string tells;
        [TextArea(2, 6)] public string lieStrategy;
        [Range(0f, 1f)] public float truthThreshold = 0.2f;

        /// <summary>Composed system prompt for Claude.</summary>
        public string ComposeFullSystemPrompt()
        {
            var parts = new List<string>
            {
                systemPrompt,
                "\nWhat you know privately (DO NOT REVEAL UNLESS PRESSED WITH EVIDENCE):\n" + privateKnowledge,
                "\nYour secret:\n" + secret,
                "\nRelationships:\n" + relationshipsBriefing,
                "\nTells:\n" + tells,
                "\nLie strategy:\n" + lieStrategy,
                "\nRules: Stay in character. 1-3 short sentences. Never reference being an AI. If pressed with strong evidence, you may admit narrowly to protect your secret."
            };
            return string.Join("\n", parts);
        }
    }
}
