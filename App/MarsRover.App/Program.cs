using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Core;
using MarsRover.Core.Constants;
using MarsRover.Core.Models;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var roadMapList = new List<RoadMap>();

            try
            {
                int counter = 1;

                while (true)
                {
                    try
                    {
                        #region Position

                        Console.WriteLine("Plateau Size :");

                        var readWidthHeight = Console.ReadLine();
                        var widthHeightSplit = readWidthHeight.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        int width = Convert.ToInt32(widthHeightSplit[0]);
                        int height = Convert.ToInt32(widthHeightSplit[1]);

                        #endregion

                        #region Location

                        Console.WriteLine("Enter Position:");

                        var position = Console.ReadLine();
                        var positionSplit = position.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        Direction direction = (Direction)Enum.Parse(typeof(Direction), positionSplit[2], true);

                        #endregion

                        #region Command

                        Console.WriteLine("Enter Command:");
                        var commands = Console.ReadLine();

                        #endregion

                        RoadMap roadMap = new RoadMap()
                        {
                            Width = width,
                            Height = height,
                            Position = new Position(Convert.ToInt32(positionSplit[0]), Convert.ToInt32(positionSplit[1])),
                            Direction = direction,
                            Command = commands
                        };

                        roadMapList.Add(roadMap);

                        Console.WriteLine("Do you want to add another rover ? (Y/N)");
                        var addRoverInput = Console.ReadLine();

                        if (!addRoverInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                            break;
                    }
                    catch (Exception innerEx)
                    {
                        Console.WriteLine($"Inner Ex: {innerEx.Message}");
                    }
                    finally
                    {
                        counter++;
                    }
                }

                if (roadMapList != null && roadMapList.Any())
                {
                    foreach (var item in roadMapList)
                    {
                        Plateau plateau = new Plateau(new Position(item.Width, item.Height));
                        Rover rover = new Rover(plateau, item.Position, item.Direction);

                        rover.Run(item.Command);
                        Console.WriteLine(rover.Current());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}