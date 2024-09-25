using UnityEngine;

public class TurnOffAnim : MonoBehaviour
{
    private Animator animator;

    // �A�j���[�V�����̏�Ԃ��I�������o���邽�߂̃t���O
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
