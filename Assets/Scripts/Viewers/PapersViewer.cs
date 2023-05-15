using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PapersViewer : MonoBehaviour
{
    [SerializeField] private Image currentPaper;
    [SerializeField] private int currentIndex;
    
    [SerializeField] private List<Sprite> papers;

    private void Start()
    {
        currentPaper = gameObject.GetComponent<Image>();
        
        if (papers.Count > 0)
            currentPaper.sprite = papers[currentIndex];
    }

    public void TrySwitchLeft()
    {
        if (currentIndex > 0)
            currentIndex--;
        UpdatePaper();
    }

    public void TrySwitchRight()
    {
        if (currentIndex < papers.Count - 1)
            currentIndex++;
        UpdatePaper();
    }

    private void UpdatePaper()
    {
        currentPaper.sprite = papers[currentIndex];
    }
}
