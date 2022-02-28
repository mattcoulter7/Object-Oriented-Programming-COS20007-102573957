using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Path : IdentifiableObject
    {
        Location _destination;

        public Location Destination { get => _destination; set => _destination = value; }

        public Path(string[] idents,Location destination) : base(idents)
        {
            _destination = destination;
        }

        public string CheckPlayerLocation(Player p)
        {
            //if the player lands on the destination
            if (p.X == _destination.X && p.Y == _destination.Y)
            {
                return p.EnterLocation(_destination);
            }

            //if the player lands on no location
            if (p.Location != null)
            {
                if (p.X != p.Location.X || p.Y != p.Location.Y)
                {
                    p.LeaveLocation();
                    return "\nYou have left " + p.Objectives[p.Objectives.IndexOf(p.Path) - 1].Destination.Name;
                    
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
            return Destination.Name + " is at (" + _destination.X + "," + _destination.Y + "). \nYou are " + CalculateRemainingSteps(p) + " steps away.";
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
