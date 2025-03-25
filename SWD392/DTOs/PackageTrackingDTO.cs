﻿namespace SWD392.DTOs
{
    public class PackageTrackingDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string PackageName { get; set; }
        public string DoctorName { get; set; }
        public string DoctorAvatar { get; set; }
        public string DoctorPhone { get; set; }
    }

}
