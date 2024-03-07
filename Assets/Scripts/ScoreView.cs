using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField0;
    [SerializeField] private TMP_Text _textField1;

    private void Awake()
    {
        SetScore(0,0);
        SetScore(1,0);
    }
    
    public void SetScore(int index, int score)
    {
        if(index == 1)
        {
             _textField0.text = $"{score}";
        }
        else if(index == 0)
        {
            _textField1.text = $"{score}";
        }
        
    }
}