using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAPP_Assignment_2;

namespace IAPP_Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Enables bullet points in formatting

            HotelRoomManager manager = HotelRoomManager.GetInstance();

            Room room1 = new BasicRoom();
            Room room2 = new BasicRoom();
            Room room3 = new BasicRoom();
            room1 = new GamingRoom(room1);
            room1 = new StudyRoom(room1);
           

            
            room2 = new PartyRoom(room2);

            Console.WriteLine("===========================================================================================");
            Console.WriteLine();
            Console.WriteLine(room1.GetDescription());

         
            Console.WriteLine("===========================================================================================");
            Console.WriteLine();
            Console.WriteLine(room2.GetDescription());

            Console.ReadLine();
        }
    }

    public sealed class HotelRoomManager
    {
        private static volatile HotelRoomManager hotelRoomManager;
        private static object _lock = new object();

        private HotelRoomManager()
        {
            Console.WriteLine("Welcome to the Hotel Room Management System.");
        }

        public static HotelRoomManager GetInstance()
        {
            if (hotelRoomManager == null)
            {
                lock (_lock)
                {
                    if (hotelRoomManager == null)
                    {
                        hotelRoomManager = new HotelRoomManager();
                    }
                }
            }
            return hotelRoomManager;
        }
    }

    public abstract class Room
    {
        private static int roomCounter = 0;
        public int RoomNumber { get; protected set; }

        protected Room()
        {
            roomCounter++;
            RoomNumber = roomCounter;
        }

        protected Room(int currentRoomNumber)
        {
            RoomNumber = currentRoomNumber;
        }

        public virtual string GetDescription()
        {
            return $"Room {RoomNumber}: A basic room";
        }
    }

    public class BasicRoom : Room
    {
        public override string GetDescription()
        {
            return $"Room {RoomNumber}: Basic Room with standard features.";
        }
    }
}

// Decorator base class
public abstract class RoomDecorator : Room
{
    protected Room _room;

    public RoomDecorator(Room room) : base(room.RoomNumber)
    {
        _room = room;
    }

    public override string GetDescription()
    {
        return _room.GetDescription();
    }
}

// Concrete Decorator: PartyRoom
public class PartyRoom : RoomDecorator
{
    public PartyRoom(Room room) : base(room) { }

    public override string GetDescription()
    {
        string desc = _room.GetDescription();
        if (!desc.Contains("An upgraded room with the following features:"))
        {
            desc = $"Room {_room.RoomNumber}: An upgraded room with the following features:\n";
        }

        return desc + "\t• Party Setup (Disco lights, speakers, mini bar)\n";
    }
}

// Concrete Decorator: StudyRoom
public class StudyRoom : RoomDecorator
{
    public StudyRoom(Room room) : base(room) { }

    public override string GetDescription()
    {
        string desc = _room.GetDescription();
        if (!desc.Contains("An upgraded room with the following features:"))
        {
            desc = $"Room {_room.RoomNumber}: An upgraded room with the following features:\n";
        }

        return desc + "\t• Study Setup (Desk, bookshelf, quiet ambiance)\n";
    }
}

// Concrete Decorator: GamingRoom
public class GamingRoom : RoomDecorator
{
    public GamingRoom(Room room) : base(room) { }

    public override string GetDescription()
    {
        string desc = _room.GetDescription();
        if (!desc.Contains("An upgraded room with the following features:"))
        {
            desc = $"Room {_room.RoomNumber}: An upgraded room with the following features:\n";
        }

        return desc + "\t• Gaming Setup (Gaming PC, RGB lights, recliner chair)\n";
    }
}
