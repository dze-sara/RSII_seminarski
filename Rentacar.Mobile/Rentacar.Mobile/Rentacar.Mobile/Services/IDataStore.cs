﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.Mobile.Services
{
    public interface IDataStore<T>
    {
        DateTime BookingStartDate { get; set; }
        DateTime BookingEndDate { get; set; }

        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}