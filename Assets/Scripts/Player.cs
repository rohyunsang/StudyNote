using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator _anim;

    public void Init()
    {
        // 3초마다 랜덤으로 애니메이션 트리거를 실행
        StartCoroutine(PlayRandomAnimation());
    }

    public void Update()
    {
        if (GameManager.instance.state != GameManager.State.Run)
        {
            _anim.SetTrigger("Stop");
        }
    }

    IEnumerator PlayRandomAnimation()
    {
        while (true)
        {
            if (GameManager.instance.state == GameManager.State.Run)
            {
                int randomAnim = Random.Range(0, 3);

                switch (randomAnim)
                {
                    case 0:
                        _anim.SetTrigger("Idle");
                        break;
                    case 1:
                        _anim.SetTrigger("Jump");
                        break;
                    case 2:
                        _anim.SetTrigger("Run");
                        break;
                }
            }

            // 3초 대기
            yield return new WaitForSeconds(3f);
        }
    }
}