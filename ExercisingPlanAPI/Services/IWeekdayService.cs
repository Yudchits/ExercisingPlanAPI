﻿using ExercisingPlanAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Services
{
    public interface IWeekdayService
    {
        Task<ICollection<Weekday>> GetAllWeekdaysAsync();
        Task<Weekday> GetWeekdayByIdAsync(int id);
        Task<bool> InsertWeekdayAsync(Weekday weekday);
        Task<bool> UpdateWeekdayAsync(Weekday weekday);
        Task<bool> DeleteWeekdayByIdAsync(int id);
        Task<bool> WeekdayIdExists(int id);
        Task<bool> WeekdayNameExists(string name);
    }
}
