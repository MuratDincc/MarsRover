using MarsRover.Core.Constants;
using MarsRover.Core.Interfaces;
using System;

namespace MarsRover.Core
{
    public class Rover : IRover
    {
        #region Fields

        public IPlateau Plateau { get; set; }
        public IPosition Position { get; set; }
        public Direction Direction { get; set; }

        #endregion

        #region Ctor

        public Rover(IPlateau plateau, IPosition position, Direction direction)
        {
            this.Plateau = plateau;
            this.Position = position;
            this.Direction = direction;
        }

        #endregion

        #region Helper Methods

        private void Move()
        {
            if (Direction == Direction.N)
                Position.YCoordinate++;
            else if (Direction == Direction.E)
                Position.XCoordinate++;
            else if (Direction == Direction.S)
                Position.YCoordinate--;
            else if (Direction == Direction.W)
                Position.XCoordinate--;
        }

        private void Rotate(Commands directionCommand)
        {
            switch (directionCommand)
            {
                case Commands.Left:
                    this.TurnLeft();
                    break;

                case Commands.Right:
                    this.TurnRight();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Direction = Direction.W;
                    break;

                case Direction.W:
                    this.Direction = Direction.S;
                    break;

                case Direction.S:
                    this.Direction = Direction.E;
                    break;

                case Direction.E:
                    this.Direction = Direction.N;
                    break;
            }
        }

        private void TurnRight()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Direction = Direction.E;
                    break;

                case Direction.E:
                    this.Direction = Direction.S;
                    break;

                case Direction.S:
                    this.Direction = Direction.W;
                    break;

                case Direction.W:
                    this.Direction = Direction.N;
                    break;
            }
        }

        #endregion

        #region Methods

        public void Run(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", command));
                }
            }
        }

        public string Current()
        {
            return $"{Position.XCoordinate} {Position.YCoordinate} {Direction}";
        } 

        #endregion
    }
}