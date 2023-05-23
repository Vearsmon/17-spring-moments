using System;
using System.Collections.Generic;
using Model;
using NPCs.Storyteller;
using UnityEngine;
using UnityEngine.UI;

public class PapersViewer : MonoBehaviour
{
    [SerializeField] private Image currentPaper;
    [SerializeField] private int currentIndex;
    [SerializeField] private int rightDocument;

    private int attemptsCount;
    
    [SerializeField] private List<Sprite> papers;

    private void Start()
    {
        currentPaper = gameObject.GetComponent<Image>();
        
        if (papers.Count > 0)
            currentPaper.sprite = papers[currentIndex];
    }

    public void TryTakeRightDocument()
    {
        if (currentIndex != rightDocument)
            return;
        
        attemptsCount++;
        if (!Core.HouseState.TryTakeDocument())
        {
            if (attemptsCount != 1) 
                return;
            var storyteller = GameObject.FindGameObjectWithTag("Storyteller").GetComponent<Storyteller>();
            storyteller.ShowMessage("ШТИРЛИЦ ПОПЫТАЛСЯ ВЗЯТЬ ДОКУМЕНТ, НО ДОКУМЕНТ НЕ ДАВАЛСЯ. " +
                                    "ШТИРЛИЦ РЕШИЛ ПОДУМАТЬ ЕЩЁ");
            return;
        }

        papers.RemoveAt(currentIndex);
        UpdatePaper();
    }
    
    public void TrySwitchLeft()
    {
        if (currentIndex <= 0)
            return;
        
        currentIndex--;
        UpdatePaper();
    }

    public void TrySwitchRight()
    {
        if (currentIndex >= papers.Count)
            return;
        
        currentIndex++;
        UpdatePaper();
    }

    private void UpdatePaper()
    {
        currentPaper.sprite = papers[currentIndex];
    }
}
