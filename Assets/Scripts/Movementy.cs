using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementy : MonoBehaviour
{
	public float mouseSensitivityX = 1.0f;
	public float mouseSensitivityY = 1.0f;
	public float range,jumps = 0;

	public float walkSpeed = 10.0f;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;

	Transform cameraT;
	float verticalLookRotation, B=0;

	public static int gun = 2;

	public GameObject pistol;
	public GameObject crowbar, primary, awp, ar , smg, shoot, smoke;
	public GameObject fpsCamera, buyMenu;

	public static bool isUsingGun;
	public static bool isUsingCrowbar;

	Rigidbody rigidbodyR;

	float jumpForce = 250.0f;
	bool grounded;
	public LayerMask groundedMask;

	bool cursorVisible;

	// Use this for initialization
	void Start()
	{
		cameraT = Camera.main.transform;
		rigidbodyR = GetComponent<Rigidbody>();
		LockMouse();
		buyMenu.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			buyMenu.SetActive(true);
			Time.timeScale = 0f;
			UnlockMouse();
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			buyMenu.SetActive(false);
			Time.timeScale = 1f;
			LockMouse();
		}

		// rotation
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
		cameraT.localEulerAngles = Vector3.left * verticalLookRotation;

		// movement
		Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

		// jump
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded || jumps >= 1)
			{
				rigidbodyR.AddForce(transform.up * jumpForce);
				jumps--;
			}
		}

		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}

		/* Lock/unlock mouse on click 
		if (Input.GetMouseButtonUp(0))
		{
			if (!cursorVisible)
			{
				UnlockMouse();
			}
			else
			{
				LockMouse();
			}
		}
		*/

		//sprint

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount * 100, ref smoothMoveVelocity, .15f);
		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			smoke.SetActive(true);
			crowbar.SetActive(false);
			pistol.SetActive(false);
			awp.SetActive(false);
			ar.SetActive(false);
			smg.SetActive(false);
			shoot.SetActive(false);
			isUsingGun = false;
			isUsingCrowbar = false;
			walkSpeed = 10;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			crowbar.SetActive(true);
			smoke.SetActive(false);
			pistol.SetActive(false);
			awp.SetActive(false);
			ar.SetActive(false);
			smg.SetActive(false);
			shoot.SetActive(false);
			isUsingGun = false;
			isUsingCrowbar = true;
			walkSpeed = 10;

		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			crowbar.SetActive(false);
			smoke.SetActive(false);
			pistol.SetActive(true);
			awp.SetActive(false);
			ar.SetActive(false);
			smg.SetActive(false);
			shoot.SetActive(false);
			isUsingGun = true;
			isUsingCrowbar = false;
			walkSpeed = 8;

		}
		else if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			crowbar.SetActive(false);
			smoke.SetActive(false);
			pistol.SetActive(false);
			if (gun == 0)
			{
				awp.SetActive(true);
				ar.SetActive(false);
				smg.SetActive(false);
				shoot.SetActive(false);
			}
			else if (gun == 1)
			{
				awp.SetActive(false);
				ar.SetActive(true);
				smg.SetActive(false);
				shoot.SetActive(false);
			}
			else if (gun == 2)
			{
				awp.SetActive(false);
				ar.SetActive(false);
				smg.SetActive(true);
				shoot.SetActive(false);

			}
			else
			{
				awp.SetActive(false);
				ar.SetActive(false);
				smg.SetActive(false);
				shoot.SetActive(true);
			}
			walkSpeed = 6;
		}

			////

			RaycastHit hitInfo;
		if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hitInfo, range))
		{

			Door target = hitInfo.transform.GetComponent<Door>();

			if (hitInfo.collider.tag == "Door" && Input.GetKeyDown(KeyCode.E))
			{
				target.Open();

			}

		}

	}
	void FixedUpdate()
	{
		rigidbodyR.MovePosition(rigidbodyR.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
	}

	void UnlockMouse()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		cursorVisible = true;
	}

	void LockMouse()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cursorVisible = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (jumps < 1)
		{
			jumps++;
		}

	}
}
