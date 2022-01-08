using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace BookingMobile
{
    public class DataBase
    {
        private readonly SQLiteAsyncConnection _database;
        public DataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Booking>();
        }
        public Task<List<Booking>> GetBookingsAsync()
        {
            return _database.Table<Booking>().ToListAsync();
        }
        public Task<int> SaveBookingAsync(Booking booking)
        {
            return _database.InsertAsync(booking);
        }
        public Task<int> RemoveBookingAsync(Booking booking)
        {
            return _database.DeleteAsync(booking);
        }
        public Task<int> UpdateBookingAsync(Booking booking)
        {
            return _database.UpdateAsync(booking);
        }
    }

}
