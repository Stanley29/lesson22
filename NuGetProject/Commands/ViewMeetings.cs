﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject.Commands
{
    internal class ViewMeetings : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Mnemonic { get; set; }
        public List<Room> Data { get; set; }

        public ViewMeetings(string name, string description, string mnemonic, List<Room> rooms)
        {
            Name = name;
            Description = description;
            Mnemonic = mnemonic;
            Data = rooms;
        }
        public bool Execute()
        {
            foreach (var room in Data)
            {
                Console.WriteLine($"Meetings for {room.Number} room");
                foreach (var meeting in room.Meetings)
                {
                    Console.WriteLine($"\t{meeting.StartTime} {meeting.Duration} {meeting.Organizer} {meeting.Organizer}");
                }
            }
            return true;
        }
    }
}
