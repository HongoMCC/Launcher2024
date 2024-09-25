using UnityEngine;

public class TurnOffAnim : MonoBehaviour
{
    private Animator animator;

    // アニメーションの状態が終了を検出するためのフラグ
    private bool isAnimationEnded;
    public GameObject[] offObjects;
    public MoveNext moveNext;
    void Start()
    {
        animator = GetComponent<Animator>();
        isAnimationEnded = false;
        foreach (GameObject obj in offObjects) 
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        if (animator)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1 && !isAnimationEnded)
            {
                isAnimationEnded = true;
                animator.enabled = false;
                foreach (GameObject obj in offObjects)
                {
                    obj.SetActive(true);
                }
                moveNext.isCoolTime= true;
            }
        }
    }
}
