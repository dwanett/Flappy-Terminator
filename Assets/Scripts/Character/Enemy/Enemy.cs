using System.Collections.Generic;

public class Enemy : Character
{
    public List<PatrollingWayPoint> PointsPatrollingWay { get; private set; }
    
    public void ReplacePatrollingWay(List<PatrollingWayPoint> pointsPatrollingWay)
    {
        PointsPatrollingWay = pointsPatrollingWay;
    }
}
