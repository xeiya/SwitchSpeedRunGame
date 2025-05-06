using UnityEngine;

public class WallRunning : MonoBehaviour
{
    [Header("Wallrunning")]
    public LayerMask whatIsWall;
    public LayerMask whatIsGround;
    public float wallRunForce;
    public float wallJumpUpForce;
    public float wallJumpSideForce;
    public float maxWallRunTime;
    private float wallRunTimer;

    [Header("Input")]
    public KeyCode jumpKey = KeyCode.Space;
    private float horizontalInput;
    private float verticalInput;

    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallHit;
    private RaycastHit rightWallHit;
    private bool wallLeft;
    private bool wallRight;

    [Header("Exiting")]
    private bool exitingWall;
    public float exitWallTime;
    private float exitWallTimer;

    [Header("Gravity")]
    public bool useGravity;
    public float gravityCounterForce;

    [Header("Reference")]
    public Transform orientation;
    public PlayerCam cam;
    private PlayerMovement pm;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        CheckForWall();
        StateMachine();
    }

    private void FixedUpdate()
    {
        if (pm.wallrunning)
        {
            WallRunningMovement();
        }
    }

    private void CheckForWall() 
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallCheckDistance, whatIsWall);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallCheckDistance, whatIsWall);
    }

    private bool AboveGround() 
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatIsGround);
    }

    private void StateMachine() 
    {
        //Getting Inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //State 1 - Wallrunning
        if ((wallLeft || wallRight) && verticalInput > 0 && AboveGround() && !exitingWall)
        {
            if (!pm.wallrunning) { StartWallRun(); }

            //wallrun time
            if (wallRunTimer > 0) { wallRunTimer -= Time.deltaTime; }

            if (wallRunTimer <= 0 && pm.wallrunning) 
            { 
                exitingWall = true;
                exitWallTimer = exitWallTime;
            }

            //wall jump
            if (Input.GetKeyDown(jumpKey)) { WallJump(); }
        }

        //State 2 - Exiting
        else if (exitingWall) 
        {
            if (pm.wallrunning) { StopWallRun(); }

            if (exitWallTimer > 0) { exitWallTimer -= Time.deltaTime; }

            if (exitWallTimer < 0) { exitingWall = false; }
        }

        //State 3 - None
        else
        {
            if (pm.wallrunning) { StopWallRun(); }
        }
    }

    private void StartWallRun() 
    { 
        pm.wallrunning = true;

        wallRunTimer = maxWallRunTime;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //apply camera effects
        cam.DoFov(80f);
        if (wallLeft) { cam.DoTilt(-5f); }
        if (wallRight) { cam.DoTilt(5f); }
    }

    private void WallRunningMovement() 
    {
        rb.useGravity = useGravity;

        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

        if ((orientation.forward - wallForward).magnitude > (orientation.forward - -wallForward).magnitude) 
        { wallForward = -wallForward; }

        //forward force
        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

        //push to wall force
        if (!(wallLeft && horizontalInput > 0) && (wallRight && horizontalInput < 0))
        { rb.AddForce(-wallNormal * 100, ForceMode.Force); }

        //weaken gravity
        if (useGravity) { rb.AddForce(transform.up * gravityCounterForce, ForceMode.Force); }
    }

    private void StopWallRun() 
    {
        pm.wallrunning = false;

        //reset camera effects
        cam.DoFov(70f);
        cam.DoTilt(0f);
    }

    private void WallJump() 
    {
        //enter exiting wall state
        exitingWall = true;
        exitWallTimer = exitWallTime;

        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

        //add force
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);
    }
}
