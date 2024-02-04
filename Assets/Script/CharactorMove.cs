using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    //移動速度
    [SerializeField] private float _movePower = 3;

    //キャラクターの移動方向を表すベクトル
    private Vector3 _dir;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Vector3 velo = _rb.velocity;
        velo.y = 0;
    }

    void Move()
    {
        //水平方向と垂直方向を取得
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        //入力方向を計算しカメラの向きを合わせる
        _dir = Vector3.forward * v + Vector3.right * h;
        _dir = Camera.main.transform.TransformDirection(_dir);
        //上下方向の無効
        _dir.y = 0;
        //移動方向を正規化
        Vector3 forward = _dir.normalized;
        _rb.velocity = forward * _movePower;
        forward.y = 0;
        //キャラクターの向きを移動方向に合わせる
        if (forward != Vector3.zero)
        {
            this.transform.forward = forward;
        }
    }
}