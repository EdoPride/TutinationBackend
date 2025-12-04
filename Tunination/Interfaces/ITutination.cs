namespace Tunination;

public interface ITutination
{

//user
   public Task<IEnumerable<UsersDao?>> GetAllAsync();
    public Task<UsersDao?> GetByIdAsync(int id);
    public Task<int> AddAsync(UsersDao entity);
    public Task<bool> UpdateAsync(UsersDao entity);
    public Task<bool> DeleteAsync(int id);

    public Task<UsersDao?> GetByEmailAsync(string email);
    public Task<bool> CheckEmailExistsAsync(string email);


//event
    public Task<IEnumerable<EventsDao?>> GetAllEventsAsync();
    public Task<EventsDao?> GetEventByIdAsync(int id);
    public Task<int> AddEventAsync(EventsDao entity);
    public Task<bool> UpdateEventAsync(EventsDao entity);
    public Task<bool> DeleteEventAsync(int id);


//tickets
    public Task<IEnumerable<TicketsDao?>> GetAllTicketsAsync();
    public Task<TicketsDao?> GetTicketByIdAsync(int id);
    public Task<int> AddTicketAsync(TicketsDao entity);
    public Task<bool> UpdateTicketAsync(TicketsDao entity);
    public Task<bool> DeleteTicketAsync(int id);
    public Task<IEnumerable<TicketsDao?>> GetTicketsByUserAsync(int userId);
    public Task<IEnumerable<TicketsDao?>> GetTicketsByEventAsync(int eventId);
    //services
    public Task<IEnumerable<ServicesDao?>> GetAllServicesAsync();
    public Task<ServicesDao?> GetServiceByIdAsync(int id);
    public Task<int> AddServiceAsync(ServicesDao entity);
    public Task<bool> UpdateServiceAsync(ServicesDao entity);
    public Task<bool> DeleteServiceAsync(int id);

//apppointments
    public Task<IEnumerable<AppointmentsDao?>> GetAllAppointmentsAsync();
    public Task<AppointmentsDao?> GetAppointmentByIdAsync(int id);
    public Task<int> AddAppointmentAsync(AppointmentsDao entity);
    public Task<bool> UpdateAppointmentAsync(AppointmentsDao entity);
    public Task<bool> DeleteAppointmentAsync(int id);
    public Task<IEnumerable<PaymentsDao?>> GetPaymentsByUserAsync(int userId);
//payments
    public Task<IEnumerable<PaymentsDao?>> GetAllPaymentsAsync();
    public Task<PaymentsDao?> GetPaymentByIdAsync(int id);
    public Task<int> AddPaymentAsync(PaymentsDao entity);
    public Task<bool> UpdatePaymentAsync(PaymentsDao entity);
    public Task<bool> DeletePaymentAsync(int id);
    public Task<PaymentsDao?> GetPaymentByReferenceAsync(string referenceId);

//PaymentTicket
   public Task LinkPaymentToTicketAsync(int paymentId, int ticketId);
   //payment appointment
    public Task LinkPaymentToAppointmentAsync(int paymentId, int appointmentId);

}
