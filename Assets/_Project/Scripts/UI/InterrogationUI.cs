using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InventixGames.Core;
using LastWitness.Suspects;
using LastWitness.Evidence;
namespace LastWitness
{
    /// <summary>
    /// Free-form interrogation. Player types any question; Claude (suspect persona) replies.
    /// </summary>
    public class InterrogationUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup root;
        [SerializeField] private TMP_Text suspectNameText;
        [SerializeField] private TMP_Text replyText;
        [SerializeField] private TMP_InputField questionInput;
        [SerializeField] private Button sendButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private Transform evidenceDropZone;
        [SerializeField] private EvidenceLedger ledger;
        [SerializeField] private float typewriterCps = 50f;
        private SuspectNpc _suspect;
        private IAICopilotService _ai;
        private Coroutine _typing;
        private readonly System.Collections.Generic.List<EvidenceItemSO> _shownEvidence = new();

        private void Awake()
        {
            sendButton.onClick.AddListener(OnSend);
            closeButton.onClick.AddListener(Close);
            Close();
        }
        public void OpenWith(SuspectNpc s)
        {
            _suspect = s;
            _ai = ServiceLocator.Get<IAICopilotService>();
            suspectNameText.text = s.Persona.displayName;
            replyText.text = "..."; questionInput.text = ""; _shownEvidence.Clear();
            root.alpha = 1; root.interactable = true; root.blocksRaycasts = true;
            questionInput.Select(); questionInput.ActivateInputField();
            _ai.Ask(s.Persona.ComposeFullSystemPrompt(), "The detective has just walked in. React in 1–2 sentences in character.", OnReply);
        }
        public void Close() { root.alpha = 0; root.interactable = false; root.blocksRaycasts = false; _suspect = null; }
        public void ShowEvidence(EvidenceItemSO ev) { if (!_shownEvidence.Contains(ev)) _shownEvidence.Add(ev); }
        private void OnSend()
        {
            if (_suspect == null) return;
            string q = questionInput.text.Trim(); if (string.IsNullOrEmpty(q)) return; questionInput.text = "";
            string sys = _suspect.Persona.ComposeFullSystemPrompt();
            string evCtx = _shownEvidence.Count > 0 ? "The detective is showing you these items: " + string.Join(", ", _shownEvidence.ConvertAll(e => e.displayName)) + ". " : "";
            string mem = string.Join(" | ", _ai.GetMemory(_suspect.Persona.npcId));
            if (!string.IsNullOrEmpty(mem)) sys += "\n\nRecent context: " + mem;
            replyText.text = "...";
            _ai.Ask(sys, evCtx + q, OnReply);
            _ai.RememberFact(_suspect.Persona.npcId, $"Detective asked: {q}");
        }
        private void OnReply(string text)
        {
            if (_typing != null) StopCoroutine(_typing);
            _typing = StartCoroutine(Type(text));
            if (_suspect != null) ledger?.Tag(_suspect.Persona.npcId, text);
        }
        private IEnumerator Type(string text)
        {
            replyText.text = "";
            float d = 1f / typewriterCps;
            for (int i = 0; i < text.Length; i++) { replyText.text += text[i]; yield return new WaitForSeconds(d); }
        }
    }
}
