using UnityEngine;

public class seiretu : MonoBehaviour
{
    public GameObject[] objects;  // �z�u����I�u�W�F�N�g�̔z��
    public float radius;  // �~�̔��a
    public float yPosition;  // y���W
    public MoveNext moveNext;
    public float scale;
    public float y;
    public bool isHigh;

    void Start()
    {
        PlaceObjectsInCircle();
        moveNext.allObjects = objects.Length;
        if(isHigh)
        {
            this.transform.Rotate(0.0f, y, 0.0f);
        }
    }

    void PlaceObjectsInCircle()
    {
        int numObjects = objects.Length;
        float angleStep = 360f / numObjects;  // �e�I�u�W�F�N�g�̊Ԋu

        for (int i = 0; i < numObjects; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;  // ���W�A���ɕϊ�
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            Vector3 position = new Vector3(x, yPosition, z);  // y���W���܂ވʒu�x�N�g�����쐬
            objects[i].transform.position = position;  // �I�u�W�F�N�g�̈ʒu���X�V
            objects[i].transform.localScale = new Vector3(scale, scale, scale);
            // �~�̒��S����O���������悤�ɃI�u�W�F�N�g����]������
            Vector3 direction = position - transform.position;  // ���S����I�u�W�F�N�g�ւ̕������v�Z
            objects[i].transform.rotation = Quaternion.LookRotation(direction);  // ���̕����Ɍ�����
        }
    }
}
