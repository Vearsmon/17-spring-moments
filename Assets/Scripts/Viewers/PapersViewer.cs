using System;
using System.Collections.Generic;
using Model;
using NPCs.Storyteller;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PapersViewer : MonoBehaviour
{
    [SerializeField] private Image currentPaper;
    [SerializeField] private int currentIndex;

    private static int attemptsCount;
    
    [SerializeField] private List<Sprite> papers;
    [SerializeField] private List<int> papersID;
    [SerializeField] private UnityEvent rightDocumentTaken;

    private void Start()
    {
        currentPaper = gameObject.GetComponent<Image>();

        var indexOfRightDocument = papersID.IndexOf(Core.HouseState.RightDocumentID);
        if (indexOfRightDocument != -1 && !Core.HouseState.Document)
        {
            papersID.RemoveAt(indexOfRightDocument);
            papers.RemoveAt(indexOfRightDocument);
        }
        if (papers.Count == 0) 
            return;
        
        currentPaper.sprite = papers[currentIndex];
    }

    public void TryTakeRightDocument()
    {
        attemptsCount++;
     
        if (!Core.HouseState.TablePuzzle.Solved || !Core.HouseState.Document)
        {
            var storyteller = GameObject.FindGameObjectWithTag("Storyteller").GetComponent<Storyteller>();
            storyteller.ShowMessage("ШТИРЛИЦ ПОПЫТАЛСЯ ВЗЯТЬ ДОКУМЕНТ, НО ДОКУМЕНТ НЕ ДАВАЛСЯ. " +
                                    "ШТИРЛИЦ РЕШИЛ ПОДУМАТЬ ЕЩЁ");
            return;
        }

        if (!Core.HouseState.TryTakeDocument(papersID[currentIndex]))
        {
            if (attemptsCount != 1) 
                return;
            
            var storyteller = GameObject.FindGameObjectWithTag("Storyteller").GetComponent<Storyteller>();
            storyteller.ShowMessage("ШТИРЛИЦ ЧУТЬ БЫЛО НЕ ПЕРЕПУТАЛ ДОКУМЕНТ И СРАЗУ ЖЕ РАСПУТАЛ ЕГО.");
            return;
        }

        papers.RemoveAt(currentIndex);
        papersID.RemoveAt(currentIndex);
        rightDocumentTaken?.Invoke();
        GameObject.FindGameObjectWithTag("Storyteller").GetComponent<Storyteller>().ShowMessagesSequence(
            "В дверь не постучали. Но Штирлиц отчетливо услышал шаги с улицы.".ToUpper(),
            "Гости - подумал Штирлиц.".ToUpper());
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
        if (currentIndex >= papers.Count - 1)
            return;
        
        currentIndex++;
        UpdatePaper();
    }

    private void UpdatePaper()
    {
        if (currentIndex >= papers.Count)
            currentIndex = papers.Count == 0 ? throw new Exception() : papers.Count - 1;
        currentPaper.sprite = papers[currentIndex];
    }
}
