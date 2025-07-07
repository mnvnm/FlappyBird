using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDlg : MonoBehaviour
{
    [SerializeField] GameObject gameoverImg;
    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
        if(isShow) gameoverImg.transform.DOPunchScale(new Vector3(1.25f, 1.25f, 1.25f), 1f, 8);
    }
    void Start()
    {
        
    }

    public void Init()
    {
        Show(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
