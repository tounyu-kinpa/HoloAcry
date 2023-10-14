using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public GameObject PlayUI;

    // 振動を検知するための閾値
    private float Threshold = 0.5f;
    // 前回の加速度データ
    private Vector3 lastAccel;
    // ローパスフィルタがかかった加速度データ
    private Vector3 smoothedAccel;

    // ローパスフィルタの係数
    float lowPassFilterFactor = 0.8f;

    void Start()
    {
        // 加速度の初期データの取得
        lastAccel = Input.acceleration;
    }

    void Update()
    {
        if (PlayUI.activeSelf)
        {
            // 加速度の取得
            Vector3 currentAccel = Input.acceleration;

            // ローパスフィルタを適用
            smoothedAccel = Vector3.Lerp(smoothedAccel, currentAccel, lowPassFilterFactor);

            // 加速度の変化が閾値を超えたかチェック
            Vector3 deltaAccel = currentAccel - lastAccel;

            if (Mathf.Abs(deltaAccel.x) > Threshold ||
                Mathf.Abs(deltaAccel.y) > Threshold ||
                Mathf.Abs(deltaAccel.z) > Threshold)
            {
                // 振動を検知した場合の処理
                HandleShakeEvent();
            }

            lastAccel = currentAccel;
        }
    }

    private void HandleShakeEvent()
    {
        // 端末が振られた時に行いたい処理をここに実装
        Whether_Mode.Start();
    }
}
