using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBarks : MonoBehaviour
{
    [SerializeField]
    private string[] enemyBarks;
    [SerializeField]
    TMP_Text barkText;    
    int barkIntervals;
    public bool isBarking = false;

    public IEnumerator BarkOrder()
    {
        while(isBarking)
        {
            int rand = Random.Range(0, enemyBarks.Length);
            barkText.text = enemyBarks[rand];
            yield return new WaitForSeconds(barkIntervals = Random.Range(2, 7));            
        }

        NoSpeech();
        yield return null;
    }

    public void NoSpeech()
    {
        barkText.text = "";
    }
}
