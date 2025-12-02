namespace Tutination;

public class TutinationRepo : ITutination
{
   //user 
  public Task<IEnumerable<UsersDao>> GetAllAsync(){
       throw new NotImplementedException();
   }
   public Task<UsersDao> GetByIdAsync(int id){
       throw new NotImplementedException();
   }
   public Task<int> AddAsync(UsersDao entity){
       throw new NotImplementedException();
   }
   public Task<bool> UpdateAsync(UsersDao entity){
       throw new NotImplementedException();
   }
   public Task<bool> DeleteAsync(int id){
       throw new NotImplementedException();
   }

   public Task<UsersDao> GetByEmailAsync(string email){
       throw new NotImplementedException();
   }
   public Task<bool> CheckEmailExistsAsync(string email){
       throw new NotImplementedException();
   }


//event
public Task<IEnumerable<EventsDao>> GetAllEventsAsync()
    {
        throw new NotImplementedException();
    }
    public Task<EventsDao> GetEventByIdAsync(int id){
        throw new NotImplementedException();
    }
    public Task<int> AddEventAsync(EventsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> UpdateEventAsync(EventsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> DeleteEventAsync(int id){
        throw new NotImplementedException();
    }


//tickets
    public Task<IEnumerable<TicketsDao>> GetAllTicketsAsync(){
        throw new NotImplementedException();
    }
    public Task<TicketsDao> GetTicketByIdAsync(int id){
        throw new NotImplementedException();
    }
    public Task<int> AddTicketAsync(TicketsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> UpdateTicketAsync(TicketsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> DeleteTicketAsync(int id){
        throw new NotImplementedException();
    }
    public Task<IEnumerable<TicketsDao>> GetTicketsByUserAsync(int userId){
        throw new NotImplementedException();
    }
    public Task<IEnumerable<TicketsDao>> GetTicketsByEventAsync(int eventId){
        throw new NotImplementedException();
    }
    //services
    public Task<IEnumerable<ServicesDao>> GetAllServicesAsync(){
        throw new NotImplementedException();
    }
    public Task<ServicesDao> GetServiceByIdAsync(int id){
        throw new NotImplementedException();
    }
    public Task<int> AddServiceAsync(ServicesDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> UpdateServiceAsync(ServicesDao entity){
        throw new NotImplementedException();
    }
   public Task<bool> DeleteServiceAsync(int id){
       throw new NotImplementedException();
   }

//apppointments
    public Task<IEnumerable<AppointmentsDao>> GetAllAppointmentsAsync(){
        throw new NotImplementedException();
    }
    public Task<AppointmentsDao> GetAppointmentByIdAsync(int id){
        throw new NotImplementedException();
    }
    public Task<int> AddAppointmentAsync(AppointmentsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> UpdateAppointmentAsync(AppointmentsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> DeleteAppointmentAsync(int id){
        throw new NotImplementedException();
    }
    public Task<IEnumerable<PaymentsDao>> GetPaymentsByUserAsync(int userId){
        throw new NotImplementedException();
    }
//payments
    public Task<IEnumerable<PaymentsDao>> GetAllPaymentsAsync(){
        throw new NotImplementedException();
    }
    public Task<PaymentsDao> GetPaymentByIdAsync(int id){
        throw new NotImplementedException();
    }
    public Task<int> AddPaymentAsync(PaymentsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> UpdatePaymentAsync(PaymentsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> DeletePaymentAsync(int id){
        throw new NotImplementedException();
    }
    public Task<PaymentsDao> GetPaymentByReferenceAsync(string referenceId){
        throw new NotImplementedException();
    }

    //PaymentTicket
   public Task LinkPaymentToTicketAsync(int paymentId, int ticketId){
       throw new NotImplementedException();
   }
   //payment appointment
    public Task LinkPaymentToAppointmentAsync(int paymentId, int appointmentId){
        throw new NotImplementedException();
    }
}
