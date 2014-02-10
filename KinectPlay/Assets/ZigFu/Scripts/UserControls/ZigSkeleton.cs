using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ZigSkeleton : MonoBehaviour
{
    public Transform Head;
    public Transform Neck;
    public Transform Torso;
    public Transform Waist;

    public Transform LeftCollar;
    public Transform LeftShoulder;
    public Transform LeftElbow;
    public Transform LeftWrist;
    public Transform LeftHand;
    public Transform LeftFingertip;

    public Transform RightCollar;
    public Transform RightShoulder;
    public Transform RightElbow;
    public Transform RightWrist;
    public Transform RightHand;
    public Transform RightFingertip;

    public Transform LeftHip;
    public Transform LeftKnee;
    public Transform LeftAnkle;
    public Transform LeftFoot;

    public Transform RightHip;
    public Transform RightKnee;
    public Transform RightAnkle;
    public Transform RightFoot;
    static public bool mirror = false;
    public bool UpdateJointPositions = false;
    public bool UpdateRootPosition = false;
    public bool UpdateOrientation = true;
    public bool RotateToPsiPose = false;
    public float RotationDamping = 30.0f;
    public float Damping = 30.0f;
	public float[] filter = new float[100];
    public Vector3 Scale = new Vector3(0.001f, 0.001f, 0.001f);

    public Vector3 PositionBias = Vector3.zero;

	public GUIText angles;

    private Transform[] transforms;
    private Quaternion[] initialRotations;
    private Vector3 rootPosition;

	// Return opposite joint of that given
    ZigJointId mirrorJoint(ZigJointId joint)
    {
        switch (joint)
        {
            case ZigJointId.LeftCollar:
                return ZigJointId.RightCollar;
            case ZigJointId.LeftShoulder:
                return ZigJointId.RightShoulder;
            case ZigJointId.LeftElbow:
                return ZigJointId.RightElbow;
            case ZigJointId.LeftWrist:
                return ZigJointId.RightWrist;
            case ZigJointId.LeftHand:
                return ZigJointId.RightHand;
            case ZigJointId.LeftFingertip:
                return ZigJointId.RightFingertip;
            case ZigJointId.LeftHip:
                return ZigJointId.RightHip;
            case ZigJointId.LeftKnee:
                return ZigJointId.RightKnee;
            case ZigJointId.LeftAnkle:
                return ZigJointId.RightAnkle;
            case ZigJointId.LeftFoot:
                return ZigJointId.RightFoot;

            case ZigJointId.RightCollar:
                return ZigJointId.LeftCollar;
            case ZigJointId.RightShoulder:
                return ZigJointId.LeftShoulder;
            case ZigJointId.RightElbow:
                return ZigJointId.LeftElbow;
            case ZigJointId.RightWrist:
                return ZigJointId.LeftWrist;
            case ZigJointId.RightHand:
                return ZigJointId.LeftHand;
            case ZigJointId.RightFingertip:
                return ZigJointId.LeftFingertip;
            case ZigJointId.RightHip:
                return ZigJointId.LeftHip;
            case ZigJointId.RightKnee:
                return ZigJointId.LeftKnee;
            case ZigJointId.RightAnkle:
                return ZigJointId.LeftAnkle;
            case ZigJointId.RightFoot:
                return ZigJointId.LeftFoot;


            default:
                return joint;
        }
    }


    public void Awake()
    {
        int jointCount = Enum.GetNames(typeof(ZigJointId)).Length;

		// Initialize list of our joint transforms
        transforms = new Transform[jointCount];
        initialRotations = new Quaternion[jointCount];

        transforms[(int)ZigJointId.Head] = Head;
        transforms[(int)ZigJointId.Neck] = Neck;
        transforms[(int)ZigJointId.Torso] = Torso;
        transforms[(int)ZigJointId.Waist] = Waist;
        transforms[(int)ZigJointId.LeftCollar] = LeftCollar;
        transforms[(int)ZigJointId.LeftShoulder] = LeftShoulder;
        transforms[(int)ZigJointId.LeftElbow] = LeftElbow;
        transforms[(int)ZigJointId.LeftWrist] = LeftWrist;
        transforms[(int)ZigJointId.LeftHand] = LeftHand;
        transforms[(int)ZigJointId.LeftFingertip] = LeftFingertip;
        transforms[(int)ZigJointId.RightCollar] = RightCollar;
        transforms[(int)ZigJointId.RightShoulder] = RightShoulder;
        transforms[(int)ZigJointId.RightElbow] = RightElbow;
        transforms[(int)ZigJointId.RightWrist] = RightWrist;
        transforms[(int)ZigJointId.RightHand] = RightHand;
        transforms[(int)ZigJointId.RightFingertip] = RightFingertip;
        transforms[(int)ZigJointId.LeftHip] = LeftHip;
        transforms[(int)ZigJointId.LeftKnee] = LeftKnee;
        transforms[(int)ZigJointId.LeftAnkle] = LeftAnkle;
        transforms[(int)ZigJointId.LeftFoot] = LeftFoot;
        transforms[(int)ZigJointId.RightHip] = RightHip;
        transforms[(int)ZigJointId.RightKnee] = RightKnee;
        transforms[(int)ZigJointId.RightAnkle] = RightAnkle;
        transforms[(int)ZigJointId.RightFoot] = RightFoot;



        // save all initial rotations
        // NOTE: Assumes skeleton model is in "T" pose since all rotations are relative to that pose
        foreach (ZigJointId j in Enum.GetValues(typeof(ZigJointId)))
        {
            if (transforms[(int)j])
            {
                // we will store the relative rotation of each joint from the gameobject rotation
                // we need this since we will be setting the joint's rotation (not localRotation) but we 
                // still want the rotations to be relative to our game object
                initialRotations[(int)j] = Quaternion.Inverse(transform.rotation) * transforms[(int)j].rotation;
            }
        }
    }

    void Start()
    {
		Debug.Log ("Start");
        // start out in calibration pose
        if (RotateToPsiPose)
        {
            RotateToCalibrationPose();
        }
		angles.text = "This nowwwww";
    }

    void UpdateRoot(Vector3 skelRoot)
    {
        // +Z is backwards in OpenNI coordinates, so reverse it
        rootPosition = Vector3.Scale(new Vector3(skelRoot.x, skelRoot.y, skelRoot.z), doMirror(Scale)) + PositionBias;
        if (UpdateRootPosition)
        {
            transform.localPosition = (transform.rotation * rootPosition);
        }
    }

    void UpdateRotation(ZigJointId joint, Quaternion orientation)

    {
        joint = mirror ? mirrorJoint(joint) : joint;
        // make sure something is hooked up to this joint
        if (!transforms[(int)joint])
        {
            return;
        }

        if (UpdateOrientation)
        {
            Quaternion newRotation = transform.rotation * orientation * initialRotations[(int)joint];
            if (mirror)
            {
                newRotation.y = -newRotation.y;
                newRotation.z = -newRotation.z;
            }
            transforms[(int)joint].rotation = Quaternion.Slerp(transforms[(int)joint].rotation, newRotation, Time.deltaTime * RotationDamping);
        }
    }
    Vector3 doMirror(Vector3 vec)
    {
        return new Vector3(mirror ? -vec.x : vec.x, vec.y, vec.z);
    }

	float[] shiftArray(float[] array, float newValue = 0.0f)
	{
		/* Shift the contents of an array ultimately removing the final index.  Also set the 0 index to 0.0f.
		 * @param newValue: Float value to be inserted into the first index of the new array
		 */
		int length = array.Length;
		float[] shifted = new float[length];
		shifted[0] = newValue;
		for (int i = 1; i < length; i++) {
			shifted[i] = array[i - 1];
		}
		return shifted;
	}

	void UpdateElbowPercentage()
	{
		double percentRange;
		float RightElbow_x = RightElbow.localPosition.x;
		float RightElbow_y = RightElbow.localPosition.y;
		float RightShoulder_x = RightShoulder.localPosition.x;
		float RightShoulder_y = RightShoulder.localPosition.y;
		// If elbow is higher than the shoulder
		bool raised = RightElbow_y > RightShoulder_y;

		// Calculate distance from shoulder to elbow. Add 10 as to avoid negative numbers.  This will serve as our range
		double upperArmLength = Math.Sqrt(Math.Pow(((RightElbow_x) - (RightShoulder_x)), 2.0f) + Math.Pow(((RightElbow_y) - (RightShoulder_y)), 2.0f));

		// Difference between
		float diff_x = Math.Abs(RightElbow_x - RightShoulder_x);


		percentRange = (diff_x / upperArmLength) * 100;
		percentRange = percentRange / 2;
		if (raised == true){ 
			percentRange = (Math.Abs(percentRange - 100) + 50) / 2;
		}

		//filter = shiftArray(filter, newValue: (float)percentRange);

		// Set font size
		angles.fontSize = 18;
		// Print Right elbow readings to gui
		angles.text = "RightElbow:\n" +
			"Pos.x: " + RightElbow_x.ToString() +
			"\nPos.y: " + RightElbow_y.ToString() +
			"\nRightShoulder:\n" +
			"Pos.x: " + RightShoulder_x.ToString() +
			"\nPos.y: " + RightShoulder_y.ToString()+
			"\nRaised: " + raised.ToString() +
			"\nLength: " + upperArmLength.ToString() +
			"\nDiff: " + diff_x.ToString() +
			"\nPercentRange: " + percentRange.ToString();
	}

    void UpdatePosition(ZigJointId joint, Vector3 position)
    {
		Debug.Log ("UpdatePosition");
        joint = mirror ? mirrorJoint(joint) : joint;
        // make sure something is hooked up to this joint
        if (!transforms[(int)joint])
        {
            return;
        }

        if (UpdateJointPositions)
        {
            Vector3 dest = Vector3.Scale(position, doMirror(Scale)) - rootPosition;
            transforms[(int)joint].localPosition = Vector3.Lerp(transforms[(int)joint].localPosition, dest, Time.deltaTime * Damping);

			UpdateElbowPercentage();
        }
    }

    public void RotateToCalibrationPose()
    {
        foreach (ZigJointId j in Enum.GetValues(typeof(ZigJointId)))
        {
            if (null != transforms[(int)j])
            {
                transforms[(int)j].rotation = transform.rotation * initialRotations[(int)j];
            }
        }

        // calibration pose is skeleton base pose ("T") with both elbows bent in 90 degrees
        if (null != RightElbow)
        {
            RightElbow.rotation = transform.rotation * Quaternion.Euler(0, -90, 90) * initialRotations[(int)ZigJointId.RightElbow];
        }
        if (null != LeftElbow)
        {
            LeftElbow.rotation = transform.rotation * Quaternion.Euler(0, 90, -90) * initialRotations[(int)ZigJointId.LeftElbow];
        }
    }

    public void SetRootPositionBias()
    {
        this.PositionBias = -rootPosition;
    }

    public void SetRootPositionBias(Vector3 bias)
    {
        this.PositionBias = bias;
    }

    void Zig_UpdateUser(ZigTrackedUser user)
    {
		Debug.Log ("Zig_UpdateUser");
        UpdateRoot(user.Position);
        if (user.SkeletonTracked)
        {
            foreach (ZigInputJoint joint in user.Skeleton)
            {
                if (joint.GoodPosition) UpdatePosition(joint.Id, joint.Position);
                if (joint.GoodRotation) UpdateRotation(joint.Id, joint.Rotation);
            }
        }
    }

}
