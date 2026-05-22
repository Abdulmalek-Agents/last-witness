using UnityEngine;
using InventixGames.Core;
namespace LastWitness.Suspects
{
    [RequireComponent(typeof(Collider))]
    public class SuspectNpc : MonoBehaviour
    {
        [SerializeField] private SuspectPersonaSO persona;
        [SerializeField] private InterrogationUI interrogationUI;
        public SuspectPersonaSO Persona => persona;
        public void OpenDialogue() { if (interrogationUI) interrogationUI.OpenWith(this); }
    }
}
