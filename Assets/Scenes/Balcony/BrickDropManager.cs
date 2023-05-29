using System;
using Items.InteractionDetector;
using Items.Inventory;
using Model;
using NPCs.Storyteller;
using UnityEngine;

namespace Scenes.Balcony
{
    public class BrickDropManager : MonoBehaviour
    {
        private IInteractionDetector interactionDetector;

        [SerializeField] private Animator mullerAnimator;
        [SerializeField] private Animator stierlitzAnimator;
        private bool animationStarted;

        private string brick = "Brick";
        
        private EscapeManager escapeManager;
        private Storyteller storyteller;
        private static readonly int Hurted = Animator.StringToHash("Hurted");
        private static readonly int Fell = Animator.StringToHash("Fell");

        private void Start()
        {
            storyteller = GameObject.FindGameObjectWithTag("Storyteller").GetComponent<Storyteller>();
            escapeManager = GameObject.FindGameObjectWithTag("EscapeManager").GetComponent<EscapeManager>();
            
            interactionDetector = GetComponent<IInteractionDetector>();
            interactionDetector.Interacted += DropBricks;
        }

        private void Update()
        {
            if (animationStarted)
                Debug.Log("Dropping animation started");
        }

        private void DropBricks(GameObject obj)
        {
            var inventory = obj.GetComponent<Inventory>();
            if (inventory.Contains(brick, 2) 
                && Core.BalconyState.MullerAppeared)
            {
                inventory.Items.RemoveAll(item => item.Name == brick);
                PlayFirstAnimationStep();
                animationStarted = true;
            }
            else if (!animationStarted)
            {
                storyteller.ShowMessage("\"Думаете, легко работать на две Ставки?\" — вздыхал Штирлиц.".ToUpper());
                //TODO ну крч думаю сделать список анеков которые рандомно будут вылезать)
            }
        }

        private void PlayFirstAnimationStep()
        {
            mullerAnimator.SetBool(Hurted, true);
            storyteller.ShowMessage("\"Вот-те раз\" — воскликнул Мюллер.".ToUpper());
            escapeManager.onClose.RemoveListener(PlayFirstAnimationStep);
            escapeManager.onClose.AddListener(PlaySecondAnimationStep);
        }
        
        private void PlaySecondAnimationStep()
        {
            mullerAnimator.SetBool(Fell, true);
            storyteller.ShowMessage("\"Вот-те два\" — ответил Штирлиц.".ToUpper());
            escapeManager.onClose.RemoveListener(PlaySecondAnimationStep);
        }
        
        
        
    }
}
