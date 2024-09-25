using UnityEngine;

public class seiretu : MonoBehaviour
{
    public GameObject[] objects;  // 配置するオブジェクトの配列
    public float radius;  // 円の半径
    public float yPosition;  // y座標
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
        float angleStep = 360f / numObjects;  // 各オブジェクトの間隔

        for (int i = 0; i < numObjects; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;  // ラジアンに変換
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            Vector3 position = new Vector3(x, yPosition, z);  // y座標を含む位置ベクトルを作成
            objects[i].transform.position = position;  // オブジェクトの位置を更新
            objects[i].transform.localScale = new Vector3(scale, scale, scale);
            // 円の中心から外側を向くようにオブジェクトを回転させる
            Vector3 direction = position - transform.position;  // 中心からオブジェクトへの方向を計算
            objects[i].transform.rotation = Quaternion.LookRotation(direction);  // その方向に向ける
        }
    }
}
