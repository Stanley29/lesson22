﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject.Commands
{
    internal class AddMeeting : ICommand
    {
        public string Name { get; set; }
        public string Description { get;  set; }
        public string Mnemonic { get; set; }
        public List<Room> Data { get; set; }

        public AddMeeting(string name, string description, string mnemonic, List<Room> data)
        {
            Name = name;
            Description = description;
            Mnemonic = mnemonic;
            Data = data;
        }
        public bool Execute()
        {
            Console.WriteLine("Existing rooms list:");
            ShowExistingRoom();
            Console.WriteLine("Select and enter room number");
            if (!CheckRoom(int.Parse(Console.ReadLine()), out Room room))
            {
                Console.WriteLine("room not finded");
                return true;
            }
            Console.WriteLine("Enter date and time meeting");
            var startDate = Console.ReadLine();
            Console.WriteLine("Enter duration if meeting");
            var duration = Console.ReadLine();
            Console.WriteLine("Enter organizer lastname");
            var organizer = Console.ReadLine();
            Console.WriteLine("Enter meeting topic");
            var topic = Console.ReadLine();
            var meetingId = room.Meetings.Count == 0? 0: room.Meetings.Max(m => m.Id) + 1;
            room.Meetings.Add(new Meeting(meetingId, startDate, duration, organizer, topic));
            return true;
        }

        private void ShowExistingRoom()
        {
            foreach (var item in Data)
            {
                Console.WriteLine(item.Number);
            }
        }

        private bool CheckRoom(int roomNumber, out Room room)
        {
            room = Data.Where(r => r.Number == roomNumber).FirstOrDefault();
            return room != null;
        }
    }
}
