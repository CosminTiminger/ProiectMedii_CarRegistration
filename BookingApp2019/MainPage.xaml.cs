using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace BookingApp2019
{
    public partial class MainPage : ContentPage
    {
        private Booking selectedBooking;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            bookings_container.ItemsSource = await App.Database.GetBookingsAsync();
        }

        private async void Add_Button_Clicked(Object sender, EventArgs e)
        {
            if (booking_details_view.IsVisible)
            {

                string nationalId = national_id_field.Text;
                string fullName = name_field.Text;
                string location = location_field.Text;
                string phoneNumber = phone_number_field.Text;
                string email = email_field.Text;
                string date = date_field.Text;

                if (!string.IsNullOrWhiteSpace(nationalId) &&
                    !string.IsNullOrWhiteSpace(fullName) &&
                    !string.IsNullOrWhiteSpace(location) &&
                    !string.IsNullOrWhiteSpace(phoneNumber) &&
                    !string.IsNullOrWhiteSpace(email) &&
                    !string.IsNullOrWhiteSpace(date))
                {
                    Booking booking = new Booking
                    {
                        NationalId = nationalId,
                        FullName = fullName,
                        Location = location,
                        PhoneNumber = phoneNumber,
                        Email = email,
                        BookingDate = date
                    };
                    await App.Database.SaveBookingAsync(booking);
                }

                OnListState();
            }
            else
            {
                OnAddState();
            }
        }

        private async void Delete_Button_Clicked(Object sender, EventArgs e)
        {
            await App.Database.RemoveBookingAsync(selectedBooking);
            OnListState();
        }

        private async void Update_Button_Clicked(Object sender, EventArgs e)
        {
            string nationalId = national_id_field.Text;
            string fullName = name_field.Text;
            string location = location_field.Text;
            string phoneNumber = phone_number_field.Text;
            string email = email_field.Text;
            string date = date_field.Text;

            if (!string.IsNullOrWhiteSpace(nationalId) &&
                    !string.IsNullOrWhiteSpace(fullName) &&
                    !string.IsNullOrWhiteSpace(location) &&
                    !string.IsNullOrWhiteSpace(phoneNumber) &&
                    !string.IsNullOrWhiteSpace(email) &&
                    !string.IsNullOrWhiteSpace(date))
            {
                selectedBooking.NationalId = nationalId;
                selectedBooking.FullName = fullName;
                selectedBooking.Location = location;
                selectedBooking.PhoneNumber = phoneNumber;
                selectedBooking.Email = email;
                selectedBooking.BookingDate = date;

                await App.Database.UpdateBookingAsync(selectedBooking);
            }

            OnListState();
        }

        private void Done_Button_Clicked(Object sender, EventArgs e)
        {
            OnListState();
            ClearFields();
        }

        private void bookings_container_ItemTapped(
            Object sender,
            ItemTappedEventArgs e)
        {
            selectedBooking = ((Booking)e.Item);
            DisplayBookingDetails(selectedBooking);
        }

        private void DisplayBookingDetails(Booking booking)
        {
            OnDetailsState();

            national_id_field.Text = booking.NationalId;
            name_field.Text = booking.FullName;
            location_field.Text = booking.Location;
            phone_number_field.Text = booking.PhoneNumber;
            email_field.Text = booking.Email;
            date_field.Text = booking.BookingDate;
        }

        private async void OnListState()
        {
            bookings_container.ItemsSource = await App.Database.GetBookingsAsync();

            booking_details_view.IsVisible = false;
            bookings_container.IsVisible = true;
            add_button.IsVisible = true;
            delete_button.IsVisible = false;
            update_button.IsVisible = false;
            done_button.IsVisible = false;

            ClearFields();
        }

        private void OnDetailsState()
        {
            booking_details_view.IsVisible = true;
            bookings_container.IsVisible = false;
            add_button.IsVisible = false;
            delete_button.IsVisible = true;
            update_button.IsVisible = true;
            done_button.IsVisible = true;
        }

        private void OnAddState()
        {
            bookings_container.IsVisible = false;
            booking_details_view.IsVisible = true;
            done_button.IsVisible = true;
        }

        private void ClearFields()
        {
            national_id_field.Text = string.Empty;
            name_field.Text = string.Empty;
            location_field.Text = string.Empty;
            phone_number_field.Text = string.Empty;
            email_field.Text = string.Empty;
            date_field.Text = string.Empty;
        }
    }

}
