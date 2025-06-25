using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // �p�����[�^
    public Transform neck;                  // �v���C���[�̎��Transform���w��
    public float sensitivity = 2.0f;     // �}�E�X���x�i���_�̈ړ��̑����𒲐��j
    public float minVertical = -90.0f;   // ���_�̍ŏ��p�x�i�c�̉�]�����j
    public float maxVertical = 90.0f;    // ���_�̍ő�p�x�i�c�̉�]�����j

    // ���Z�p�ϐ�
    private float rotationX = 0f;       // �c�����̉�]�p�x�i��̉�]�j

    // �Q�[���J�n���ɌĂ΂��
    void Start()
    {
        // �J�[�\�����\�������b�N
        Cursor.lockState = CursorLockMode.Locked;   // �J�[�\������ʒ����ɌŒ�
        Cursor.visible = false;                     // �J�[�\�����\���ɂ���
    }

    // ���t���[�����s�����
    void Update()
    {
        // �}�E�X���͂̎擾
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;  // ���̃}�E�X�ړ��ʂ��擾���A���x�Œ���
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;  // �c�̃}�E�X�ړ��ʂ��擾���A���x�Œ���

        // Player�i�́j�̉�]�i���E�j
        transform.Rotate(0, mouseX, 0);   // �v���C���[�i�́j�̍��E�̉�]���}�E�XX�����̓��͂ɍ��킹�čs��

        // Neck�i��j�̉�]�i�㉺�j
        rotationX -= mouseY; // �}�E�XY�����̓��͂ɂ���ďc�����̉�]���X�V
        rotationX = Mathf.Clamp(rotationX, minVertical, maxVertical);   // ��]�p�x���w�肳�ꂽ�͈͂ɐ���
        neck.localRotation = Quaternion.Euler(rotationX, 0, 0);         // ��̉�]��ݒ�B�c�����̂݉�]������
    }
}
