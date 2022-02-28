using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    public class Path : IdentifiableObject
    {
        Location _destination;
        public Path(string[] idents,Location destination) : base(idents)
        {
            _destination = destination;
        }

        public string CheckPlayerLocation(Player p)
        {
            //if the player lands on the destination
            if (p.X == _destination.X && p.Y == _destination.Y)
            {
                p.EnterLocation(_destination);
                return "\nYou have arrived at " + FirstId;
            }

            //if the player lands on no location
            if (p.Location != null)
            {
                if (p.X != p.Location.X || p.Y != p.Location.Y)
                {
                    p.LeaveLocation();
                    return "\nYou have left " + p.LocationHistory[p.LocationHistory.Count - 1].FirstId;
                }
            }
            
            return TestRemainingDistance(p);
        }

        public void UpdatePlayerPosition(Player p, int dis, Direction dir)
        {
            p.X += Convert.ToSingle(Math.Floor(dis * Math.Cos(dir.Angle)));
            p.Y += Convert.ToSingle(Math.Floor(dis * Math.Sin(dir.Angle)));
        }

        public string TestRemainingDistance(Player p)
        {
            return "\nHogwarts is at (" + _destination.X + "," + _destination.Y + "). You are " + CalculateRemainingSteps(p) + " steps away from reaching your destination.";
        }

        public double CalculateRemainingSteps(Player p)
        {
            return Math.Floor(Math.Sqrt(Math.Pow(_destination.X - p.X,2) + Math.Pow(_destination.Y - p.Y,2)));
        }

        public void MovePlayerToDestination(Player p)
        {
            p.X = _destination.X;
            p.Y = _destination.Y;
            p.EnterLocation(_destination);
        }
    }
}
