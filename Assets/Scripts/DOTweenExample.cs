using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DOTweenExample : MonoBehaviour
{
    Image img;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform.DOMove();
        //transform.DOMoveX();
        //transform.DORotate();
        //transform.DOScale();


        // img.DOColor().SetLoops;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void dotweenExample()
    {
        Sequence seq = DOTween.Sequence(); // DOTween 시퀀스 = Tween 순서 설정
        seq.Append(transform.DOMove(new Vector3(1, 1), 3)); // Append = DOTween 추가 // x = 1, y = 1의 위치로 3초 만에 이동
        seq.Join(transform.DOScale(3, 1)); // Join = 동시 실행 하는 묶음 실행 // 스케일이 3만큼 1초 만에 증가
        seq.OnComplete(() => Debug.Log("두트윈 애니메이션 종료")); // 시퀀스가 완료되었을 때 호출하는 람다함수 
    }
}
