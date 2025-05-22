using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPP_Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public sealed class HotelRoomManager
    { 
        private static volatile HotelRoomManager hotelRoomManager;
        private static object _lock = new object();

        private HotelRoomManager()
        {
            Console.WriteLine("Welcome to the Hotel Room Management System");
        }

        public static HotelRoomManager GetInstance()
        {
            if(hotelRoomManager == null)
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


    }

}
