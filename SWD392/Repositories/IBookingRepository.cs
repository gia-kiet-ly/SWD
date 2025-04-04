﻿using SWD392.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWD392.Repositories
{
    public interface IBookingRepository
    {
        Task<List<BookingDTO>> GetAvailableBookingsAsync(string doctorId);
        Task<bool> RequestAppointmentAsync(BookingRequestDTO request, string customerUsername);
        Task<List<BookingDTO>> GetCustomerAppointmentsAsync(string customerUsername);
        Task<bool> CancelAppointmentAsync(int bookingId, string customerUsername);
        Task<List<DoctorScheduleDTO>> GetDoctorScheduleAsync(string doctorId);
        Task<bool> CompleteAppointmentAsync(int bookingId, string doctorId, UpdateBookingDTO request);
        Task<bool> ConfirmAppointmentAsync(int bookingId);
        Task<bool> CancelAppointmentAsync(int bookingId);
        Task<bool> CustomerCancelAppointmentAsync(int bookingId);
        Task<List<DoctorDTO>> GetAllDoctorsAsync();

        Task<List<BookingDTO>> GetPendingAppointmentsAsync();
        Task<ResultBookingDTO> GetResultBookingAsync(int bookingId, string customerId);

        Task<bool> UpdateBookingDetailsAsync(int bookingId, string doctorId, UpdateBookingDTO request);

        Task<List<BookingDTO>> GetAllConfirmedAppointmentsAsync();
        Task CreateDoctorBookingsAsync(string doctorId, int numberOfDays = 7);

        Task<bool> HasScheduleForDateAsync(string doctorId, DateTime date);
        Task<bool> DeleteDoctorBookingsForDateAsync(string doctorId, DateTime date);

        Task<int> GetPendingBookingCountAsync();
        Task<int> GetConfirmedBookingCountAsync();
        Task<BookingFrequencyDTO> GetConfirmedBookingFrequencyByDayAsync(DateTime startDate, DateTime endDate);
        Task<BookingFrequencyDTO> GetConfirmedBookingFrequencyByWeekAsync(DateTime startDate, DateTime endDate);
        Task<BookingFrequencyDTO> GetConfirmedBookingFrequencyByMonthAsync(int year);

        Task<List<DoctorScheduleDTO>> SearchBookingByPhoneAsync(string phoneNumber);

    }
}
 