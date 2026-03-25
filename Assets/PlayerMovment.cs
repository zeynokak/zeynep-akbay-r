using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -19.62f; // Yerçekimi
    public float jumpHeight = 3f; // Zýplama yüksekliði

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // Yere deðip deðmediðimizi kontrol ediyoruz
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Klavye hareket giriþleri (WASD / Ok tuþlarý)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Zýplama mekaniði
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Yerçekimi uygulamasý
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}