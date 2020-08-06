using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    float distanceTravelled;
    public bool updatestop = false;
    public int currentPathIndex = 0;
    public float fixRotationValue=-90;
    public bool ShouldChangeRotation = true;
    void Start()
    {

        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
        float t = distanceTravelled / pathCreator.path.length;
        currentPathIndex=  (int)t;
    }

    void Update()
    {
        //if (Player.Instance.gamestartdelay)
        //{
        //    if (Player.Instance._playerState == Player.playerState.die || Player.Instance._playerState == Player.playerState.finishline)
        //    {
        //        updatestop = true;
        //    }
        //    if (!updatestop)
        //    {
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            float t = distanceTravelled / pathCreator.path.length;
            var data = pathCreator.path.CalculatePercentOnPathData(t, endOfPathInstruction);
            transform.localRotation = Quaternion.Euler(0,-90,0);

            print("data t: " + (int)t);
            if (ShouldChangeRotation)
            {
                if ((int)t > currentPathIndex)
                {
                    ChangeRotation();
                    currentPathIndex = (int)t;

                }
            }
            print("data NextIndex: " + data.nextIndex);
            
        }
        //    }
        //}


    }
    public void ChangeRotation()
    {
        print("ChangeRotation Called");
        this.transform.localScale = new Vector3(1,1, -1 * transform.localScale.z);
    }

// If the path changes during the game, update the distance travelled so that the follower's position on the new path
// is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}
